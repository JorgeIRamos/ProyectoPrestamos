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
            // Usamos el nombre correcto de la columna en ORDER BY
            string sentencia = "SELECT * FROM recordatorio ORDER BY fecharecordatorio";

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
                id_prestamo = reader.GetInt32(reader.GetOrdinal("id_prestamo"))
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
