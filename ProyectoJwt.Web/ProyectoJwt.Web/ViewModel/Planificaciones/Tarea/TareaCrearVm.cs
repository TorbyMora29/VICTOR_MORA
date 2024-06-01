namespace ProyectoJwt.Web.ViewModel.Planificaciones.Tarea
{
    public class TareaCrearVm
    {
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaVencimiento { get; set; }
    }
}
