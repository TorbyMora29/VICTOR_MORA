namespace ProyectoJwt.Dto.Planificaciones
{
    public partial class TareaDto
    {
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaVencimiento { get; set; }
        public bool EsCompletada { get; set; }
        public bool Activo { get; set; }
    }
}
