using FluentResults;
using ProyectoJwt.Dto.Configuracion;

namespace ProyectoJwt.Aplicacion.Configuracion.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Result CrearUsuario(UsuarioDto.Creacion creacion);
        Result ActualizarUsuario();
        Result ActualizarContraseña();
        Result<UsuarioDto> VerificarSesionUsuario(UsuarioDto.Sesion sesion);
    }
}
