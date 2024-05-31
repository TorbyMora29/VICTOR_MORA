using Microsoft.Extensions.DependencyInjection;
using ProyectoJwt.Aplicacion.Configuracion.Implementacion;
using ProyectoJwt.Aplicacion.Configuracion.Interfaces;

namespace ProyectoJwt.Aplicacion.Configuracion
{
    internal static class ConfiguracionServicios
    {
        public static IServiceCollection RegistarServiciosConfiguracion(this IServiceCollection servicios)
        {
            servicios.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            servicios.AddTransient<ITokenRepositorio, TokenRepositorio>();

            return servicios;
        }
    }
}
