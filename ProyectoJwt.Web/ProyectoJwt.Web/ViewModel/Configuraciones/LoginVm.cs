using System.ComponentModel.DataAnnotations;

namespace ProyectoJwt.Web.ViewModel.Configuraciones
{
    public class LoginVm
    {
        [Required]
        public string Usuario { get; set; } = null!;

        [Required]
        public string Contraseña { get; set; } = null!;
    }
}
