using System;
using Sistema.Entidades.Usuarios;
using Sistema.Entidades.Empleado;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades.Registro
{
    public class Expediente
    {
        public int idExpediente { get; set; }
        public int idUsuario { get; set; }
        public int idMedico { get; set; }
        public string Nombre { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Nombre_Medico { get; set; }
        public DateTime fecha { get; set; }
        public string Detalles_Estudios { get; set; }
        public string Detalles_Examenes { get; set; }
        public string Recetas { get; set; }
        public string Costo_Cita { get; set; }

        [ForeignKey("idUsuario")]
        public virtual Usuario usuarios { get; set; }
        [ForeignKey("idMedico")]
        public virtual Medico medicos { get; set; }
    }
}
