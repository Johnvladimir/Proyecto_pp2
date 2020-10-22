using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Empleado;

namespace Sistema.Datos.Mapping.Empleado
{
    public class MedicoMap : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medico").HasKey(c => c.idMedico);
        }
    }
}
