using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Modelos.GeoPortal
{
    public class MapaViewModel
    {
        public int idMapa { get; set; }
        public int idMedico { get; set; }
        public string NombreLugar { get; set; }
        public string Direccion { get; set; }
        public string Imagen { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string NombreLugarId { get; set; }
    }
}
