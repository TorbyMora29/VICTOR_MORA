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
    public class LoginController : BaseController
    {
        private readonly ILoginRepositorio _login;

        public LoginController(ILoginRepositorio login)
        {
            _login = login;
        }

        [HttpGet("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion([FromForm] LoginVm login)
        {
            try
            {
                var solicitud = login.Mapear<LoginSolicitudDto>();
                var respuestaToken = await _login.GenerarToken(solicitud);

                if (respuestaToken.IsFailed)
                {
                    TempData["Error"] = "Usuario y/o Credenciales incorrectas";
                    return RedirectToPage("/Index");
                }

                var tokenGenerado = respuestaToken.Value!;
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, tokenGenerado.Usuario),
                    new(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);


                await HttpContext.SignInAsync(principal);

                HttpContext.Session.SetString("Token", tokenGenerado.Token);
            }
            catch (Exception)
            {
                RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpGet("CerrarSesion")]
        public async Task<IActionResult> CerrarSesion()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync();
            return RedirectToPage("/Index");
        }


        [HttpPost("CrearUsuario")]
        public async Task<IActionResult> CrearUsuario([FromForm] CrearUsuarioVm crearUsuario)
        {
            try
            {
                var solicitud = crearUsuario.Mapear<CrearUsuarioSolicitudDto>();
                var respuestaToken = await _login.CrearUsuario(solicitud);

                if (respuestaToken.IsFailed)
                {
                    TempData["Error"] = "Error al crear usuario: " + string.Join("\n", respuestaToken.Errors);
                    return RedirectToPage("/Index");
                }
            }
            catch (Exception)
            {
                RedirectToAction("Error", "Home");
            }

            return RedirectToPage("/Index");
        }
    }
}
