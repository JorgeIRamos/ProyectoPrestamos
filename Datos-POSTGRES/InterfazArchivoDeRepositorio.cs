using System.Collections.Generic;
using Npgsql;
namespace Datos_POSTGRES
{
    public interface IFileRepository<T>
    {
        string Guardar(T entity);
        List<T> Consultar();
        T Mappear(NpgsqlDataReader reader);
        T BuscarPorId(int id);
        int GetId(T entity);

        //  string Eliminar(T entity);

        string Eliminar(int id); // <= importante que sea por ID
        string Modificar(T entity);

    }
}