using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoJwt.Entidades.Configuraciones;
using System.Reflection.Emit;

namespace ProyectoJwt.Persistencia.MapeoEntidades.Configuraciones
{
    public class MapeoUsuario
    {
        public MapeoUsuario(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Conf_Usuario");

            builder.HasKey(x => x.Identificador);

            builder.Property(x => x.CodigoUsuario)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.DescripcionUsuario)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.RequiereActualizacionContraseña)
                .IsRequired();

            builder.Property(x => x.Activo)
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

            builder.HasOne(u => u.SeguridadUsuario)
                .WithOne(up => up.Usuario)
                .HasForeignKey<SeguridadUsuario>(up => up.IdentidicadorUsuario);
        }        
    }
}
