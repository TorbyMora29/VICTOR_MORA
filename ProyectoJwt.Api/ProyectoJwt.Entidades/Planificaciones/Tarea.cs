using ProyectoJwt.Entidades.Comunes;

namespace ProyectoJwt.Entidades.Planificaciones
{
    public class Tarea : Auditoria
    {
        public long Identificador { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaVencimiento { get; set; }
        public bool EsCompletada { get; set; }
        public bool Activo { get; set; }
    }
}
