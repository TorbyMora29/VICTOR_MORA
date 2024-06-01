namespace ProyectoJwt.Dto.Planificaciones.Tarea
{
    public class TareaCrearSolicitudDto
    {
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaVencimiento { get; set; }
    }
}
