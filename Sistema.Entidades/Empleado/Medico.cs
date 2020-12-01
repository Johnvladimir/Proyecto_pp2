using System.Collections.Generic;
using Sistema.Entidades.GeoPortal;
using Sistema.Entidades.Registro;

namespace Sistema.Entidades.Empleado
{
    public class Medico
    {
        public int idMedico { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Profesion { get; set; }

        public virtual ICollection<Expediente> Expedientes { get; set; }
        public virtual ICollection<Mapa> Mapas { get; set; }
    }
}
