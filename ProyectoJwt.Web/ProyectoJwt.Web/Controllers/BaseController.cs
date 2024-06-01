using Microsoft.AspNetCore.Mvc;

namespace ProyectoJwt.Web.Controllers
{
    public class BaseController : Controller
    {
        public string RecuperarTokenSesion()
        {
            var tokenJwt = HttpContext.Session.GetString("Token");
            HttpContext.Session.SetString("Token", tokenJwt!);

            return tokenJwt ?? string.Empty;
        }
    }
}
