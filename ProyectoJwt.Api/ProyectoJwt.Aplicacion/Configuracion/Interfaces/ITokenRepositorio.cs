using FluentResults;
using ProyectoJwt.Dto.Configuracion;

namespace ProyectoJwt.Aplicacion.Configuracion.Interfaces
{
    public interface ITokenRepositorio
    {
        Result<string> GenerarToken(UsuarioDto.RequestToken user);
        
        Result EsTokenValido(string token);
    }
}
