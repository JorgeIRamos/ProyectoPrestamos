using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logica
{
    public class Service<T> : IService<T>
    {
        //Vamos a comunicar el servicio con la capa base de datos. Para abrir la conexion

        public string AbrirConexion()
        {
            var bd = new Datos_POSTGRES.BaseDatos();
            return bd.AbrirConexion().ToString();  // Convierte el enum ConnectionState a texto
        }

        public string CerrarConexion()
        {
            var bd = new Datos_POSTGRES.BaseDatos();
            bd.CerrarConexion();
            return "Conexión cerrada";  // O también puedes retornar bd.EstadoConexion().ToString() si existe.
        }


        public List<T> Consultar(T entity)
        {
            var repo = new Estrategia<T>().Repositorio(entity);
            return repo.Consultar();
        }

        public bool ExistePorId(int id, T entity)
        {
            var existente = new Estrategia<T>().Repositorio(entity).BuscarPorId(id);
            return existente != null;
        }

        public string Guardar(T entity)
        {
            var repo = new Estrategia<T>().Repositorio(entity);
            int id = repo.GetId(entity); // Método común en todos los repositorios

            if (ExistePorId(id, entity))
            {
                return $"Ya existe un registro con ID = {id}.";
            }

            return repo.Guardar(entity);
        }

        //public string Eliminar(T entity)
        //{
        //    throw new NotImplementedException();
        //}
        public string Eliminar(T entity)
        {
            var repo = new Estrategia<T>().Repositorio(entity);
            int id = repo.GetId(entity);

            var existente = repo.BuscarPorId(id);
            if (existente == null)
            {
                return $"No se encontró un registro con ID = {id} para eliminar.";
            }

            return repo.Eliminar(id); // ahora usamos el método correcto que recibe un ID
        }


        public string Modificar(T entity)
        {
            var repo = new Estrategia<T>().Repositorio(entity);
            int id = repo.GetId(entity);

            var existente = repo.BuscarPorId(id);
            if (existente == null)
            {
                return $"No se encontró un registro con ID = {id} para modificar.";
            }

            return repo.Modificar(entity);
        }

    }
}
