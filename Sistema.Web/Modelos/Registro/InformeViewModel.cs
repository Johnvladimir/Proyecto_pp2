using System;

namespace Sistema.Web.Modelos.Registro
{
    public class InformeViewModel
    {
        public string Nombre { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Nombre_Medico { get; set; }
        public Nullable<DateTime> Fecha { get; set; }
        public string Detalles_Estudios { get; set; }
        public string Detalles_Examenes { get; set; }
        public string Recetas { get; set; }
        public string Costo_Cita { get; set; }
    }
}
