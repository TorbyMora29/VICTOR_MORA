using FluentResults;
using ProyectoJwt.Dto.Configuraciones.Login;

namespace ProyectoJwt.Servicios.Configuraciones.Interfaces
{
    public interface ILoginRepositorio
    {
        Task<LoginRespuesta> GenerarToken(LoginSolicitud loginSolicitud);
    }
}
