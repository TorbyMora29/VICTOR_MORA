using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoJwt.Entidades.Planificaciones;

namespace ProyectoJwt.Persistencia.MapeoEntidades.Planificaciones
{
    public class MapeoTarea
    {
        public MapeoTarea(EntityTypeBuilder<Tarea> builder)
        {
            builder.ToTable("Plan_Tarea");

            builder.HasKey(x => x.Identificador);

            builder.Property(x => x.Titulo)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Descripcion)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.FechaVencimiento)
                .IsRequired();

            builder.Property(x => x.EsCompletada)
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
        }
    }
}
