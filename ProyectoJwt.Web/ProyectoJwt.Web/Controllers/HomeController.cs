using Microsoft.AspNetCore.Mvc;

namespace ProyectoJwt.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : BaseController
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Error")]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
