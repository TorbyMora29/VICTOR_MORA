using FluentValidation;
using ProyectoJwt.Dto.Planificaciones;
using ProyectoJwt.Infraestructura.Utilidades;

namespace ProyectoJwt.Aplicacion.Planificaciones.Validaciones
{
    public partial class ValidacionTarea
    {
        public class CompletarTarea : AbstractValidator<TareaDto.CompletarTarea>
        {
            public CompletarTarea()
            {
                RuleFor(u => u.Identificador).GreaterThan(0)
                    .WithMessage("El identificador debe ser mayor a cero");
            }
        }
    }
}
