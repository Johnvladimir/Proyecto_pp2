using System.Collections.Generic;
using Sistema.Entidades.Registro;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades.Usuarios
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }

        [ForeignKey("idRol")]
        public virtual Rol Rol { get; set; }

        public virtual ICollection<Expediente> Expedientes { get; set; }
    }
}
