namespace ProyectoJwt.Dto.Configuracion
{
    public partial class UsuarioDto
    {
        public class Creacion
        {
            public string CodigoUsuario { get; set; } = null!;
            public string DescripcionUsuario { get; set; } = null!;
            public string ContraseñaUsuario { get; set; } = null!;
        }
    }    
}
