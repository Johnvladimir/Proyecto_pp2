using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios;
using System;

namespace Sistema.Datos.Mapping.Usuarios
{
    public class RolMap : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol").HasKey(c => c.idRol);
        }
    }
}
