using FluentResults;
using ProyectoJwt.Aplicacion.Planificaciones.Validaciones;
using ProyectoJwt.Dto.Planificaciones;

namespace ProyectoJwt.Api.Validaciones.Planifiicaciones
{
    public static class ValidadorTarea
    {
        public static Result ValidarEntrada(TareaDto.Crear request)
        {
            var resultado = new ValidacionTarea.Crear()
                .Validate(request);

            if (!resultado.IsValid)
            {
                return Result.Fail(resultado.Errors.Select(x => x.ErrorMessage));
            }

            return Result.Ok();
        }

        public static Result ValidarEntrada(TareaDto.Actualizar request)
        {
            var resultado = new ValidacionTarea.Actualizar()
                .Validate(request);

            if (!resultado.IsValid)
            {
                return Result.Fail(resultado.Errors.Select(x => x.ErrorMessage));
            }

            return Result.Ok();
        }

        public static Result ValidarEntrada(TareaDto.Consultar request)
        {
            var resultado = new ValidacionTarea.Consultar()
                .Validate(request);

            if (!resultado.IsValid)
            {
                return Result.Fail(resultado.Errors.Select(x => x.ErrorMessage));
            }

            return Result.Ok();
        }

        public static Result ValidarEntrada(TareaDto.CompletarTarea request)
        {
            var resultado = new ValidacionTarea.CompletarTarea()
                .Validate(request);

            if (!resultado.IsValid)
            {
                return Result.Fail(resultado.Errors.Select(x => x.ErrorMessage));
            }

            return Result.Ok();
        }

        public static Result ValidarEntrada(TareaDto.Eliminar request)
        {
            var resultado = new ValidacionTarea.Eliminar()
                .Validate(request);

            if (!resultado.IsValid)
            {
                return Result.Fail(resultado.Errors.Select(x => x.ErrorMessage));
            }

            return Result.Ok();
        }

        public static Result ValidarEntrada(TareaDto.ConsultarTodos request)
        {
            var resultado = new ValidacionTarea.ConsultarTodos()
                .Validate(request);

            if (!resultado.IsValid)
            {
                return Result.Fail(resultado.Errors.Select(x => x.ErrorMessage));
            }

            return Result.Ok();
        }
    }
}
