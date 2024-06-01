using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoJwt.Dto.Planificaciones.Tarea;
using ProyectoJwt.Servicios.Planificaciones.Interfaces;
using ProyectoJwt.Web.Constantes;
using ProyectoJwt.Web.Utilidades;
using ProyectoJwt.Web.ViewModel.Planificaciones.Tarea;

namespace ProyectoJwt.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TareaController : BaseController
    {
        private readonly ITareaRepositorio _tarea;

        public TareaController(ITareaRepositorio tarea)
        {
            _tarea = tarea;
        }


        [Authorize]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost("GenerarNuevo")]
        public IActionResult GenerarNuevo()
        {
            var modelo = new TareaVm() { FechaVencimiento = DateTime.Today.AddDays(1) };
            this.ViewBag.Tipo = ModoVista.m_tipoCreacion;
            return PartialView("TareaEdicion", modelo);
        }

        [Authorize]
        [HttpPost("ConsultarPorId")]
        public async Task<IActionResult> ConsultarPorId([FromBody] TareaConsultarIdVm consultar)
        {
            TareaVm tareas;
            try
            {
                var solicitud = consultar.Mapear<TareaConsultarPorIdSolicitudDto>();
                var respuesta = await _tarea.ConsultarPorId(solicitud, RecuperarTokenSesion());

                if (respuesta.IsFailed) RedirectToAction("Error", "Home");

                tareas = respuesta.Value.Mapear<TareaVm>();
            }
            catch (Exception)
            {
                tareas = new();
                RedirectToAction("Error", "Home");
            }

            this.ViewBag.Tipo = ModoVista.m_tipoEdicion;
            return PartialView("TareaEdicion", tareas);
        }

        [Authorize]
        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] TareaCrearVm crear)
        {
            Result result;
            try
            {
                var solicitud = crear.Mapear<TareaCrearSolicitudDto>();
                var respuesta = await _tarea.Crear(solicitud, RecuperarTokenSesion());

                if (respuesta.IsFailed) RedirectToAction("Error", "Home");

                result = respuesta;
            }
            catch (Exception)
            {
                result = Result.Fail("");
                RedirectToAction("Error", "Home");
            }

            return Json(result);
        }

        [Authorize]
        [HttpPost("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] TareaActualizarVm actualizar)
        {
            Result result;
            try
            {
                var solicitud = actualizar.Mapear<TareaActualizarSolicitudDto>();
                var respuesta = await _tarea.Actualizar(solicitud, RecuperarTokenSesion());

                if (respuesta.IsFailed) RedirectToAction("Error", "Home");

                result = respuesta;
            }
            catch (Exception)
            {
                result = Result.Fail("");
                RedirectToAction("Error", "Home");
            }

            return Json(result);
        }

        [Authorize]
        [HttpPost("Eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] TareaEliminarVm eliminar)
        {
            Result result;
            try
            {
                var solicitud = eliminar.Mapear<TareaEliminarSolicitudDto>();
                var respuesta = await _tarea.Eliminar(solicitud, RecuperarTokenSesion());

                if (respuesta.IsFailed) RedirectToAction("Error", "Home");

                result = respuesta;
            }
            catch (Exception)
            {
                result = Result.Fail("");
                RedirectToAction("Error", "Home");
            }

            return Json(result);
        }

        [Authorize]
        [HttpPost("Completar")]
        public async Task<IActionResult> Completar([FromBody] TareaCompletarVm completar)
        {
            Result result;
            try
            {
                var solicitud = completar.Mapear<TareaCompletarSolicitudDto>();
                var respuesta = await _tarea.Completar(solicitud, RecuperarTokenSesion());

                if (respuesta.IsFailed) RedirectToAction("Error", "Home");

                result = respuesta;
            }
            catch (Exception)
            {
                result = Result.Fail("");
                RedirectToAction("Error", "Home");
            }

            return Json(result);
        }

        [Authorize]
        [HttpPost("ConsultarTodos")]
        public async Task<IActionResult> ConsultarTodos([FromBody] TareaConsultarTodosVm consultar)
        {
            TareaVm[] tareas;
            try
            {
                var solicitud = consultar.Mapear<TareaConsultarTodoSolicitudDto>();
                var respuesta = await _tarea.ConsultarTodo(solicitud, RecuperarTokenSesion());

                if (respuesta.IsFailed) RedirectToAction("Error", "Home");

                tareas = respuesta.Value.Mapear<TareaVm[]>();
            }
            catch (Exception)
            {
                tareas = [];
                RedirectToAction("Error", "Home");
            }

            return PartialView("TareaConsultaResultado", tareas);
        }

        [Authorize]
        [HttpPost("FiltrarDocumentos")]
        public IActionResult FiltrarDocumentos()
        {
            return PartialView("TareaConsultaFiltro");
        }
    }
}
