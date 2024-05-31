using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoJwt.Entidades.Configuraciones;

namespace ProyectoJwt.Persistencia.MapeoEntidades.Configuraciones
{
    public class MapeoSeguridadUsuario
    {
        public MapeoSeguridadUsuario(EntityTypeBuilder<SeguridadUsuario> builder)
        {
            builder.ToTable("Conf_SeguridadUsuario");

            builder.HasKey(x => x.Identificador);

            builder.Property(x => x.IdentidicadorUsuario)
                .IsRequired();

            builder.Property(x => x.ContraseñaUsuario)
                .HasMaxLength(1500)
                .IsRequired();

            builder.Property(x => x.ExpiracionContraseña)
                .IsRequired();

            builder.Property(x => x.UsuarioCreacion)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.FechaCreacion)
                .IsRequired();

            builder.Property(x => x.UsuarioModificacion)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.FechaModificacion)
                .IsRequired();

        }        
    }
}
