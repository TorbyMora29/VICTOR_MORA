using FluentResults;
using ProyectoJwt.Dto.Planificaciones.Tarea;
using ProyectoJwt.Servicios.Planificaciones.Constantes;
using ProyectoJwt.Servicios.Planificaciones.Interfaces;
using ProyectoJwt.Servicios.Servicios;

namespace ProyectoJwt.Servicios.Planificaciones.Implementaciones
{
    internal class TareaRepositorio : ITareaRepositorio
    {
        private readonly ClienteConsumoApi _consumoApi;

        public TareaRepositorio(ClienteConsumoApi consumoApi)
        {
            _consumoApi = consumoApi;
        }

        public async Task<Result> Actualizar(TareaActualizarSolicitudDto solicitud, string jwtToken)
        {
            var respuesta = await _consumoApi.PostAsync<TareaActualizarSolicitudDto, Result>(TareaEndPoint.Actualizar, solicitud, jwtToken);
            return respuesta.Value;
        }

        public async Task<Result> Completar(TareaCompletarSolicitudDto solicitud, string jwtToken)
        {
            var respuesta = await _consumoApi.PostAsync<TareaCompletarSolicitudDto, Result>(TareaEndPoint.Completar, solicitud, jwtToken);
            return respuesta.Value;
        }

        public async Task<Result<TareaRespuestaDto>> ConsultarPorId(TareaConsultarPorIdSolicitudDto solicitud, string jwtToken)
        {
            var respuesta = await _consumoApi.PostAsync<TareaConsultarPorIdSolicitudDto, TareaRespuestaDto>(TareaEndPoint.ConsultarPorId, solicitud, jwtToken);
            return respuesta;
        }

        public async Task<Result<TareaRespuestaDto[]>> ConsultarTodo(TareaConsultarTodoSolicitudDto solicitud, string jwtToken)
        {
            var respuesta = await _consumoApi.PostAsync<TareaConsultarTodoSolicitudDto, TareaRespuestaDto[]>(TareaEndPoint.ConsultarTodas, solicitud, jwtToken);
            return respuesta;
        }

        public async Task<Result> Crear(TareaCrearSolicitudDto solicitud, string jwtToken)
        {
            var respuesta = await _consumoApi.PostAsync<TareaCrearSolicitudDto, Result>(TareaEndPoint.Crear, solicitud, jwtToken);
            return respuesta.Value;
        }

        public async Task<Result> Eliminar(TareaEliminarSolicitudDto solicitud, string jwtToken)
        {
            var respuesta = await _consumoApi.PostAsync<TareaEliminarSolicitudDto, Result>(TareaEndPoint.Eliminar, solicitud, jwtToken);
            return respuesta.Value;
        }
    }
}
