using System;
using System.Collections.Generic;
using Npgsql;
using Entidades;

namespace Datos_POSTGRES
{
    public class PrestamoRepository : BaseDatos, IFileRepository<Prestamo>
    {
        public PrestamoRepository() : base() { }

        public List<Prestamo> Consultar()
        {
            List<Prestamo> lista = new List<Prestamo>();
            string sentencia = @"
        SELECT 
            p.id_prestamo,
            p.saldo_restante,
            p.estado,
            p.id_ofertaprestamo,
            p.id_prestatario,

            pr.id_prestatario,
            persona_pre.id_persona AS id_persona,
            persona_pre.nombre AS nombre_prestatario,
            persona_pre.apellido AS apellido_prestatario,
            persona_pre.numerodocumento AS numerodocumento_prestatario,
            persona_pre.tipo_documento AS tipo_documento_prestatario,
            persona_pre.telefono AS telefono_prestatario,
            persona_pre.sexo AS sexo_prestatario,
            persona_pre.direccion AS direccion_prestatario,
            persona_pre.email AS email_prestatario,
            persona_pre.username AS username_prestatario,
            persona_pre.contraseña AS contraseña_prestatario,
            td_pre.nombre AS nombre_doc_prestatario,

            o.id AS id_oferta,
            o.cantidad,
            o.intereses,
            o.plazo,
            o.cuotas,
            o.frecuencia,
            o.fechainicio,
            o.fechavencimiento,
            o.proposito,
            o.tipopago,
            o.estado AS estado_oferta,
            o.id_prestamista,

            pm.id_prestamista,
            persona_pm.id_persona AS id_persona_prestamista,
            persona_pm.nombre AS nombre_prestamista,
            persona_pm.apellido AS apellido_prestamista,
            persona_pm.numerodocumento AS numerodocumento_prestamista,
            persona_pm.tipo_documento AS tipo_documento_prestamista,
            persona_pm.telefono AS telefono_prestamista,
            persona_pm.sexo AS sexo_prestamista,
            persona_pm.direccion AS direccion_prestamista,
            persona_pm.email AS email_prestamista,
            persona_pm.username AS username_prestamista,
            persona_pm.contraseña AS contraseña_prestamista,
            td_pm.nombre AS nombre_doc_prestamista

        FROM prestamo p
        JOIN prestatario pr ON p.id_prestatario = pr.id_prestatario
        JOIN persona persona_pre ON pr.id_prestatario = persona_pre.id_persona
        JOIN tipo_documento td_pre ON persona_pre.tipo_documento = td_pre.id_documento
        JOIN oferta_prestamo o ON p.id_ofertaprestamo = o.id
        JOIN prestamista pm ON o.id_prestamista = pm.id_prestamista
        JOIN persona persona_pm ON pm.id_prestamista = persona_pm.id_persona
        JOIN tipo_documento td_pm ON persona_pm.tipo_documento = td_pm.id_documento
        ";

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
                    Console.WriteLine("Error al consultar préstamos: " + ex.Message);
                }
                finally
                {
                    CerrarConexion();
                }
            }
            return lista;
        }

        public Prestamo Mappear(NpgsqlDataReader reader)
        {
            var prestamo = new Prestamo
            {
                id_prestamo = reader.GetInt32(reader.GetOrdinal("id_prestamo")),
                saldo_restante = reader.GetDecimal(reader.GetOrdinal("saldo_restante")),
                estado = reader.GetString(reader.GetOrdinal("estado")),
                id_ofertaprestamo = reader.GetInt32(reader.GetOrdinal("id_ofertaprestamo")),
                id_prestatario = reader.GetInt32(reader.GetOrdinal("id_prestatario")),

                prestatario = new Prestatario
                {
                    id_prestatario = reader.GetInt32(reader.GetOrdinal("id_prestatario")),
                    Persona = new Persona
                    {
                        id_persona = reader.GetInt32(reader.GetOrdinal("id_persona")),
                        nombre = reader.GetString(reader.GetOrdinal("nombre_prestatario")),
                        apellido = reader.GetString(reader.GetOrdinal("apellido_prestatario")),
                        NumeroDocumento = reader.GetString(reader.GetOrdinal("numerodocumento_prestatario")),
                        tipo_documento = reader.GetInt32(reader.GetOrdinal("tipo_documento_prestatario")),
                        telefono = reader.IsDBNull(reader.GetOrdinal("telefono_prestatario")) ? null : reader.GetString(reader.GetOrdinal("telefono_prestatario")),
                        sexo = reader.IsDBNull(reader.GetOrdinal("sexo_prestatario")) ? null : reader.GetString(reader.GetOrdinal("sexo_prestatario")),
                        direccion = reader.IsDBNull(reader.GetOrdinal("direccion_prestatario")) ? null : reader.GetString(reader.GetOrdinal("direccion_prestatario")),
                        email = reader.IsDBNull(reader.GetOrdinal("email_prestatario")) ? null : reader.GetString(reader.GetOrdinal("email_prestatario")),
                        username = reader.GetString(reader.GetOrdinal("username_prestatario")),
                        contraseña = reader.GetString(reader.GetOrdinal("contraseña_prestatario")),
                        tipodocumento = new TipoDocumento
                        {
                            id_documento = reader.GetInt32(reader.GetOrdinal("tipo_documento_prestatario")),
                            nombre = reader.GetString(reader.GetOrdinal("nombre_doc_prestatario"))
                        }
                    }
                },

                ofertaPrestamo = new OfertaPrestamo
                {
                    id = reader.GetInt32(reader.GetOrdinal("id_oferta")),
                    cantidad = reader.GetDecimal(reader.GetOrdinal("cantidad")),
                    intereses = reader.GetDecimal(reader.GetOrdinal("intereses")),
                    plazo = reader.GetInt32(reader.GetOrdinal("plazo")),
                    cuotas = reader.GetInt32(reader.GetOrdinal("cuotas")),
                    frecuencia = reader.GetString(reader.GetOrdinal("frecuencia")),
                    fechainicio = reader.GetDateTime(reader.GetOrdinal("fechainicio")),
                    fechavencimiento = reader.GetDateTime(reader.GetOrdinal("fechavencimiento")),
                    proposito = reader.GetString(reader.GetOrdinal("proposito")),
                    tipopago = reader.GetString(reader.GetOrdinal("tipopago")),
                    estado = reader.GetString(reader.GetOrdinal("estado_oferta")),
                    id_prestamista = reader.GetInt32(reader.GetOrdinal("id_prestamista")),

                    prestamista = new Prestamista
                    {
                        id_prestamista = reader.GetInt32(reader.GetOrdinal("id_prestamista")),
                        Persona = new Persona
                        {
                            id_persona = reader.GetInt32(reader.GetOrdinal("id_persona_prestamista")),
                            nombre = reader.GetString(reader.GetOrdinal("nombre_prestamista")),
                            apellido = reader.GetString(reader.GetOrdinal("apellido_prestamista")),
                            NumeroDocumento = reader.GetString(reader.GetOrdinal("numerodocumento_prestamista")),
                            tipo_documento = reader.GetInt32(reader.GetOrdinal("tipo_documento_prestamista")),
                            telefono = reader.IsDBNull(reader.GetOrdinal("telefono_prestamista")) ? null : reader.GetString(reader.GetOrdinal("telefono_prestamista")),
                            sexo = reader.IsDBNull(reader.GetOrdinal("sexo_prestamista")) ? null : reader.GetString(reader.GetOrdinal("sexo_prestamista")),
                            direccion = reader.IsDBNull(reader.GetOrdinal("direccion_prestamista")) ? null : reader.GetString(reader.GetOrdinal("direccion_prestamista")),
                            email = reader.IsDBNull(reader.GetOrdinal("email_prestamista")) ? null : reader.GetString(reader.GetOrdinal("email_prestamista")),
                            username = reader.GetString(reader.GetOrdinal("username_prestamista")),
                            contraseña = reader.GetString(reader.GetOrdinal("contraseña_prestamista")),
                            tipodocumento = new TipoDocumento
                            {
                                id_documento = reader.GetInt32(reader.GetOrdinal("tipo_documento_prestamista")),
                                nombre = reader.GetString(reader.GetOrdinal("nombre_doc_prestamista"))
                            }
                        }
                    }
                }
            };

            // 🟢 Estado calculado según el saldo restante
            prestamo.estado = prestamo.saldo_restante > 0 ? "Activo" : "Finalizado";

            return prestamo;
        }



        public string Guardar(Prestamo entity)
        {
            if (entity == null || entity.id_prestatario <= 0 || entity.id_ofertaprestamo <= 0)
                return "Datos inválidos";

            string sentencia = @"
            INSERT INTO prestamo (id_prestatario, id_ofertaprestamo, saldo_restante, estado) 
            VALUES (@id_prestatario, @id_ofertaprestamo, @saldo_restante, @estado) 
            RETURNING id_prestamo";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id_prestatario", entity.id_prestatario);
                cmd.Parameters.AddWithValue("@id_ofertaprestamo", entity.id_ofertaprestamo);
                cmd.Parameters.AddWithValue("@saldo_restante", entity.saldo_restante);
                cmd.Parameters.AddWithValue("@estado", entity.estado);

                try
                {
                    AbrirConexion();
                    var result = cmd.ExecuteScalar();
                    return result != null ? $"Préstamo guardado con ID {result}" : "No se ha insertado el préstamo.";
                }
                catch (Exception ex)
                {
                    return $"Error al guardar préstamo: {ex.Message}";
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }

        public string Modificar(Prestamo entity)
        {
            if (entity == null || entity.id_prestamo <= 0)
                return "Datos inválidos";

            string sentencia = @"
            UPDATE prestamo SET
                id_prestatario = @id_prestatario,
                id_ofertaprestamo = @id_ofertaprestamo,
                saldo_restante = @saldo_restante,
                estado = @estado
            WHERE id_prestamo = @id_prestamo";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id_prestatario", entity.id_prestatario);
                cmd.Parameters.AddWithValue("@id_ofertaprestamo", entity.id_ofertaprestamo);
                cmd.Parameters.AddWithValue("@saldo_restante", entity.saldo_restante);
                cmd.Parameters.AddWithValue("@estado", entity.estado);
                cmd.Parameters.AddWithValue("@id", entity.id_prestamo);

                try
                {
                    AbrirConexion();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0 ? "Préstamo modificado correctamente" : "No se encontró el préstamo.";
                }
                catch (Exception ex)
                {
                    return $"Error al modificar préstamo: {ex.Message}";
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

            string sentencia = "DELETE FROM prestamo WHERE id_prestamo = @id_prestamo";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id_prestamo", id);

                try
                {
                    AbrirConexion();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0 ? "Préstamo eliminado correctamente" : "No se encontró el préstamo.";
                }
                catch (Exception ex)
                {
                    return $"Error al eliminar préstamo: {ex.Message}";
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }

        public Prestamo BuscarPorId(int id)
        {
            if (id <= 0)
                return null;

          string sentencia = @"
    SELECT
        p.id_prestamo,
        p.saldo_restante,
        p.estado,
        p.id_oferta_prestamo,
        p.id_prestatario,
        
        per_pr.id_persona AS id_persona_prestatario,
        per_pr.nombre AS nombre_prestatario,
        per_pr.apellido AS apellido_prestatario,
        per_pr.numero_documento AS numero_documento_prestatario,
        per_pr.tipo_documento AS tipo_documento_prestatario,
        per_pr.telefono AS telefono_prestatario,
        per_pr.sexo AS sexo_prestatario,
        per_pr.direccion AS direccion_prestatario,
        per_pr.email AS email_prestatario,
        per_pr.username AS username_prestatario,
        per_pr.contrasena AS contrasena_prestatario,
        td_pr.nombre AS nombre_doc_prestatario,
        
        o.id AS id_oferta,
        o.cantidad,
        o.intereses,
        o.plazos,
        o.cuotas,
        o.frecuencia,
        o.fecha_inicio,
        o.fecha_vencimiento,
        o.proposito,
        o.tipo_pago,
        o.estado AS estado_oferta,
        o.id_prestamista,
        
        pm.id_prestamista,
        per_pm.id_persona AS id_persona_prestamista,
        per_pm.nombre AS nombre_prestamista,
        per_pm.apellido AS apellido_prestamista,
        per_pm.numero_documento AS numero_documento_prestamista,
        per_pm.tipo_documento AS tipo_documento_prestamista,
        per_pm.telefono AS telefono_prestamista,
        per_pm.sexo AS sexo_prestamista,
        per_pm.direccion AS direccion_prestamista,
        per_pm.email AS email_prestamista,
        per_pm.username AS username_prestamista,
        per_pm.contrasena AS contrasena_prestamista,
        td_pm.nombre AS nombre_doc_prestamista
        
    FROM prestamo p
    JOIN prestatario pr ON p.id_prestatario = pr.id_prestatario
    JOIN persona per_pr ON pr.id_prestatario = per_pr.id_persona
    JOIN tipo_documento td_pr ON per_pr.tipo_documento = td_pr.id_documento
    JOIN oferta_prestamo o ON p.id_oferta_prestamo = o.id
    JOIN prestamista pm ON o.id_prestamista = pm.id_prestamista
    JOIN persona per_pm ON pm.id_prestamista = per_pm.id_persona
    JOIN tipo_documento td_pm ON per_pm.tipo_documento = td_pm.id_documento
    WHERE p.id_prestamo = @id_prestamo"; ;

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id_prestamo", id);

                try
                {
                    AbrirConexion();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return Mappear(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en BuscarPorId: " + ex.Message);
                    return null;
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return null;
        }


        public int GetId(Prestamo entity)
        {
            return entity?.id_prestamo ?? 0;
        }
    }
}
