using System.Collections.Generic;

namespace Datos
{
    public interface IFileRepository<T>
    {
        //PARA OBLIGAR A IMPLEMENTAR LOS METODOS A ArchivoDeRepositorio
        List<T> Consultar();
        string Guardar(T entity);
        T Mappear(string datos);

        //NUEVO METODOS
        int GetId(T entity);
        T BuscarProId(int id);
    }
}