using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoJwt.Api.Validaciones.Planifiicaciones;
using ProyectoJwt.Aplicacion.Planificaciones.Interfaces;
using ProyectoJwt.Dto.Planificaciones;

namespace ProyectoJwt.Api.Controllers.Planificaciones
{
    public class TareaController : Controller
    {
        private readonly ITareaRepositorio _tarea;

        public TareaController(ITareaRepositorio tarea)
        {
            _tarea = tarea;
        }

        [Authorize]
        [HttpPost("/api/consultar-tarea-id")]
        public IActionResult ConsultarPorId([FromBody] TareaDto.Consultar consultar)
        {
            try
            {
                // Aplicar Fluent Validator
                var validarEntrada = ValidadorTarea.ValidarEntrada(consultar);
                if (validarEntrada.IsFailed) return BadRequest(string.Join("\n", validarEntrada.Errors));

                // Envio de la solicitud
                var respuesta = _tarea.ConsultarPorId(consultar);

                return respuesta.IsSuccess
                    ? Ok(respuesta.Value)
                    : Problem(string.Join("\n", respuesta.Errors));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("/api/crear-tarea")]
        public IActionResult CrearTarea([FromBody] TareaDto.Crear crear)
        {
            try
            {
                //Aplicar Fluent Validator
                var validarEntrada = ValidadorTarea.ValidarEntrada(crear);
                if (validarEntrada.IsFailed) return BadRequest(string.Join("\n", validarEntrada.Errors));

                // Envio de la solicitud
                var respuesta = _tarea.CrearTarea(crear);

                return respuesta.IsSuccess
                    ? Ok("Tarea creada exitosamente")
                    : Problem(string.Join("\n", respuesta.Errors));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("/api/actualizar-tarea")]
        public IActionResult ActualizarTarea([FromBody] TareaDto.Actualizar actualizacion)
        {
            try
            {
                //Aplicar Fluent Validator
                var validarEntrada = ValidadorTarea.ValidarEntrada(actualizacion);
                if (validarEntrada.IsFailed) return BadRequest(string.Join("\n", validarEntrada.Errors));

                // Envio de solicitud
                var respuesta = _tarea.ActualizarTarea(actualizacion);

                return respuesta.IsSuccess
                    ? Ok("Tarea actualizada exitosamente")
                    : Problem(string.Join("\n", respuesta.Errors));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("/api/eliminar-tarea")]
        public IActionResult EliminarTarea([FromBody] TareaDto.Eliminar eliminar)
        {
            try
            {
                //Aplicar Fluent Validator
                var validarEntrada = ValidadorTarea.ValidarEntrada(eliminar);
                if (validarEntrada.IsFailed) return BadRequest(string.Join("\n", validarEntrada.Errors));

                // Envio de solicitud
                var respuesta = _tarea.EliminarTarea(eliminar);

                return respuesta.IsSuccess
                    ? Ok("Tarea eliminada exitosamente")
                    : Problem(string.Join("\n", respuesta.Errors));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("/api/completar-tarea")]
        public IActionResult CompletarTarea([FromBody] TareaDto.CompletarTarea completar)
        {
            try
            {
                //Aplicar Fluent Validator
                var validarEntrada = ValidadorTarea.ValidarEntrada(completar);
                if (validarEntrada.IsFailed) return BadRequest(string.Join("\n", validarEntrada.Errors));

                // Envio de solicitud
                var respuesta = _tarea.CompletarTarea(completar);

                return respuesta.IsSuccess
                    ? Ok("Tarea completada exitosamente")
                    : Problem(string.Join("\n", respuesta.Errors));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}