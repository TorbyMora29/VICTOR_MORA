using FluentResults;
using Microsoft.EntityFrameworkCore;
using ProyectoJwt.Aplicacion.Configuracion.Interfaces;
using ProyectoJwt.Dto.Configuracion;
using ProyectoJwt.Entidades.Configuraciones;
using ProyectoJwt.Infraestructura.Utilidades;
using ProyectoJwt.Persistencia;

namespace ProyectoJwt.Aplicacion.Configuracion.Implementacion
{
    internal class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ProyectoJwtDbContext _context;
        private const int m_numMesesExpiracionClave = 2;

        public UsuarioRepositorio(ProyectoJwtDbContext context)
        {
            _context = context;
        }

        public Result ActualizarContraseña()
        {
            throw new NotImplementedException();
        }

        public Result ActualizarUsuario()
        {
            throw new NotImplementedException();
        }

        public Result CrearUsuario(UsuarioDto.Creacion creacion)
        {
            try
            {
                // Verificamos si existe un usuario
                var usuarioExistente = _context.Usuarios
                    .FirstOrDefault(e => e.CodigoUsuario == creacion.CodigoUsuario);
                if (usuarioExistente is not null) return Result.Fail("Ya existe un usuario con ese codigo");

                // Procedemos con el registro
                using var scope = _context.Database.BeginTransaction();

                // Creamos el usuario
                var usuario = new Usuario()
                {
                    CodigoUsuario = creacion.CodigoUsuario,
                    DescripcionUsuario = creacion.DescripcionUsuario,
                    RequiereActualizacionContraseña = false,
                    Activo = true,
                };

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                var seguridadUsuario = new SeguridadUsuario()
                {
                    IdentidicadorUsuario = usuario.Identificador,
                    //ContraseñaUsuario = EncriptadorUtil.Encriptar(creacion.ContraseñaUsuario),
                    ContraseñaUsuario = creacion.ContraseñaUsuario,
                    ExpiracionContraseña = DateTime.Now.AddMonths(m_numMesesExpiracionClave), // La contraseña tiene una vigencia de 2 meses
                };

                _context.SeguridadUsuarios.Add(seguridadUsuario);
                _context.SaveChanges();

                scope.Commit();
            }
            catch (Exception)
            {
                return Result.Fail("Error innesperado, comuniquese con su administrador de sistemas.");
            }

            return Result.Ok();
        }

        public Result<UsuarioDto> VerificarSesionUsuario(UsuarioDto.Sesion sesion)
        {
            try
            {
                var usuario = _context
                    .Usuarios
                    .Where(e => e.CodigoUsuario.ToUpper() == sesion.Usuario.ToUpper())
                    .Include(e => e.SeguridadUsuario)
                    .FirstOrDefault();

                if (usuario is null) return Result.Fail("Usuario no existe");
                if (!usuario.Activo) return Result.Fail("Usuario no está activo");

                //var contraseña = EncriptadorUtil.Desencriptar(usuario.SeguridadUsuario.ContraseñaUsuario);
                var contraseña = usuario.SeguridadUsuario.ContraseñaUsuario;

                if (sesion.Contraseña != contraseña) return Result.Fail("Las Credenciales no son correctas");

                return Result.Ok(usuario.Mapear<UsuarioDto>());
            }
            catch (Exception)
            {
                return Result.Fail("Error innesperado, comuniquese con su administrador de sistemas.");
            }
        }
    }
}