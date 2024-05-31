namespace ProyectoJwt.Entidades.Comunes
{
    public class Auditoria
    {
        public string UsuarioCreacion { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
    }
}
