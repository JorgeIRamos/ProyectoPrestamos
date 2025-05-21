using Entidades;
using System;
using Datos_POSTGRES;
public class Estrategia<T>
{
    /*
 ✅ ANTES (archivos de texto)
Tus repositorios como PrestamistaRepository heredaban de ArchivoDeRepositorio y su 
constructor requería una ruta:
public PrestamistaRepository(string ruta) : base(ruta) { }

Entonces en la clase Estrategia<T> tú podías hacer:

return (IFileRepository<T>)new PrestamistaRepository("prestamista.txt");

❌ AHORA (base de datos)
Tus repositorios ahora heredan de BaseDatos, y ya no usan archivos, por lo tanto sus 
constructores no reciben ningún parámetro:
public PrestamistaRepository() : base() { }


 */
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
        //else if (objeto is Usuario)
        //{
        //    return (IFileRepository<T>)new UsuarioRepository();
        //}
        else
        {
            throw new Exception("Tipo no soportado");
        }
    }
}
