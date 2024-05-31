using FluentResults;
using ProyectoJwt.Dto.Configuraciones.Login;
using ProyectoJwt.Servicios.Configuraciones.Interfaces;
using ProyectoJwt.Servicios.Constantes.Configuraciones;
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

        public async Task<LoginRespuesta?> GenerarToken(LoginSolicitud loginSolicitud)
        {
            var respuesta = await _consumoApi.PostAsync<LoginSolicitud, LoginRespuesta>(UsuarioEndPoint.GenerarTokenUsuario, loginSolicitud);
            return respuesta;
        }
    }
}
