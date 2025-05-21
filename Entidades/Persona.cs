using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        public int id_persona { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string NumeroDocumento { get; set; }
        public int tipo_documento { get; set; }
        public TipoDocumento tipodocumento { get; set; }
        public string telefono { get; set; }
        public string sexo { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string contraseña { get; set; }
    }

}

