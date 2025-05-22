using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;

namespace Datos_POSTGRES
{
    public class BaseDatos
    {

       
        protected string cadenaConexion = "Host=localhost;Port=5432;Username=postgres;Password=12345;Database=prueba";

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
