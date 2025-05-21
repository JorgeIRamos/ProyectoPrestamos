using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class PrestatarioRepository : ArchivoDeRepositorio<Prestatario>
    {
        public PrestatarioRepository(string ruta) : base(ruta)
        {
        }

        public override List<Prestatario> Consultar()
        {
            try
            {
                List<Prestatario> lista = new List<Prestatario>();

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
        public override Prestatario Mappear(string datos)
        {
            Prestatario prestatario = new Prestatario();

            string[] campos = datos.Split(';');

          //  prestatario.ID = int.Parse(campos[0]);
            prestatario.Nombre = campos[1];
            prestatario.Apellido = campos[2];
            prestatario.Direccion = campos[3];
            prestatario.Telefono = campos[4];
            prestatario.Email = campos[5];
         //   prestatario.Sexo = char.Parse(campos[6]);
            return prestatario;
        }

        public override Prestatario BuscarPorId(int id)
        {
            //  return Consultar().FirstOrDefault(x => x.ID == id);
            ///lanzar que no se ha implementando el metodo

            throw new NotImplementedException("El método BuscarPorId no está implementado en PrestatarioRepository.");
        }
    }
}
