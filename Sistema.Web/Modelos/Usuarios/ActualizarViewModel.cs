using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Modelos.Usuarios
{
    public class ActualizarViewModel
    {
        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}
