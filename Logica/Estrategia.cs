using Entidades;
using System;
using Datos_POSTGRES;
public class Estrategia<T>
{
    public IFileRepository<T> Repositorio(T objeto)
    {   if(objeto is Persona)
        {
            return (IFileRepository<T>)new PersonaRepository();
        }
        else if (objeto is Prestamista)
        {
            return (IFileRepository<T>)new PrestamistaRepository();
        }
        else if (objeto is Prestatario)
        {
            return (IFileRepository<T>)new PrestatarioRepository();
        }
        else if (objeto is OfertaPrestamo)
        {
            return (IFileRepository<T>)new OfertaPrestamoRepository();
        }
        else if (objeto is Prestamo)
        {
            return (IFileRepository<T>)new PrestamoRepository();
        }
        else if (objeto is Transaccion)
        {
            return (IFileRepository<T>)new TransaccionRepository();
        }
        else if (objeto is Recordatorio)
        {
            return (IFileRepository<T>)new RecordatorioRepository();
        }
        else if (objeto is TipoDocumento)
        {
            return (IFileRepository<T>)new TipoDocumentoRepository();
        }
        else
        {
            throw new Exception("Tipo no soportado");
        }
    }
}
