using Microsoft.Extensions.DependencyInjection;
using ProyectoJwt.Servicios.Configuraciones.Implementaciones;
using ProyectoJwt.Servicios.Configuraciones.Interfaces;

namespace ProyectoJwt.Servicios.Configuraciones
{
    internal static class ConfiguracionServicios
    {
        public static IServiceCollection ServiciosConfiguracion(this IServiceCollection servicios)
        {
            servicios.AddTransient<ILoginRepositorio, LoginRepositorio>();

            return servicios;
        }
    }
}
