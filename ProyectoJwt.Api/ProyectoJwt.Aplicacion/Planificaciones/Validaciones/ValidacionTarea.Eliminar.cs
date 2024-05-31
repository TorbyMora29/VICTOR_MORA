﻿using FluentValidation;
using ProyectoJwt.Dto.Planificaciones;
using ProyectoJwt.Infraestructura.Utilidades;

namespace ProyectoJwt.Aplicacion.Planificaciones.Validaciones
{
    public partial class ValidacionTarea
    {
        public class Eliminar : AbstractValidator<TareaDto.Eliminar>
        {
            public Eliminar()
            {
                RuleFor(u => u.Identificador).GreaterThan(0)
                    .WithMessage("El identificador debe ser mayor a cero");
            }
        }
    }
}
