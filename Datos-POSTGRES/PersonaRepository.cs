using System;
using System.Collections.Generic;
using Npgsql;
using Entidades;

namespace Datos_POSTGRES
{
    public class PersonaRepository : BaseDatos, IFileRepository<Persona>
    {
        public PersonaRepository() : base() { }

        public List<Persona> Consultar()
        {
            string sentencia = "SELECT * FROM persona";
            List<Persona> lista = new List<Persona>();

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
                    Console.WriteLine("Error al consultar personas: " + ex.Message);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return lista;
        }

        public Persona Mappear(NpgsqlDataReader reader)
        {
            return new Persona
            {
                id_persona = reader.GetInt32(reader.GetOrdinal("id_persona")),
                nombre = reader.GetString(reader.GetOrdinal("nombre")),
                apellido = reader.GetString(reader.GetOrdinal("apellido")),
                NumeroDocumento = reader.GetString(reader.GetOrdinal("numerodocumento")),
                tipo_documento = reader.GetInt32(reader.GetOrdinal("tipo_documento")),
                telefono = reader.GetString(reader.GetOrdinal("telefono")),
                sexo = reader.GetString(reader.GetOrdinal("sexo")),
                direccion = reader.GetString(reader.GetOrdinal("direccion")),
                email = reader.GetString(reader.GetOrdinal("email")),
                username = reader.GetString(reader.GetOrdinal("username")),
                contraseña = reader.GetString(reader.GetOrdinal("contraseña"))
            };
        }

        public string Guardar(Persona entity)
        {
            if (entity == null || string.IsNullOrWhiteSpace(entity.nombre))
                return "Datos inválidos";

            string sentencia = @"
        INSERT INTO persona 
            (nombre, apellido, numerodocumento, tipo_documento, telefono, sexo, direccion, email, username, contraseña) 
        VALUES 
            (@nombre, @apellido, @numeroDocumento, @tipoDocumento, @telefono, @sexo, @direccion, @correo, @usuario, @clave)
        RETURNING id_persona";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", entity.nombre);
                cmd.Parameters.AddWithValue("@apellido", entity.apellido);
                cmd.Parameters.AddWithValue("@numeroDocumento", entity.NumeroDocumento);
                cmd.Parameters.AddWithValue("@tipoDocumento", entity.tipo_documento);
                cmd.Parameters.AddWithValue("@telefono", entity.telefono);
                cmd.Parameters.AddWithValue("@sexo", entity.sexo);
                cmd.Parameters.AddWithValue("@direccion", entity.direccion);
                cmd.Parameters.AddWithValue("@correo", entity.email);
                cmd.Parameters.AddWithValue("@usuario", entity.username);
                cmd.Parameters.AddWithValue("@clave", entity.contraseña);

                try
                {
                    AbrirConexion();
                    object result = cmd.ExecuteScalar();
                    return result != null ? $"Persona registrada correctamente con ID {result}." : "No se ha insertado la persona.";
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
            string sentencia = "DELETE FROM persona WHERE id_persona = @id";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    AbrirConexion();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0 ? "Registro eliminado correctamente." : "No se encontró la persona.";
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

        public string Modificar(Persona entity)
        {
            string sentencia = @"UPDATE persona SET 
                nombre = @nombre, 
                apellido = @apellido, 
                numerodocumento = @numeroDocumento, 
                tipo_documento = @tipoDocumento, 
                telefono = @telefono, 
                sexo = @sexo, 
                direccion = @direccion, 
                email = @correo, 
                username = @usuario, 
                contraseña = @clave 
                WHERE id_persona = @id";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id", entity.id_persona);
                cmd.Parameters.AddWithValue("@nombre", entity.nombre);
                cmd.Parameters.AddWithValue("@apellido", entity.apellido);
                cmd.Parameters.AddWithValue("@numeroDocumento", entity.NumeroDocumento);
                cmd.Parameters.AddWithValue("@tipoDocumento", entity.tipo_documento);
                cmd.Parameters.AddWithValue("@telefono", entity.telefono);
                cmd.Parameters.AddWithValue("@sexo", entity.sexo);
                cmd.Parameters.AddWithValue("@direccion", entity.direccion);
                cmd.Parameters.AddWithValue("@correo", entity.email);
                cmd.Parameters.AddWithValue("@usuario", entity.username);
                cmd.Parameters.AddWithValue("@clave", entity.contraseña);

                try
                {
                    AbrirConexion();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0 ? "Persona modificada correctamente." : "No se encontró la persona.";
                }
                catch (Exception ex)
                {
                    return $"Error al modificar: {ex.Message}";
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }

        public Persona BuscarPorId(int id)
        {
            string sentencia = "SELECT * FROM persona WHERE id_persona = @id";

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
                    Console.WriteLine("Error al buscar persona: " + ex.Message);
                }
                finally
                {
                    CerrarConexion();
                }
            }

            return null;
        }

        public int GetId(Persona entity)
        {
            return entity.id_persona;
        }
    }
}
