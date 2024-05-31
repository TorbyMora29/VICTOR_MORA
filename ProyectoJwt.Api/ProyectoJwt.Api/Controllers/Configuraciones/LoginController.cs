using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoJwt.Aplicacion.Configuracion.Interfaces;
using ProyectoJwt.Dto.Configuracion;
using ProyectoJwt.Infraestructura.Utilidades;

namespace ProyectoJwt.Api.Controllers.Configuraciones
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuario;
        private readonly ITokenRepositorio _tokenRepositorio;

        public LoginController(
            IUsuarioRepositorio usuario,
            ITokenRepositorio tokenRepositorio)
        {
            _usuario = usuario;
            _tokenRepositorio = tokenRepositorio;
        }

        [HttpPost("/api/generar-token-usuario")]
        public IActionResult GenerarToken([FromBody] UsuarioDto.Sesion sesion)
        {
            try
            {
                // Aplicar fluent Validations
                var resultado = _usuario.VerificarSesionUsuario(sesion);
                if (resultado.IsFailed) return Problem(string.Join("\n", resultado.Errors));

                var solicitudToken = sesion.Mapear<UsuarioDto.RequestToken>();

                var respuestaToken = _tokenRepositorio.GenerarToken(solicitudToken);
                if (respuestaToken.IsFailed) return Problem(string.Join("\n", resultado.Errors));

                HttpContext.Session.SetString("Token", respuestaToken.Value);

                return Ok(new
                {
                    Login = resultado.Value.CodigoUsuario,
                    Usuario = resultado.Value.DescripcionUsuario,
                    Token = respuestaToken.Value,
                });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
