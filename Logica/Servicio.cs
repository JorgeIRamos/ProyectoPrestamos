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

        public string AbrirConexion()
        {
            var bd = new Datos_POSTGRES.BaseDatos();
            return bd.AbrirConexion().ToString(); 
        }

        public string CerrarConexion()
        {
            var bd = new Datos_POSTGRES.BaseDatos();
            bd.CerrarConexion();
            return "Conexión cerrada"; 
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
            int id = repo.GetId(entity); 

            if (ExistePorId(id, entity))
            {
                return $"Ya existe un registro con ID = {id}.";
            }

            return repo.Guardar(entity);
        }


        public string Eliminar(T entity)
        {
            var repo = new Estrategia<T>().Repositorio(entity);
            int id = repo.GetId(entity);

            var existente = repo.BuscarPorId(id);
            if (existente == null)
            {
                return $"No se encontró un registro con ID = {id} para eliminar.";
            }

            return repo.Eliminar(id);
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

        public T BuscarPorId(int id, T entity)
        {
            var repo = new Estrategia<T>().Repositorio(entity);
            var resultado = repo.BuscarPorId(id);
            if (resultado == null)
            {
                throw new Exception($"No se encontró un registro con ID = {id}.");
            }
            return resultado;
        }
    }
}
