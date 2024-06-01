using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProyectoJwt.Servicios.Configuraciones;
using ProyectoJwt.Servicios.Planificaciones;

namespace ProyectoJwt.Servicios
{
    public static class ConfiguracionServicios
    {
        public static IServiceCollection ConfigurarSevicios(this IServiceCollection servicios)
        {
            servicios.ServiciosConfiguracion();
            servicios.ServiciosPlanificaciones();
            servicios.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return servicios;
        }
    }
}
