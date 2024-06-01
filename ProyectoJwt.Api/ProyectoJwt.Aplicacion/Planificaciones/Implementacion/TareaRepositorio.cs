using FluentResults;
using ProyectoJwt.Aplicacion.Planificaciones.Interfaces;
using ProyectoJwt.Dto.Planificaciones;
using ProyectoJwt.Entidades.Planificaciones;
using ProyectoJwt.Infraestructura.Utilidades;
using ProyectoJwt.Persistencia;
using static ProyectoJwt.Dto.Planificaciones.TareaDto;

namespace ProyectoJwt.Aplicacion.Planificaciones.Implementacion
{
    internal class TareaRepositorio : ITareaRepositorio
    {
        private readonly ProyectoJwtDbContext _context;

        public TareaRepositorio(ProyectoJwtDbContext context)
        {
            _context = context;
        }

        public Result ActualizarTarea(Actualizar actualizacion)
        {
            try
            {
                var tarea = _context.Tareas
                    .FirstOrDefault(e => e.Identificador == actualizacion.Identificador);

                if (tarea is null) return Result.Fail("La tarea no existe");
                if (!tarea.Activo) return Result.Fail("La tarea no está activa");

                using var transaccion = _context.Database.BeginTransaction();

                // Asignamos los valores a actualizar
                tarea.Titulo = actualizacion.Titulo;
                tarea.Descripcion = actualizacion.Descripcion;
                tarea.FechaVencimiento = actualizacion.FechaVencimiento;

                _context.Tareas.Update(tarea);
                _context.SaveChanges();

                transaccion.Commit();
            }
            catch (Exception)
            {
                return Result.Fail("Error al actualizar la tarea");
            }

            return Result.Ok();
        }

        public Result CompletarTarea(CompletarTarea completarTarea)
        {
            try
            {
                var tarea = _context.Tareas
                    .FirstOrDefault(e => e.Identificador == completarTarea.Identificador);

                if (tarea is null) return Result.Fail("La tarea no existe");
                if (!tarea.Activo) return Result.Fail("La tarea no está activa");
                if (tarea.EsCompletada) return Result.Fail("La tarea ya está completada");

                // Empezamos la transaccion
                using var transaccion = _context.Database.BeginTransaction();

                // Asignamos los valores a actualizar
                tarea.EsCompletada = true;

                _context.Tareas.Update(tarea);
                _context.SaveChanges();

                transaccion.Commit();
            }
            catch (Exception)
            {
                return Result.Fail("Error al completar la tarea");
            }

            return Result.Ok();
        }

        public Result<TareaDto> ConsultarPorId(Consultar consultar)
        {
            try
            {
                var tarea = _context.Tareas
                    .FirstOrDefault(e => e.Identificador == consultar.Identificador && e.Activo);

                if (tarea is null) return Result.Fail("La tarea no existe");

                return Result.Ok(tarea.Mapear<TareaDto>());

            }
            catch (Exception)
            {
                return Result.Fail("Error al consultar la tarea");
            }
        }

        public Result<TareaDto[]> ConsultarTodos(ConsultarTodos completarTarea)
        {
            try
            {
                var tareas = _context.Tareas
                    .Where(e => e.Activo)
                    .ToArray();

                if (!string.IsNullOrEmpty(completarTarea.TituloContiene))
                {
                    tareas = tareas.Where(e => e.Titulo.Contains(completarTarea.TituloContiene)).ToArray();
                }

                return Result.Ok(tareas.Mapear<TareaDto[]>());

            }
            catch (Exception)
            {
                return Result.Fail("Error al consultar la tarea");
            }
        }

        public Result CrearTarea(Crear creacion)
        {
            try
            {                
                using var transaccion = _context.Database.BeginTransaction();

                // Creamos la nueva tarea
                var tarea = creacion.Mapear<Tarea>();
                tarea.Activo = true;

                _context.Tareas.Add(tarea);
                _context.SaveChanges();

                transaccion.Commit();
            }
            catch (Exception)
            {
                return Result.Fail("Error al crear la tarea");
            }

            return Result.Ok();
        }

        public Result EliminarTarea(Eliminar eliminar)
        {
            try
            {
                var tarea = _context.Tareas
                    .FirstOrDefault(e => e.Identificador == eliminar.Identificador);

                if (tarea is null) return Result.Fail("La tarea no existe");
                if (!tarea.Activo) return Result.Fail("La tarea no está activa");

                // Empezamos la transaccion
                using var transaccion = _context.Database.BeginTransaction();

                tarea.Activo = false;
                _context.Tareas.Update(tarea);
                _context.SaveChanges();

                transaccion.Commit();
            }
            catch (Exception)
            {
                return Result.Fail("Error al eliminar la tarea");
            }

            return Result.Ok();
        }
    }
}
