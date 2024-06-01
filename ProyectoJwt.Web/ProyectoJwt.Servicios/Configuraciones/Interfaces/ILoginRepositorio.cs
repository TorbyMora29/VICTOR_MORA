using FluentResults;
using ProyectoJwt.Dto.Configuraciones.Login;

namespace ProyectoJwt.Servicios.Configuraciones.Interfaces
{
    public interface ILoginRepositorio
    {
        Task<Result<LoginRespuestaDto?>> GenerarToken(LoginSolicitudDto loginSolicitud);
        Task<Result> CrearUsuario(CrearUsuarioSolicitudDto loginSolicitud);
    }
}
