using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entidades;

namespace Datos
{
    public abstract class ArchivoDeRepositorio<T> : IFileRepository<T>
    {
        protected string ruta;
        public string Ruta => ruta; // Propiedad de solo lectura para acceder a la ruta desde fuera de la clase

        public ArchivoDeRepositorio()
        {

        }

        public ArchivoDeRepositorio(string ruta)
        {
            this.ruta = ruta;
        }

        public virtual string Guardar(T entity)
        {
            try
            {
                StreamWriter sw = new StreamWriter(ruta, true);
                sw.WriteLine(entity.ToString());
                sw.Close();
                return "ok";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public abstract List<T> Consultar();
        public abstract T Mappear(string datos);
        public virtual string Modificar(T entity)
        {
            try
            {
                List<T> lista = Consultar();
                File.Delete(ruta);
                foreach (var item in lista)
                {
                    if (!item.Equals(entity))
                    {
                        Guardar(item);
                    }
                }
                Guardar(entity);
                return "Modificado correctamente";
            }
            catch (Exception ex)
            {
                return $"Error al modificar: {ex.Message}";
            }
        }

        public virtual string Eliminar(int id)
        {
            try
            {
                List<T> lista = Consultar();
                File.Delete(ruta);
                foreach (var item in lista)
                {
                    if (!GetId(item).Equals(id))
                    {
                        Guardar(item);
                    }
                }
                return "Eliminado correctamente";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        }

        public virtual int GetId(T entity)
        {
            var property = entity.GetType().GetProperty("Id");
            if (property != null)
            {
                return (int)property.GetValue(entity);
            }
            return 0;
        }

        public virtual T BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public T BuscarProId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
