//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Entidades;
//namespace Datos
//{
//    public class HistorialDePagoRepository : ArchivoDeRepositorio<HistorialPago>
//    {
//        public HistorialDePagoRepository(string ruta) : base(ruta)
//        {
//        }
//        public override List<HistorialPago> Consultar()
//        {
//            try
//            {
//                List<HistorialPago> lista = new List<HistorialPago>();

//                StreamReader sr = new StreamReader(ruta);
//                while (!sr.EndOfStream)
//                {
//                    lista.Add(Mappear(sr.ReadLine())); // Mapea cada línea del archivo a una mascota
//                }
//                sr.Close(); // No olvides cerrar el archivo después de leer
//                return lista;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public override HistorialPago Mappear(string datos)
//        {
//            HistorialPago historialPago = new HistorialPago();

//            historialPago.ID = int.Parse(datos.Split(';')[0]);
//            historialPago.FechaPago = datos.Split(';')[1];
//            historialPago.MontoPagado = double.Parse(datos.Split(';')[2]);
//            Prestamo prestamo = new Prestamo();
//            return historialPago;
//        }
//        //public override int GetId(HistorialDePago entity)
//        //{
//        //    throw new NotImplementedException();
//        //}
//        public override HistorialPago BuscarPorId(int id)
//        {
//            return Consultar().FirstOrDefault<HistorialPago>(x => x.ID == id);
//        }
//    }

//}