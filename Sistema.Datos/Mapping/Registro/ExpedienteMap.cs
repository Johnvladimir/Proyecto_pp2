using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Registro;

namespace Sistema.Datos.Mapping.Registro
{
    public class ExpedienteMap : IEntityTypeConfiguration<Expediente>
    {
        public void Configure(EntityTypeBuilder<Expediente> builder)
        {
            builder.ToTable("Expediente").HasKey(c => c.idExpediente);
        }
    }
}