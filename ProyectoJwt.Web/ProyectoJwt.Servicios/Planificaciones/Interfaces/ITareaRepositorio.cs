using FluentResults;
using ProyectoJwt.Dto.Planificaciones.Tarea;

namespace ProyectoJwt.Servicios.Planificaciones.Interfaces
{
    public interface ITareaRepositorio
    {
        Task<Result<TareaRespuestaDto>> ConsultarPorId(TareaConsultarPorIdSolicitudDto solicitud, string jwtToken);
        Task<Result> Crear(TareaCrearSolicitudDto solicitud, string jwtToken);
        Task<Result> Actualizar(TareaActualizarSolicitudDto solicitud, string jwtToken);
        Task<Result> Eliminar(TareaEliminarSolicitudDto solicitud, string jwtToken);
        Task<Result> Completar(TareaCompletarSolicitudDto solicitud, string jwtToken);
        Task<Result<TareaRespuestaDto[]>> ConsultarTodo(TareaConsultarTodoSolicitudDto solicitud, string jwtToken);
    }
}
