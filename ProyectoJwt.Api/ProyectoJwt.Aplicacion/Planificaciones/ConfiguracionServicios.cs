using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProyectoJwt.Aplicacion.Planificaciones.Implementacion;
using ProyectoJwt.Aplicacion.Planificaciones.Interfaces;
using ProyectoJwt.Aplicacion.Planificaciones.Validaciones;
using ProyectoJwt.Dto.Planificaciones;

namespace ProyectoJwt.Aplicacion.Planificaciones
{
    public static class ConfiguracionServicios
    {
        public static IServiceCollection RegistarServiciosPlanificaciones(this IServiceCollection servicios)
        {
            servicios.AddTransient<ITareaRepositorio, TareaRepositorio>();

            servicios.AddScoped<IValidator<TareaDto.Crear>, ValidacionTarea.Crear>();
            servicios.AddScoped<IValidator<TareaDto.Eliminar>, ValidacionTarea.Eliminar>();
            servicios.AddScoped<IValidator<TareaDto.Actualizar>, ValidacionTarea.Actualizar>();
            servicios.AddScoped<IValidator<TareaDto.CompletarTarea>, ValidacionTarea.CompletarTarea>();
            servicios.AddScoped<IValidator<TareaDto.Consultar>, ValidacionTarea.Consultar>();

            return servicios;
        }
    }
}
