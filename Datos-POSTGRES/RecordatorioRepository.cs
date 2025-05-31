using System;
using System.Collections.Generic;
using Npgsql;
using Entidades;

namespace Datos_POSTGRES
{
    public class RecordatorioRepository : BaseDatos, IFileRepository<Recordatorio>
    {
        public RecordatorioRepository() : base() { }

        public List<Recordatorio> Consultar()
        {
            string sentencia = @"
SELECT 
    r.id_recordatorio, r.fecharecordatorio, r.mensaje, r.id_prestamo,
    
    p.id_prestamo, p.saldo_restante, p.estado, p.id_ofertaprestamo, p.id_prestatario,
    
    pr.id_prestatario, 
    
    per_prestatario.id_persona, 
    per_prestatario.nombre AS nombre_prestatario, 
    per_prestatario.apellido AS apellido_prestatario, 
    per_prestatario.NumeroDocumento AS numerodocumento_prestatario, 
    per_prestatario.tipo_documento AS tipo_documento_prestatario, 
    per_prestatario.telefono AS telefono_prestatario, 
    per_prestatario.sexo AS sexo_prestatario, 
    per_prestatario.direccion AS direccion_prestatario, 
    per_prestatario.email AS email_prestatario, 
    per_prestatario.username AS username_prestatario, 
    per_prestatario.contraseña AS contraseña_prestatario,
    
    td_prestatario.nombre AS nombre_doc_prestatario,

    op.id AS id_oferta, 
    op.cantidad, 
    op.intereses, 
    op.plazo, 
    op.cuotas, 
    op.cuotas_restantes,        
    op.frecuencia, 
    op.fechainicio, 
    op.fechavencimiento, 
    op.proposito, 
    op.tipopago, 
    op.estado AS estado_oferta, 
    op.id_prestamista,
    
    pre.id_prestamista,
    
    per_prestamista.id_persona AS id_persona_prestamista, 
    per_prestamista.nombre AS nombre_prestamista, 
    per_prestamista.apellido AS apellido_prestamista,
    per_prestamista.NumeroDocumento AS numerodocumento_prestamista, 
    per_prestamista.tipo_documento AS tipo_documento_prestamista, 
    per_prestamista.telefono AS telefono_prestamista, 
    per_prestamista.sexo AS sexo_prestamista, 
    per_prestamista.direccion AS direccion_prestamista, 
    per_prestamista.email AS email_prestamista, 
    per_prestamista.username AS username_prestamista, 
    per_prestamista.contraseña AS contraseña_prestamista,
    
    td_prestamista.nombre AS nombre_doc_prestamista

FROM recordatorio r
JOIN prestamo p ON r.id_prestamo = p.id_prestamo
JOIN prestatario pr ON p.id_prestatario = pr.id_prestatario
JOIN persona per_prestatario ON pr.id_prestatario = per_prestatario.id_persona
JOIN tipo_documento td_prestatario ON per_prestatario.tipo_documento = td_prestatario.id_documento
JOIN oferta_prestamo op ON p.id_ofertaprestamo = op.id
JOIN prestamista pre ON op.id_prestamista = pre.id_prestamista
JOIN persona per_prestamista ON pre.id_prestamista = per_prestamista.id_persona
JOIN tipo_documento td_prestamista ON per_prestamista.tipo_documento = td_prestamista.id_documento

ORDER BY r.fecharecordatorio;
";

            List<Recordatorio> lista = new List<Recordatorio>();

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                try
                {
                    AbrirConexion();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(Mappear(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar recordatorios: " + ex.Message);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }

        public Recordatorio Mappear(NpgsqlDataReader reader)
        {
            return new Recordatorio
            {
                id_recordatorio = reader.GetInt32(reader.GetOrdinal("id_recordatorio")),
                mensaje = reader.GetString(reader.GetOrdinal("mensaje")),
                fecharecordatorio = reader.GetDateTime(reader.GetOrdinal("fecharecordatorio")),
                id_prestamo = reader.GetInt32(reader.GetOrdinal("id_prestamo")),
                Prestamo = new PrestamoRepository().Mappear(reader) 
            };
        }

        public string Guardar(Recordatorio entity)
        {
            if (entity == null || string.IsNullOrWhiteSpace(entity.mensaje) || entity.id_prestamo <= 0)
                return "Datos inválidos";

            string sentencia = @"INSERT INTO recordatorio (id_prestamo, fecharecordatorio, mensaje) 
                                VALUES (@IdPrestamo, @FechaRecordatorio, @Mensaje) RETURNING id_recordatorio";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@IdPrestamo", entity.id_prestamo);
                cmd.Parameters.AddWithValue("@FechaRecordatorio", entity.fecharecordatorio);
                cmd.Parameters.AddWithValue("@Mensaje", entity.mensaje);

                try
                {
                    AbrirConexion();
                    var result = cmd.ExecuteScalar();
                    return result != null ? $"Registro insertado correctamente con ID {result}" : "No se insertó el registro";
                }
                catch (Exception ex)
                {
                    return $"Error: {ex.Message}";
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }

        public string Modificar(Recordatorio entity)
        {
            if (entity == null || entity.id_recordatorio <= 0 || entity.id_prestamo <= 0 || string.IsNullOrWhiteSpace(entity.mensaje))
                return "Datos inválidos";

            string sentencia = @"UPDATE recordatorio 
                                SET id_prestamo = @IdPrestamo, fecharecordatorio = @FechaRecordatorio, mensaje = @Mensaje 
                                WHERE id_recordatorio = @Id";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@IdPrestamo", entity.id_prestamo);
                cmd.Parameters.AddWithValue("@FechaRecordatorio", entity.fecharecordatorio);
                cmd.Parameters.AddWithValue("@Mensaje", entity.mensaje);
                cmd.Parameters.AddWithValue("@Id", entity.id_recordatorio);

                try
                {
                    AbrirConexion();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0 ? "Registro modificado correctamente" : "No se encontró el registro";
                }
                catch (Exception ex)
                {
                    return $"Error: {ex.Message}";
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }

        public string Eliminar(int id)
        {
            if (id <= 0)
                return "ID inválido";

            string sentencia = "DELETE FROM recordatorio WHERE id_recordatorio = @Id";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    AbrirConexion();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0 ? "Registro eliminado correctamente" : "No se encontró el registro";
                }
                catch (Exception ex)
                {
                    return $"Error: {ex.Message}";
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }

        public Recordatorio BuscarPorId(int id)
        {
            if (id <= 0) return null;

            string sentencia = "SELECT * FROM recordatorio WHERE id_recordatorio = @Id";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    AbrirConexion();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return Mappear(reader);
                    }
                }
                catch
                {
                    return null;
                }
                finally
                {
                    CerrarConexion();
                }
            }
            return null;
        }

        public int GetId(Recordatorio entity)
        {
            return entity?.id_recordatorio ?? 0;
        }
    }
}
