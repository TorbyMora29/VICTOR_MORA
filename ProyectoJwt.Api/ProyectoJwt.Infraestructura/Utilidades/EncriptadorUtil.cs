using System.Security.Cryptography;

namespace ProyectoJwt.Infraestructura.Utilidades
{
    public static class EncriptadorUtil
    {
        public static string Encriptar(string textoEncriptar)
        {
            using Aes myAes = Aes.Create();
            return CodificadorUtil.CodificarByte(EncriptarTextoAByte_Aes(textoEncriptar, myAes.Key, myAes.IV));
        }

        public static string Desencriptar(string textoEncriptado)
        {
            using Aes myAes = Aes.Create();
            return DesencriptarTextoABytes_Aes(CodificadorUtil.DecodificarAByte(textoEncriptado), myAes.Key, myAes.IV);
        }

        private static byte[] EncriptarTextoAByte_Aes(string textoCifrar, byte[] llave, byte[] IV)
        {
            // Check arguments.
            if (textoCifrar == null || textoCifrar.Length <= 0) throw new ArgumentNullException(nameof(textoCifrar));
            if (llave == null || llave.Length <= 0) throw new ArgumentNullException(nameof(llave));
            if (IV == null || IV.Length <= 0) throw new ArgumentNullException(nameof(IV));

            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = llave;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using MemoryStream msEncrypt = new();
                using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (StreamWriter swEncrypt = new(csEncrypt))
                swEncrypt.Write(textoCifrar);
                encrypted = msEncrypt.ToArray();
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        private static string DesencriptarTextoABytes_Aes(byte[] textoCifrado, byte[] llave, byte[] IV)
        {
            // Check arguments.
            if (textoCifrado == null || textoCifrado.Length <= 0) throw new ArgumentNullException(nameof(textoCifrado));
            if (llave == null || llave.Length <= 0) throw new ArgumentNullException(nameof(llave));
            if (IV == null || IV.Length <= 0) throw new ArgumentNullException(nameof(IV));

            // Declare the string used to hold
            // the decrypted text.
            string plaintext;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = llave;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using MemoryStream msDecrypt = new(textoCifrado);
                using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new(csDecrypt);

                // Read the decrypted bytes from the decrypting stream
                // and place them in a string.
                plaintext = srDecrypt.ReadToEnd();
            }

            return plaintext;
        }

    }
}
