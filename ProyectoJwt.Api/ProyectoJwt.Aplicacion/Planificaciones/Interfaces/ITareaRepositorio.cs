using FluentResults;
using ProyectoJwt.Dto.Planificaciones;
using static ProyectoJwt.Dto.Planificaciones.TareaDto;

namespace ProyectoJwt.Aplicacion.Planificaciones.Interfaces
{
    public interface ITareaRepositorio
    {
        Result<TareaDto> ConsultarPorId(Consultar consultar);
        Result CrearTarea(Crear creacion);
        Result ActualizarTarea(Actualizar actualizacion);
        Result EliminarTarea(Eliminar eliminar);
        Result CompletarTarea(CompletarTarea completarTarea);
        Result<TareaDto[]> ConsultarTodos(ConsultarTodos completarTarea);
    }
}
