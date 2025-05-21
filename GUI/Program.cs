using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Npgsql;
using Datos_POSTGRES;
using Entidades;
using Logica;
namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
            Datos_POSTGRES.BaseDatos bd = new Datos_POSTGRES.BaseDatos();
            var estado = bd.AbrirConexion();
            MessageBox.Show("Estado de la conexión: " + estado.ToString());
            // Crear instancia del repositorio
            PrestamistaRepository repo = new PrestamistaRepository();

            // Crear nuevo prestamista con datos de prueba
            Prestamista nuevo = new Prestamista
            {
                Nombre = "Juana Holaaa",
                Apellido = "Pérez Lanafa",
                Direccion = "Calle Falsa 123",
                Telefono = "555-1234",
                Email = "juan.perez@example.com",
                Sexo = "M"
            };
            Service<Prestamista> servicio = new Service<Prestamista>();
            // Guardar en BD
            string resultado = repo.Guardar(nuevo);
            //string resultado = servicio.Guardar(nuevo);

            // Mostrar resultado
            MessageBox.Show(resultado, "Resultado");

            //Cerrar la conexión
            bd.CerrarConexion();

            // Para que no se cierre la app de inmediato
          //  Application.Run();

        }
    }
}
