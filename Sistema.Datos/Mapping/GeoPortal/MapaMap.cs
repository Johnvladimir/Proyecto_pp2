using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.GeoPortal;

namespace Sistema.Datos.Mapping.GeoPortal
{
    public class MapaMap : IEntityTypeConfiguration<Mapa>
    {
        public void Configure(EntityTypeBuilder<Mapa> builder)
        {
            builder.ToTable("Mapa").HasKey(c => c.idMapa);
        }
    }
}
