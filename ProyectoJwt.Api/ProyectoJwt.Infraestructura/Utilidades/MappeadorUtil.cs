using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProyectoJwt.Infraestructura.Utilidades
{
    public static class MappeadorUtil
    {
        private static readonly JsonSerializerOptions m_OpcionesSerializado = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };

        public static T Mapear<T>(this object objeto)
        {
            var serializado = JsonSerializer.Serialize(objeto, m_OpcionesSerializado);
            return JsonSerializer.Deserialize<T>(serializado)!;
        }
    }
}
