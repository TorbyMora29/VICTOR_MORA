using FluentValidation;
using ProyectoJwt.Dto.Planificaciones;

namespace ProyectoJwt.Aplicacion.Planificaciones.Validaciones
{
    public partial class ValidacionTarea
    {
        public class ConsultarTodos : AbstractValidator<TareaDto.ConsultarTodos>
        {
            public ConsultarTodos()
            {

            }
        }
    }
}
