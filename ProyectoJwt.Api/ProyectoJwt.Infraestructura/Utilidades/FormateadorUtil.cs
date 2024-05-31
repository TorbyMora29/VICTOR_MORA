using ProyectoJwt.Infraestructura.Constantes;

namespace ProyectoJwt.Infraestructura.Utilidades
{
    public static class FormateadorUtil
    {
        public static string ToDateFormat(this DateTime fecha, string formato = FormatosFecha.m_FormatoFechaComun)
        {
            return fecha.ToString(formato);
        }
    }
}
