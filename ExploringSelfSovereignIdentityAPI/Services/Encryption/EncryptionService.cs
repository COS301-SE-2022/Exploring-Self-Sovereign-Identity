﻿using System;
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

            aes.Key = Encoding.UTF8.GetBytes(generateKey(userID));
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

            aes.Key = Encoding.UTF8.GetBytes(generateKey(userID));
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


        private string generateKey(string userId)
        {
            string key = "";
            string tempUserId = userId;

            for (int i=0; i<=(32 - userId.Length); i++)
            {
                tempUserId += (i%10).ToString();
            }

            for (int i = 0; i < 32; i++)
            {
                key += tempUserId[(userId.Length + i) % 32];
            }

            byte[] iv = new byte[16];
            byte[] array;

            Aes aes = Aes.Create();

            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write);

            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
            {
                streamWriter.Write(userId);
            }

            array = memoryStream.ToArray();

            string enc = Convert.ToBase64String(array);

            string tempEnc = enc;

            for (int i = 0; i <= (32 - enc.Length); i++)
            {
                tempEnc += (i % 10).ToString();
            }

            string res = "";

            for (int i = 0; i < 32; i++)
            {
                res += tempEnc[(enc.Length + i) % 32];
            }

            return res;
        }



    }
}
