using ProyectoJwt.Web.Constantes;

namespace ProyectoJwt.Web.Utilidades
{
    public static class FormateadorUtil
    {
        public static string ToDateFormat(this DateTime fecha, string formato = FormatosFecha.m_FormatoFechaComun)
        {
            return fecha.ToString(formato);
        }
        public static string ToDateIsoFormat(this DateTime fecha)
        {
            return fecha.ToDateFormat(FormatosFecha.m_FormatoFechaIso);
        }
        public static string ToTextFormat(this bool valor)
        {
            return valor ? "SÍ" : "NO";
        }
    }
}
