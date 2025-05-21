using System;
using System.Collections.Generic;
using Npgsql;
using Entidades;

namespace Datos_POSTGRES
{
    public class PrestatarioRepository : BaseDatos, IFileRepository<Prestatario>
    {
        public PrestatarioRepository() : base() { }

        public List<Prestatario> Consultar()
        {
            string sentencia = @"
SELECT p.id_prestatario, per.*, td.nombre AS nombre_tipo_doc
FROM prestatario p
JOIN persona per ON p.id_prestatario = per.id_persona
JOIN tipo_documento td ON per.tipo_documento = td.id_documento";
            List<Prestatario> lista = new List<Prestatario>();

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
                    Console.WriteLine("Error al consultar prestatarios: " + ex.Message);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }

        public Prestatario Mappear(NpgsqlDataReader reader)
        {
            return new Prestatario
            {
                id_prestatario = reader.GetInt32(reader.GetOrdinal("id_prestatario")),
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
            };
        }

        public string Guardar(Prestatario entity)
        {
            if (entity == null || entity.id_prestatario <= 0)
                return "ID inválido";

            string sentencia = "INSERT INTO prestatario (id_prestatario) VALUES (@id)";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id", entity.id_prestatario);

                try
                {
                    AbrirConexion();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0 ? "Prestatario registrado correctamente." : "No se ha insertado el prestatario.";
                }
                catch (Exception ex)
                {
                    return $"Error al guardar: {ex.Message}";
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

            string sentencia = "DELETE FROM prestatario WHERE id_prestatario = @id";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    AbrirConexion();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0 ? "Registro eliminado correctamente" : "No se encontró el prestatario.";
                }
                catch (Exception ex)
                {
                    return $"Error al eliminar: {ex.Message}";
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }

        public string Modificar(Prestatario entity)
        {
            // No tiene sentido modificar solo el ID en este modelo.
            // Puedes lanzar una excepción o devolver un mensaje fijo.
            return "Operación no soportada: el ID del prestatario no puede modificarse.";
        }

        public Prestatario BuscarPorId(int id)
        {
            if (id <= 0)
                return null;

            string sentencia = "SELECT * FROM prestatario WHERE id_prestatario = @id";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    AbrirConexion();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Mappear(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al buscar prestatario: " + ex.Message);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return null;
        }

        public int GetId(Prestatario entity)
        {
            return entity.id_prestatario;
        }
    }
}
