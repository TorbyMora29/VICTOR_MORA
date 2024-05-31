using ProyectoJwt.Entidades.Comunes;

namespace ProyectoJwt.Entidades.Configuraciones
{
    public class SeguridadUsuario : Auditoria
    {
        public long Identificador { get; set; }
        public long IdentidicadorUsuario { get; set; }
        public string ContraseñaUsuario { get; set; } = null!;
        public DateTime ExpiracionContraseña {  get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
