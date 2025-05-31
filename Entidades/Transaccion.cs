using System;

namespace Entidades
{
    public class Transaccion
    {
        public int id_transaccion { get; set; }
        public int id_prestamo { get; set; }
        public decimal monto { get; set; }
        public DateTime fecha { get; set; }
        public byte[] imagen { get; set; }
        public string tipo_transaccion { get; set; }
    }
}
