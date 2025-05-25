using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public interface IService<T>
    {
        string Guardar(T entity);
        string Modificar(T entity);
        string Eliminar(T entity);
        List<T> Consultar(T entity);

        T BuscarPorId(int id, T entity);
    }
}
