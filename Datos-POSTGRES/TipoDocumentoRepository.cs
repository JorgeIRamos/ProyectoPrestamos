using System;
using System.Collections.Generic;
using Npgsql;
using Entidades;

namespace Datos_POSTGRES
{
    public class TipoDocumentoRepository : BaseDatos, IFileRepository<TipoDocumento>
    {
        public TipoDocumentoRepository() : base() { }

        public List<TipoDocumento> Consultar()
        {
            string sentencia = "SELECT * FROM tipo_documento ORDER BY Nombre";
            List<TipoDocumento> lista = new List<TipoDocumento>();

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
                    throw new Exception("Error al consultar TipoDocumentos: " + ex.Message);
                }
                finally
                {
                    CerrarConexion();
                }
            }
            return lista;
        }

        public TipoDocumento Mappear(NpgsqlDataReader reader)
        {
            return new TipoDocumento
            {
                id_documento = reader.GetInt32(reader.GetOrdinal("id_documento")),
                nombre = reader.GetString(reader.GetOrdinal("nombre"))
            };
        }

        public TipoDocumento BuscarPorId(int id)
        {
            if (id <= 0) return null;

            string sentencia = "SELECT * FROM TipoDocumentos WHERE Id_TipoDocumento = @Id";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@Id", id);

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

        public string Guardar(TipoDocumento entity)
        {
            if (entity == null || string.IsNullOrWhiteSpace(entity.nombre))
                return "Datos inválidos";

            string sentencia = @"INSERT INTO tipo_documento (id_documento, nombre) 
                                VALUES (@id_documento, @nombre)";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id_documento", entity.id_documento);
                cmd.Parameters.AddWithValue("@nombre", entity.nombre);

                try
                {
                    AbrirConexion();
                    int i = cmd.ExecuteNonQuery();
                    return i > 0 ? "Registro insertado correctamente" : "No se ha insertado...";
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


        public string Modificar(TipoDocumento entity)
        {
            if (entity == null || entity.id_documento <= 0 || string.IsNullOrWhiteSpace(entity.nombre))
                return "Datos inválidos";

            string sentencia = @"UPDATE tipo_documento SET nombre=@nombre WHERE id_documento=@id_documento";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", entity.nombre);
                cmd.Parameters.AddWithValue("@id_documento", entity.id_documento);

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

            string sentencia = "DELETE FROM tipo_documento WHERE id_documento = @id_documento";

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id_documento", id);

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

        public int GetId(TipoDocumento entity)
        {
            return entity?.id_documento ?? 0;
        }
    }
}
