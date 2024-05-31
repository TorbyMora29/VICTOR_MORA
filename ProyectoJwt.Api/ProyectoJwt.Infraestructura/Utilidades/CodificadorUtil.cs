using System.Text;

namespace ProyectoJwt.Infraestructura.Utilidades
{
    public static class CodificadorUtil
    {
        public static string CodificarByte(byte[] arregloCodificar)
        {
            return Codificar(arregloCodificar);
        }
        public static string CodificarTexto(string texto)
        {
            return Codificar(Encoding.UTF8.GetBytes(texto));
        }

        private static string Codificar(byte[] arregloCodificar)
        {
            return Convert.ToBase64String(arregloCodificar).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        }

        public static string DecodificarATexto(string textoCodificado)
        {
            textoCodificado = textoCodificado.Replace('_', '/').Replace('-', '+');
            switch (textoCodificado.Length % 4)
            {
                case 2:
                    textoCodificado += "==";
                    break;
                case 3:
                    textoCodificado += "=";
                    break;
            }
            return Encoding.UTF8.GetString(Convert.FromBase64String(textoCodificado));
        }
        public static byte[] DecodificarAByte(string textoCodificado)
        {
            textoCodificado = textoCodificado.Replace('_', '/').Replace('-', '+');
            switch (textoCodificado.Length % 4)
            {
                case 2:
                    textoCodificado += "==";
                    break;
                case 3:
                    textoCodificado += "=";
                    break;
            }
            return Convert.FromBase64String(textoCodificado);
        }
    }
}
