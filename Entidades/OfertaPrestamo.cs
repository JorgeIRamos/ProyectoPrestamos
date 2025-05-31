using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OfertaPrestamo
    {
        public int id { get; set; }
        public decimal cantidad { get; set; }
        public decimal intereses { get; set; }
        public int plazo { get; set; }
        public int cuotas { get; set; }
        public int cuotas_restantes { get; set; }
        public string frecuencia { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechavencimiento { get; set; }
        public string proposito { get; set; }
        public string tipopago { get; set; }
        public string estado { get; set; }
        public int id_prestamista { get; set; }
        public Prestamista prestamista { get; set; }
    }

}
