using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Datos
{
    public class PrestamistaRepository : ArchivoDeRepositorio<Prestamista>
    {
        public PrestamistaRepository(string ruta) : base(ruta)
        {
        }
        public override List<Prestamista> Consultar()
        {
            try
            {
                List<Prestamista> lista = new List<Prestamista>();

                StreamReader sr = new StreamReader(ruta);
                while (!sr.EndOfStream)
                {
                    lista.Add(Mappear(sr.ReadLine())); 
                }
                sr.Close(); 
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Prestamista Mappear(string datos)
        {
            Prestamista prestamista = new Prestamista();

          //  prestamista.ID = int.Parse(datos.Split(';')[0]);
            prestamista.Nombre = datos.Split(';')[1];
            prestamista.Apellido = datos.Split(';')[2];
            prestamista.Direccion = datos.Split(';')[3];
            prestamista.Telefono = datos.Split(';')[4];
            prestamista.Email = datos.Split(';')[5];
          //  prestamista.Sexo = char.Parse(datos.Split(';')[6]);

            return prestamista;
        }

       

        public override Prestamista BuscarPorId(int id)
        {
            //   return Consultar().FirstOrDefault<Prestamista>(x => x.ID == id);
            // Lanzar que no se ha implementando el metodo
            throw new NotImplementedException("El método BuscarPorId no está implementado en PrestamistaRepository.");
        }

    }

}