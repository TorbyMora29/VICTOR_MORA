namespace ProyectoJwt.Web.ViewModel.Planificaciones.Tarea
{
    public class TareaVm
    {
        public long Identificador { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaVencimiento { get; set; }
        public bool EsCompletada { get; set; }
    }
}
