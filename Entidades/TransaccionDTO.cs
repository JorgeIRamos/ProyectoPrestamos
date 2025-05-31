using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TransaccionDTO
    {
        public int id;
        public int id_prestamo { get; set; }
        public decimal monto { get; set; }
        public DateTime fecha { get; set; }
        public string tipo_transaccion { get; set; }
        public string NombrePrestatario { get; set; }
        public string ApellidoPrestatario { get; set; }
        public string NumeroDocumentoPrestatario { get; set; }

        public decimal Intereses { get; set; }

        public decimal cuota { get; set; }

        public string estado { get; set; }
    }
}
