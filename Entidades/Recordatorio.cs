using System;

namespace Entidades
{
    public class Recordatorio
    {
        public int id_recordatorio { get; set; }
        public int id_prestamo { get; set; }
        public DateTime fecharecordatorio { get; set; }
        public string mensaje { get; set; }
    }
}

