using Microsoft.EntityFrameworkCore;
using Sistema.Datos.Mapping.Empleado;
using Sistema.Datos.Mapping.Registro;
using Sistema.Datos.Mapping.Usuarios;
using Sistema.Entidades.Empleado;
using Sistema.Entidades.Registro;
using Sistema.Entidades.Usuarios;

namespace Sistema.Datos
{
    public class DbContextSistema : DbContext
    {
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Rols { get; set; }

        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MedicoMap());
            modelBuilder.ApplyConfiguration(new ExpedienteMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new RolMap());
        }
    }
}
