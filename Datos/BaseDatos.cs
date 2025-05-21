using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;

namespace Datos
{
    public class BaseDatos
    {

        //string cadenaConexion = "Server=.\\SQLEXPRESS;Database=VeterinariaDB;Trusted_Connection=True;";
        //string cadenaConexion = "Server=.\\SQLEXPRESS;Database=VeterinariaDB;User Id=sa;Password=123456;";
        protected string cadenaConexion = "Host=localhost;Port=5436;Username=postgres;Password=12345;Database=proyectointentarenlazar";

        //using (NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion))
        //{
        //    try
        //    {
        //        conexion.Open();
        //        Console.WriteLine("¡Conectado a PostgreSQL exitosamente!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error al conectar: {ex.Message}");
        //    }
        //}


        public NpgsqlConnection conexion;

        public BaseDatos()
        {
            conexion = new NpgsqlConnection(cadenaConexion);
        }

        public ConnectionState AbrirConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();

            }
            conexion.Open();
            return conexion.State;
        }
        public void CerrarConexion()
        {
            conexion.Close();
        }
    }
}
