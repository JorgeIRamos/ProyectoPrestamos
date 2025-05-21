using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class RecordatorioRepository : ArchivoDeRepositorio<Recordatorio>
    {
        public RecordatorioRepository(string ruta) : base(ruta)
        {
        }

        public override List<Recordatorio> Consultar()
        {
            try
            {
                List<Recordatorio> lista = new List<Recordatorio>();

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

        public override Recordatorio Mappear(string datos)
        {
            Recordatorio recordatorio = new Recordatorio();

            recordatorio.ID = int.Parse(datos.Split(';')[0]);
            recordatorio.Mensaje = datos.Split(';')[1];
          //  recordatorio.Fecha = datos.Split(';')[2];

            return recordatorio;
        }

        public override Recordatorio BuscarPorId(int id)
        {
            return Consultar().FirstOrDefault(x => x.ID == id);
        }
    }
}
