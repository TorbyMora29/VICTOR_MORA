using Microsoft.Extensions.DependencyInjection;
using ProyectoJwt.Servicios.Configuraciones;

namespace ProyectoJwt.Servicios
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
