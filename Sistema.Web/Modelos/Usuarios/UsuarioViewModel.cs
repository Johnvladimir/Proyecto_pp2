
namespace Sistema.Web.Modelos.Usuarios
{
    public class UsuarioViewModel
    {
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public string rol { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public byte[] password_hash { get; set; }
        public bool Condicion { get; set; }
    }
}
