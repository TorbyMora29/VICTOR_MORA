using FluentValidation;
using ProyectoJwt.Dto.Planificaciones;
using ProyectoJwt.Infraestructura.Utilidades;

namespace ProyectoJwt.Aplicacion.Planificaciones.Validaciones
{
    public partial class ValidacionTarea
    {
        public class Crear : AbstractValidator<TareaDto.Crear>
        {
            public Crear()
            {
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
