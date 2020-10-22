using System;
using System.Collections.Generic;
namespace Sistema.Entidades.Usuarios
{
    public class Rol
    {
        public int idRol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Condicion { get; set; }

        public virtual ICollection<Usuario> usuarios { get; set; }
    }
}
