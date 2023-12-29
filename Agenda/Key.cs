using System;
using System.Security.Cryptography;

namespace Agenda
{
    public class Key
    {
        public static string Secret = GerarChaveHMACSHA256();

        private static string GerarChaveHMACSHA256()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] chaveBytes = new byte[32]; // 32 bytes é o mínimo recomendado para HMAC-SHA256

                // Gera uma chave criptograficamente segura
                rng.GetBytes(chaveBytes);

                // Converte a chave para uma representação hexadecimal
                string chaveHex = BitConverter.ToString(chaveBytes).Replace("-", "").ToLower();

                return chaveHex;
            }
        }
    }
}
