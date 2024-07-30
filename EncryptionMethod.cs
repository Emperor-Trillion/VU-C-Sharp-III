using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace finalProject
{

    public class EncryptionMethod
    {
        private static readonly string key = "ffeba"; // 16 bytes for AES-128
        private static readonly string iv = "abcdef0123456789";  // 16 bytes for AES-128

        public static string EncryptPassword(string plainText)
        {
            byte[] Key = Encoding.UTF8.GetBytes(key.PadRight(16, '\0').Substring(0, 16));
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
    }
}

