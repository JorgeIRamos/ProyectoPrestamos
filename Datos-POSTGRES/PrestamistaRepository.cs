using System;
using System.Collections.Generic;
using Npgsql;
using Entidades;

namespace Datos_POSTGRES
{
    public class PrestamistaRepository : BaseDatos, IFileRepository<Prestamista>
    {
        public PrestamistaRepository() : base() { }

        public List<Prestamista> Consultar()
        {
            string sentencia = @"
            SELECT p.id_prestamista, per.*, td.nombre AS nombre_tipo_doc
            FROM prestamista p
            JOIN persona per ON p.id_prestamista = per.id_persona
            JOIN tipo_documento td ON per.tipo_documento = td.id_documento";



            List<Prestamista> lista = new List<Prestamista>();

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
                    Console.WriteLine("Error al consultar prestamistas: " + ex.Message);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }


        public Prestamista Mappear(NpgsqlDataReader reader)
        {
            return new Prestamista
            {
                id_prestamista = reader.GetInt32(reader.GetOrdinal("id_prestamista")),
                Persona = new Persona
                {
                    id_persona = reader.GetInt32(reader.GetOrdinal("id_persona")),
                    nombre = reader.GetString(reader.GetOrdinal("nombre")),
                    apellido = reader.GetString(reader.GetOrdinal("apellido")),
                    NumeroDocumento = reader.GetString(reader.GetOrdinal("numerodocumento")),
                    tipo_documento = reader.GetInt32(reader.GetOrdinal("tipo_documento")),
                    tipodocumento= new TipoDocumento
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





        public string Guardar(Prestamista entity)
        {
            if (entity == null || entity.id_prestamista <= 0)
                return "ID inválido";

            string sentencia = "INSERT INTO prestamista (id_prestamista) VALUES (@id)";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id", entity.id_prestamista);

                try
                {
                    AbrirConexion();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0 ? "Prestamista registrado correctamente." : "No se ha insertado el prestamista.";
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
            string sentencia = "DELETE FROM prestamista WHERE id_prestamista = @id";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    AbrirConexion();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0 ? "Registro eliminado correctamente" : "No se encontró el prestamista.";
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

        public string Modificar(Prestamista entity)
        {
            return "No se puede modificar el ID del prestamista.";
        }

        public Prestamista BuscarPorId(int id)
        {
            string sentencia = "SELECT * FROM prestamista WHERE id_prestamista = @id";

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
                    Console.WriteLine("Error al buscar prestamista: " + ex.Message);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return null;
        }

        public int GetId(Prestamista entity)
        {
            return entity.id_prestamista;
        }
    }
}
