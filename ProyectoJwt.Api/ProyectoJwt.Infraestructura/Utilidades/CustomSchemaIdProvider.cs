namespace ProyectoJwt.Infraestructura.Utilidades
{
    public static class CustomSchemaIdProvider
    {
        public static string GenerateCustomSchemaId(Type type)
        {
            // Retorna un nombre único para cada tipo
            return type.FullName!.Replace(".", "_");
        }
    }
}
