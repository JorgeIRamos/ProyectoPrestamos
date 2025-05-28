using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OfertaPrestamoDTO
    {
        public int id { get; set; }
        public decimal cantidad { get; set; }
        public decimal intereses { get; set; }
        public int plazo { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechavencimiento { get; set; }
        public string proposito { get; set; }
        public string tipopago { get; set; }
        public string estado { get; set; }
        public string NombrePrestamista { get; set; }
        public string ApellidoPrestamista { get; set; }

        public string NumeroDocumentoPrestamista { get; set; }
    }
}
