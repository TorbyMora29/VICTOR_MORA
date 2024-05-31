using Microsoft.Extensions.DependencyInjection;
using ProyectoJwt.Aplicacion.Configuracion;
using ProyectoJwt.Aplicacion.Planificaciones;

namespace ProyectoJwt.Aplicacion
{
    public static class AplicacionServicios
    {
        public static IServiceCollection RegistrarServiciosAplicacion(this IServiceCollection servicios)
        {
            servicios.RegistarServiciosConfiguracion();
            servicios.RegistarServiciosPlanificaciones();

            return servicios;
        }
    }
}
