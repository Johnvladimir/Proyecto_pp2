
namespace Sistema.Web.Modelos.Usuarios
{
    public class ActualizarViewModel
    {
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string password { get; set; }
        public bool act_password { get; set; }
    }
}
