namespace ProyectoJwt.Dto.Configuraciones.Login
{
    public class CrearUsuarioSolicitudDto
    {
        public string CodigoUsuario { get; set; } = null!;
        public string DescripcionUsuario { get; set; } = null!;
        public string ContraseñaUsuario { get; set; } = null!;
    }
}
