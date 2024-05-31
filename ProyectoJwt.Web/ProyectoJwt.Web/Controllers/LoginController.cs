using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProyectoJwt.Dto.Configuraciones.Login;
using ProyectoJwt.Servicios.Configuraciones.Interfaces;
using ProyectoJwt.Web.Utilidades;
using ProyectoJwt.Web.ViewModel.Configuraciones;
using System.Security.Claims;

namespace ProyectoJwt.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginRepositorio _login;

        public LoginController(ILoginRepositorio login)
        {
            _login = login;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion([FromForm] LoginVm login)
        {
            try
            {
                var solicitud = login.Mapear<LoginSolicitud>();
                var respuestaToken = await _login.GenerarToken(solicitud);

                if (respuestaToken is null)
                {
                    TempData["Error"] = "Usuario y/o Credenciales incorrectas";
                    Redirect("Index");
                };

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, respuestaToken.Usuario),
                    new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);


                await HttpContext.SignInAsync(principal);

                HttpContext.Session.SetString("Token", respuestaToken.Token);
            }
            catch (Exception)
            {
                return View("");
            }

            return RedirectToAction("Prueba", "Tarea");
        }
        public IActionResult CerrarSesion()
        {
            return View();
        }
    }
}
