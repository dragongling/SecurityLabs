using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using MetalWorker.Cryptography;
using System.Threading.Tasks;

namespace RSA_code
{
    /// <summary>
    /// Encrypts and decrypts strings with the block RSA
    /// </summary>
    class StringRSA
    {
        private static readonly Encoding encoding = new UTF8Encoding();

        public static string Encrypt(string text, BlockRSA.Key<BigInteger> encKey)
        {
            return ByteArrayToString(BlockRSA.Encrypt(encoding.GetBytes(text), encKey));
        }

        public static string Decrypt(string text, BlockRSA.Key<BigInteger> decKey)
        {
            return encoding.GetString(BlockRSA.Decrypt(StringToByteArray(text), decKey));
        }

        public static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
