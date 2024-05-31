using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoJwt.Entidades.Comunes;
using ProyectoJwt.Entidades.Configuraciones;
using ProyectoJwt.Entidades.Planificaciones;
using ProyectoJwt.Persistencia.Comunes;
using ProyectoJwt.Persistencia.MapeoEntidades.Configuraciones;
using ProyectoJwt.Persistencia.MapeoEntidades.Planificaciones;

namespace ProyectoJwt.Persistencia
{
    public class ProyectoJwtDbContext : DbContext
    {
        public ProyectoJwtDbContext(
            DbContextOptions<ProyectoJwtDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<SeguridadUsuario> SeguridadUsuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(ConstantesPersistencia.m_DefaultSchema);

            ModelConfig(modelBuilder);
        }

        private static void ModelConfig(ModelBuilder modelBuilder)
        {
            _ = new MapeoUsuario(modelBuilder.Entity<Usuario>());
            _ = new MapeoSeguridadUsuario(modelBuilder.Entity<SeguridadUsuario>());
            _ = new MapeoTarea(modelBuilder.Entity<Tarea>());
        }

        #region Sobreescritura de métodos

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<Auditoria>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.UsuarioCreacion = string.Empty;
                        entry.Entity.FechaCreacion = DateTime.Now;
                        entry.Entity.UsuarioModificacion = string.Empty;
                        entry.Entity.FechaModificacion = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UsuarioModificacion = string.Empty;
                        entry.Entity.FechaModificacion = DateTime.Now;
                        break;
                }
            }

            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Auditoria>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.UsuarioCreacion = string.Empty;
                        entry.Entity.FechaCreacion = DateTime.Now;
                        entry.Entity.UsuarioModificacion = string.Empty;
                        entry.Entity.FechaModificacion = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UsuarioModificacion = string.Empty;
                        entry.Entity.FechaModificacion = DateTime.Now;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        #endregion
    }
}
