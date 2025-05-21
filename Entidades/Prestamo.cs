using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Prestamo
    {
        public int id_prestamo { get; set; }
        public int id_prestatario { get; set; }
        public int id_ofertaprestamo { get; set; }
        public decimal saldo_restante { get; set; }
        public string estado { get; set; }
        public OfertaPrestamo ofertaPrestamo { get; set; }
        public Prestatario prestatario { get; set; }
    }
}
