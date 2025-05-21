using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class PrestamoRepository : ArchivoDeRepositorio<Prestamo>
    {
        public PrestamoRepository(string ruta) : base(ruta)
        {
        }

        public override List<Prestamo> Consultar()
        {
            try
            {
                List<Prestamo> lista = new List<Prestamo>();

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

        public override Prestamo Mappear(string datos)
        {
            Prestamo prestamo = new Prestamo();

            string[] campos = datos.Split(';');

          //  prestamo.ID = int.Parse(campos[0]);
           // prestamo.Monto = double.Parse(campos[1]);
           // prestamo.TasaInteres = double.Parse(campos[2]);
         //   prestamo.FechaInicio = campos[3];
          // prestamo.FechaVencimiento = campos[4];
            prestamo.Estado = campos[5];

            // Asociar prestatario y prestamista por ID (solo referenciando ID por simplicidad)
         //   prestamo.Prestatario = new Prestatario { ID = int.Parse(campos[6]) };
          //  prestamo.Prestamista = new Prestamista { ID = int.Parse(campos[7]) };

            // No se cargan listas de transacciones ni historial para simplificar
            prestamo.Transacciones = new List<Transaccion>();
            prestamo.HistorialPagos = new List<HistorialPago>();
            prestamo.Recordatorios = new List<Recordatorio>();

            return prestamo;
        }

        public override Prestamo BuscarPorId(int id)
        {
            //return Consultar().FirstOrDefault(x => x.ID == id);
            // Lanzar que no se ha implementando el metodo
            throw new NotImplementedException("El método BuscarPorId no está implementado en PrestamoRepository.");
        }
    }
}
