using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class TransaccionRepository : ArchivoDeRepositorio<Transaccion>
    {
        public TransaccionRepository(string ruta) : base(ruta)
        {
        }

        public override List<Transaccion> Consultar()
        {
            try
            {
                List<Transaccion> lista = new List<Transaccion>();

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

        public override Transaccion Mappear(string datos)
        {
            Transaccion transaccion = new Transaccion();

            transaccion.ID = int.Parse(datos.Split(';')[0]);
         //   transaccion.Tipo = datos.Split(';')[1];
          //  transaccion.Monto = double.Parse(datos.Split(';')[2]);
            //transaccion.Fecha = datos.Split(';')[3];
            Prestamo prestamo = new Prestamo();
          //  prestamo.ID = int.Parse(datos.Split(';')[4]);
            transaccion.Prestamo = prestamo;

            return transaccion;
        }

        public override Transaccion BuscarPorId(int id)
        {
            return Consultar().FirstOrDefault(x => x.ID == id);
        }
    }
}
