using System;
using System.Collections.Generic;
using Npgsql;
using Entidades;

namespace Datos_POSTGRES
{
    public class OfertaPrestamoRepository : BaseDatos, IFileRepository<OfertaPrestamo>
    {
        public OfertaPrestamoRepository() : base() { }

        public List<OfertaPrestamo> Consultar()
        {
            string sentencia = @"
            SELECT o.*, 
                   p.id_prestamista, 
                   per.*, 
                   td.nombre AS nombre_tipo_doc
            FROM oferta_prestamo o
            JOIN prestamista p ON o.id_prestamista = p.id_prestamista
            JOIN persona per ON p.id_prestamista = per.id_persona
            JOIN tipo_documento td ON per.tipo_documento = td.id_documento";

            List<OfertaPrestamo> lista = new List<OfertaPrestamo>();

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
                    throw new Exception("Error al consultar ofertas de préstamo: " + ex.Message);
                }
                finally
                {
                    CerrarConexion();
                }
            }
            return lista;
        }

        public OfertaPrestamo Mappear(NpgsqlDataReader reader)
        {
            return new OfertaPrestamo
            {
                id = reader.GetInt32(reader.GetOrdinal("id")),
                cantidad = reader.GetDecimal(reader.GetOrdinal("cantidad")),
                intereses = reader.GetDecimal(reader.GetOrdinal("intereses")),
                plazo = reader.GetInt32(reader.GetOrdinal("plazo")),
                fechainicio = reader.GetDateTime(reader.GetOrdinal("fechainicio")),
                fechavencimiento = reader.GetDateTime(reader.GetOrdinal("fechavencimiento")),
                proposito = reader.IsDBNull(reader.GetOrdinal("proposito")) ? null : reader.GetString(reader.GetOrdinal("proposito")),
                tipopago = reader.GetString(reader.GetOrdinal("tipopago")),
                estado = reader.IsDBNull(reader.GetOrdinal("estado")) ? null : reader.GetString(reader.GetOrdinal("estado")),
                id_prestamista = Convert.ToInt32(reader["id_prestamista"]),
                prestamista = new Prestamista
                {
                    id_prestamista = reader.GetInt32(reader.GetOrdinal("id_prestamista")),
                    Persona = new Persona
                    {
                        id_persona = reader.GetInt32(reader.GetOrdinal("id_persona")),
                        nombre = reader.GetString(reader.GetOrdinal("nombre")),
                        apellido = reader.GetString(reader.GetOrdinal("apellido")),
                        NumeroDocumento = reader.GetString(reader.GetOrdinal("numerodocumento")),
                        tipo_documento = reader.GetInt32(reader.GetOrdinal("tipo_documento")),
                        tipodocumento = new TipoDocumento
                        {
                            id_documento = reader.GetInt32(reader.GetOrdinal("tipo_documento")),
                            nombre = reader.GetString(reader.GetOrdinal("nombre_tipo_doc"))
                        },
                        telefono = reader.IsDBNull(reader.GetOrdinal("telefono")) ? null : reader.GetString(reader.GetOrdinal("telefono")),
                        sexo = reader.IsDBNull(reader.GetOrdinal("sexo")) ? null : reader.GetString(reader.GetOrdinal("sexo")),
                        direccion = reader.IsDBNull(reader.GetOrdinal("direccion")) ? null : reader.GetString(reader.GetOrdinal("direccion")),
                        email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email")),
                        username = reader.GetString(reader.GetOrdinal("username")),
                        contraseña = reader.GetString(reader.GetOrdinal("contraseña"))
                    }
                }
            };
        }

        public string Guardar(OfertaPrestamo entity)
        {
            if (entity == null)
                return "Datos inválidos";

            string sentencia = @"INSERT INTO oferta_prestamo 
                        (cantidad, intereses, plazo, fechainicio, fechavencimiento, proposito, tipopago, estado, id_prestamista)
                        VALUES 
                        (@Cantidad, @Intereses, @Plazo, @FechaInicio, @FechaVencimiento, @Proposito, @TipoPago, @Estado, @IdPrestamista)
                        RETURNING id";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@Cantidad", entity.cantidad);
                cmd.Parameters.AddWithValue("@Intereses", entity.intereses);
                cmd.Parameters.AddWithValue("@Plazo", entity.plazo);
                cmd.Parameters.AddWithValue("@FechaInicio", entity.fechainicio);
                cmd.Parameters.AddWithValue("@FechaVencimiento", entity.fechavencimiento);
                cmd.Parameters.AddWithValue("@Proposito", (object)entity.proposito ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoPago", entity.tipopago);
                cmd.Parameters.AddWithValue("@Estado", (object)entity.estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdPrestamista", entity.id_prestamista);

                try
                {
                    AbrirConexion();
                    object result = cmd.ExecuteScalar();
                    return result != null ? $"Oferta insertada con ID {result}" : "No se insertó la oferta";
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

        public string Modificar(OfertaPrestamo entity)
        {
            if (entity == null || entity.id <= 0)
                return "Datos inválidos";

            string sentencia = @"UPDATE oferta_prestamo SET 
                                cantidad=@Cantidad, intereses=@Intereses, plazo=@Plazo, 
                                fechainicio=@FechaInicio, fechavencimiento=@FechaVencimiento, 
                                proposito=@Proposito, tipopago=@TipoPago, estado=@Estado, 
                                id_prestamista=@IdPrestamista 
                                WHERE id=@Id";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@Cantidad", entity.cantidad);
                cmd.Parameters.AddWithValue("@Intereses", entity.intereses);
                cmd.Parameters.AddWithValue("@Plazo", entity.plazo);
                cmd.Parameters.AddWithValue("@FechaInicio", entity.fechainicio);
                cmd.Parameters.AddWithValue("@FechaVencimiento", entity.fechavencimiento);
                cmd.Parameters.AddWithValue("@Proposito", (object)entity.proposito ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoPago", entity.tipopago);
                cmd.Parameters.AddWithValue("@Estado", (object)entity.estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdPrestamista", entity.id_prestamista);
                cmd.Parameters.AddWithValue("@Id", entity.id);

                try
                {
                    AbrirConexion();
                    int i = cmd.ExecuteNonQuery();
                    return i > 0 ? "Oferta modificada correctamente" : "No se encontró la oferta";
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

            string sentencia = "DELETE FROM oferta_prestamo WHERE id = @Id";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    AbrirConexion();
                    int i = cmd.ExecuteNonQuery();
                    return i > 0 ? "Oferta eliminada correctamente" : "No se encontró la oferta";
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

        public OfertaPrestamo BuscarPorId(int id)
        {
            if (id <= 0) return null;

            string sentencia = @"SELECT o.*, 
               p.id_prestamista, 
               per.*, 
               td.nombre AS nombre_tipo_doc
               FROM oferta_prestamo o
               JOIN prestamista p ON o.id_prestamista = p.id_prestamista
               JOIN persona per ON p.id_prestamista = per.id_persona
               JOIN tipo_documento td ON per.tipo_documento = td.id_documento
               WHERE o.id = @Id";


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


        public int GetId(OfertaPrestamo entity)
        {
            return entity?.id ?? 0;
        }


    }
}
