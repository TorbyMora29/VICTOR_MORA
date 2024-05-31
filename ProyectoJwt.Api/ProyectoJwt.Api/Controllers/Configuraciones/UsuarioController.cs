using FluentResults;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoJwt.Aplicacion.Configuracion.Interfaces;
using ProyectoJwt.Dto.Configuracion;

namespace ProyectoJwt.Api.Controllers.Configuraciones
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuario;
        public UsuarioController(IUsuarioRepositorio usuario)
        {
            _usuario = usuario;
        }

        [HttpPost("/api/crear-usuario")]
        public IActionResult CrearUsuario([FromBody] UsuarioDto.Creacion creacion)
        {
            try
            {
                // Aplicar fluent Validations

                var result = _usuario.CrearUsuario(creacion);

                return result.IsSuccess
                    ? Ok("Usuario Creado Exitosamente")
                    : Problem(string.Join("\n", result.Errors));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }        
    }
}
