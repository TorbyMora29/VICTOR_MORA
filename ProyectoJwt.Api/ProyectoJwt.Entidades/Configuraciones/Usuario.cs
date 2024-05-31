using ProyectoJwt.Entidades.Comunes;

namespace ProyectoJwt.Entidades.Configuraciones
{
    public class Usuario : Auditoria
    {
        public long Identificador { get; set; }
        public string CodigoUsuario { get; set; } = null!;
        public string DescripcionUsuario { get; set; } = null!;
        public bool RequiereActualizacionContraseña {  get; set; }
        public bool Activo {  get; set; }

        public virtual SeguridadUsuario SeguridadUsuario { get; set; }
    }
}
