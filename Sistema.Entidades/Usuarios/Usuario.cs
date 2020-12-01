using System.Collections.Generic;
using Sistema.Entidades.Registro;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades.Usuarios
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public byte[] password_hash { get; set; }
        public byte[] password_salt { get; set; }
        public bool Condicion { get; set; }

        [ForeignKey("idRol")]
        public virtual Rol Rol { get; set; }

        public virtual ICollection<Expediente> Expedientes { get; set; }
    }
}
