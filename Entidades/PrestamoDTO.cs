using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PrestamoDTO
    {
        public int id_prestamo { get; set; }
        public decimal saldo_restante { get; set; }
        public string estado { get; set; }
        public int id_ofertaprestamo { get; set; }
        public string NombrePrestamista { get; set; }
        public string ApellidoPrestamista { get; set; }
        public string NumeroDocumentoPrestamista { get; set; }
        public decimal cantidad { get; set; }
        public decimal intereses { get; set; }
        public int plazo { get; set; }
        public int cuotas { get; set; }
        public string frecuencia { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechavencimiento { get; set; }
        public string proposito { get; set; }
        public string tipopago { get; set; }

    }
}
