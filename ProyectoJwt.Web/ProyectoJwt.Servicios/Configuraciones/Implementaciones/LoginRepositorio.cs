using FluentResults;
using ProyectoJwt.Dto.Configuraciones.Login;
using ProyectoJwt.Servicios.Configuraciones.Constantes;
using ProyectoJwt.Servicios.Configuraciones.Interfaces;
using ProyectoJwt.Servicios.Servicios;

namespace ProyectoJwt.Servicios.Configuraciones.Implementaciones
{
    internal class LoginRepositorio : ILoginRepositorio
    {
        private readonly ClienteConsumoApi _consumoApi;

        public LoginRepositorio(ClienteConsumoApi consumoApi)
        {
            _consumoApi = consumoApi;
        }

        public async Task<Result> CrearUsuario(CrearUsuarioSolicitudDto loginSolicitud)
        {
            var respuesta = await _consumoApi.PostAsync<CrearUsuarioSolicitudDto, Result>(UsuarioEndPoint.CrearUsuario, loginSolicitud);
            return respuesta.Value;
        }

        public async Task<Result<LoginRespuestaDto?>> GenerarToken(LoginSolicitudDto loginSolicitud)
        {
            var respuesta = await _consumoApi.PostAsync<LoginSolicitudDto, LoginRespuestaDto>(UsuarioEndPoint.GenerarTokenUsuario, loginSolicitud);
            return respuesta;
        }
    }
}
