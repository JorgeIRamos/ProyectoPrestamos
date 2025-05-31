using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UsuariosDTO
    {
        public string id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroDocumento { get; set; }
        public string CorreoElectronico { get; set; }

        public string Telefono { get; set; }

        public string sexo { get; set; }
    }
}
