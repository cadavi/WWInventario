using WWInventario.Models;
using Microsoft.EntityFrameworkCore;

namespace WWInventario.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<Compania> Companias { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<EstadoEquipo> EstadoEquipos { get; set; }
        public DbSet<FallaEquipo> FallaEquipos { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }

    }
}
