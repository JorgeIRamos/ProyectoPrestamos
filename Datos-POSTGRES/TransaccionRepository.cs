using System;
using System.Collections.Generic;
using Npgsql;
using Entidades;

namespace Datos_POSTGRES
{
    public class TransaccionRepository : BaseDatos, IFileRepository<Transaccion>
    {
        public TransaccionRepository() : base() { }

        public List<Transaccion> Consultar()
        {
            string sentencia = "SELECT * FROM transaccion ORDER BY fecha";

            List<Transaccion> lista = new List<Transaccion>();

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
                    throw new Exception("Error al consultar transacciones: " + ex.Message);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }

        public Transaccion Mappear(NpgsqlDataReader reader)
        {
            return new Transaccion
            {
                id_transaccion = reader.GetInt32(reader.GetOrdinal("id_transaccion")),
                tipo_transaccion = reader.GetString(reader.GetOrdinal("tipo_transaccion")),
                monto = reader.GetDecimal(reader.GetOrdinal("monto")),
                imagen = reader.IsDBNull(reader.GetOrdinal("imagen")) ? null : (byte[])reader["imagen"],
                fecha = reader.GetDateTime(reader.GetOrdinal("fecha")),
                id_prestamo = reader.GetInt32(reader.GetOrdinal("id_prestamo"))
            };
        }

        public string Guardar(Transaccion entity)
        {
            if (entity == null || string.IsNullOrWhiteSpace(entity.tipo_transaccion) || entity.id_prestamo <= 0)
                return "Datos inválidos";

            string sentencia = @"INSERT INTO transaccion (tipo_transaccion, monto, fecha, imagen, id_prestamo) 
                        VALUES (@tipo_transaccion, @monto, @fecha, @imagen, @id_prestamo) RETURNING id_transaccion";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@tipo_transaccion", entity.tipo_transaccion);
                cmd.Parameters.AddWithValue("@monto", entity.monto);
                cmd.Parameters.AddWithValue("@fecha", entity.fecha);
                cmd.Parameters.AddWithValue("@id_prestamo", entity.id_prestamo);
                cmd.Parameters.AddWithValue("@imagen", entity.imagen ?? (object)DBNull.Value);


                try
                {
                    AbrirConexion();
                    object result = cmd.ExecuteScalar();
                    return result != null ? $"Registro insertado correctamente con ID {result}" : "No se ha insertado...";
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

        public string Modificar(Transaccion entity)
        {
            if (entity == null || entity.id_transaccion <= 0 || entity.id_prestamo <= 0)
                return "Datos inválidos";

            string sentencia = @"UPDATE transaccion SET tipo_transaccion=@tipo_transaccion, monto=@monto, fecha=@fecha, id_prestamo=@id_prestamo 
                        WHERE id_transaccion=@id_transaccion";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@tipo_transaccion", entity.tipo_transaccion);
                cmd.Parameters.AddWithValue("@monto", entity.monto);
                cmd.Parameters.AddWithValue("@fecha", entity.fecha);
                cmd.Parameters.AddWithValue("@id_prestamo", entity.id_prestamo);
                cmd.Parameters.AddWithValue("@id_transaccion", entity.id_transaccion);

                try
                {
                    AbrirConexion();
                    int i = cmd.ExecuteNonQuery();
                    return i > 0 ? "Registro modificado correctamente" : "No se encontró el registro...";
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

            string sentencia = "DELETE FROM transaccion WHERE id_transaccion = @Id";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    AbrirConexion();
                    int i = cmd.ExecuteNonQuery();
                    return i > 0 ? "Registro eliminado correctamente" : "No se encontró el registro...";
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

        public Transaccion BuscarPorId(int id)
        {
            if (id <= 0) return null;

            string sentencia = "SELECT * FROM transaccion WHERE id_transaccion = @Id";

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

        public int GetId(Transaccion entity)
        {
            return entity?.id_transaccion ?? 0;
        }
    }
}
