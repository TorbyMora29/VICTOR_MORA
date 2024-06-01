using System.ComponentModel.DataAnnotations;

namespace ProyectoJwt.Web.ViewModel.Configuraciones
{
    public class CrearUsuarioVm
    {
        [Required]
        public string CodigoUsuario { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string DescripcionUsuario { get; set; } = null!;

        [Required]
        public string ContraseñaUsuario { get; set; } = null!;
    }
}
