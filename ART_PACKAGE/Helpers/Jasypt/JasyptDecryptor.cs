

using Mono.Unix.Native;
using sun.security.util;
using System;
using System.Security.Cryptography;
using System.Text;


namespace ART_PACKAGE.Helpers.Jasypt
{
    public class JasyptDecryptor
    {
        private const string Password = "DG-ARTSecretP@ssw0rd";
        private const int Iterations = 1000;
        public static string Decrypt(string encryptedText)
        {

            // Generate key and IV from the password


            try
            {
                using (var sha256 = SHA256.Create())
                {
                    var key = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password)).AsSpan(0, 32).ToArray();
                    var iv = Encoding.UTF8.GetBytes("16byteslongivval");
                    using (var aes = Aes.Create())
                    {
                        aes.Key = key;
                        aes.IV = iv;

                        using (var ms = new MemoryStream(Convert.FromBase64String(encryptedText)))
                        {
                            using (var cryptoStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                            {
                                using (var reader = new StreamReader(cryptoStream))
                                {
                                    return reader.ReadToEnd();
                                }
                            }
                        }
                    }
                } }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during decryption: {ex.Message}");
                throw ex;
            }
        }
       
    }
}
