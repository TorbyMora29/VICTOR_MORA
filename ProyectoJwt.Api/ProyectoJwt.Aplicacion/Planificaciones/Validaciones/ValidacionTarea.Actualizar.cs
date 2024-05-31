using FluentValidation;
using ProyectoJwt.Dto.Planificaciones;
using ProyectoJwt.Infraestructura.Utilidades;

namespace ProyectoJwt.Aplicacion.Planificaciones.Validaciones
{
    public partial class ValidacionTarea
    {
        public class Actualizar : AbstractValidator<TareaDto.Actualizar>
        {
            public Actualizar()
            {
                RuleFor(u => u.Identificador).GreaterThan(0)
                    .WithMessage("El identificador debe ser mayor a cero");

                RuleFor(u => u.Titulo).NotEmpty()
                    .WithMessage("El título de la tarea es obligatorio");

                RuleFor(u => u.Descripcion).NotEmpty()
                    .WithMessage("La descripción de la tarea es obligatorio");

                RuleFor(u => u.FechaVencimiento).GreaterThanOrEqualTo(DateTime.Now)
                    .WithMessage($"La fecha de vencimiento de la tarea debe ser mayor o igual que {DateTime.Now.ToDateFormat()}");
            }
        }
    }
}
