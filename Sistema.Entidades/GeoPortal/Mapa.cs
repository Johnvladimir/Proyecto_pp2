using Sistema.Entidades.Empleado;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades.GeoPortal
{
    public class Mapa
    {
        public int idMapa { get; set; }
        public int idMedico { get; set; }
        public string NombreLugar { get; set; }
        public string Direccion { get; set; }
        public string Imagen { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string NombreLugarId { get; set; }

        [ForeignKey("idMedico")]
        public virtual Medico medicos { get; set; }
    }
}
