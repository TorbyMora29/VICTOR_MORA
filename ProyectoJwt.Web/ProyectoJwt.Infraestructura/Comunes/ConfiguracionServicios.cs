using Microsoft.Extensions.DependencyInjection;
using ProyectoJwt.Infraestructura.Comunes.Implementaciones;
using ProyectoJwt.Infraestructura.Comunes.Interfaces;

namespace ProyectoJwt.Infraestructura.Comunes
{
    internal static class ConfiguracionServicios
    {
        public static IServiceCollection ServiciosConfiguracion(this IServiceCollection servicios)
        {
            servicios.AddTransient<IApiRepositorio, ApiRepositorio>();

            return servicios;
        }
    }
}
