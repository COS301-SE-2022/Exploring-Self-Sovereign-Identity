using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ExploringSelfSovereignIdentityAPI.Services.Encryption
{
    public class EncryptionService: IEncryptionService
    {

        private static string salt = "lkofnrenirnvierjnfoisoeofm3234434**^^%&sfwe4*&*^&$@@";
        public string DecryptString(string userID, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            Aes aes = Aes.Create();

            aes.Key = Encoding.UTF8.GetBytes(userID);
            aes.IV = iv;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            MemoryStream memoryStream = new MemoryStream(buffer);

            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read);

            StreamReader streamReader = new StreamReader((Stream)cryptoStream);

            return streamReader.ReadToEnd();
        }

        public  string EncryptString(string userID, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            Aes aes = Aes.Create();

            aes.Key = Encoding.UTF8.GetBytes(userID);
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write);

            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
            {
                streamWriter.Write(plainText);
            }

            array = memoryStream.ToArray();


            return Convert.ToBase64String(array);

        }


        public string generateKey(string userId)
        {
            return null;
        }



    }
}
