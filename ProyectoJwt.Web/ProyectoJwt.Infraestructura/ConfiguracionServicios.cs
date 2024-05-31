using Microsoft.Extensions.DependencyInjection;
using ProyectoJwt.Infraestructura.Comunes;

namespace ProyectoJwt.Infraestructura
{
    public static class ConfiguracionServicios
    {
        public static IServiceCollection ConfigurarSevicios(this IServiceCollection servicios)
        {
            servicios.ServiciosConfiguracion();

            return servicios;
        }
    }
}
