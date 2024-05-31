namespace ProyectoJwt.Dto.Configuracion
{
    public partial class UsuarioDto
    {
        public class Sesion
        {
            public string Usuario { get; set; } = null!;
            public string Contraseña { get; set; } = null!;
        }
    }    
}
