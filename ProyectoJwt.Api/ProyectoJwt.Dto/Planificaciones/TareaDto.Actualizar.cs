namespace ProyectoJwt.Dto.Planificaciones
{
    public partial class TareaDto
    {
        public class Actualizar
        {
            public long Identificador { get; set; }
            public string Titulo { get; set; } = null!;
            public string Descripcion { get; set; } = null!;
            public DateTime FechaVencimiento { get; set; }
        }
    }
}
