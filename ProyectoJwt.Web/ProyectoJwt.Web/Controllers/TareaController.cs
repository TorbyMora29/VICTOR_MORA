using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoJwt.Web.Controllers
{
    public class TareaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Prueba")]
        public IActionResult Prueba()
        {
            return View("Index");
        }
    }
}
