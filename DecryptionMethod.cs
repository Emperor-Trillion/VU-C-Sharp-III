using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace finalProject
{
    public class DecryptionMethod
    {
        private static readonly string iv = "abcdef0123456789";

        public static string TryDecryptPassword(string cipherText, string key)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            byte[] keyBtyes = Encoding.UTF8.GetBytes(key.PadRight(16, '\0').Substring(0, 16));
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            try
            {

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = keyBtyes;
                    aesAlg.IV = ivBytes;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(cipherTextBytes))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {

                            byte[] res = new byte[cipherTextBytes.Length];
                            int len = csDecrypt.Read(res, 0, res.Length);
                            return Encoding.UTF8.GetString(res, 0, len);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }

        }
    }
}
