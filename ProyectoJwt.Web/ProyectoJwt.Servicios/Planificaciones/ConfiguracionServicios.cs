using Microsoft.Extensions.DependencyInjection;
using ProyectoJwt.Servicios.Planificaciones.Implementaciones;
using ProyectoJwt.Servicios.Planificaciones.Interfaces;

namespace ProyectoJwt.Servicios.Planificaciones
{
    internal static class ConfiguracionServicios
    {
        public static IServiceCollection ServiciosPlanificaciones(this IServiceCollection servicios)
        {
            servicios.AddTransient<ITareaRepositorio, TareaRepositorio>();

            return servicios;
        }
    }
}
