using System;
using System.IO;
using System.Security.Cryptography;

namespace SoviTech.Common.Encryption
{
    public class TripleDESEncryptor : ICryptoOperation
    {
        //24 byte or 192 bit key and IV for TripleDES
        private static byte[] KEY_192 = { 25, 61, 93, 156, 42, 4, 238, 32, 15, 78, 44, 80, 26, 250, 155, 112, 2, 94, 21, 204, 62, 23, 5, 234 };
        private static byte[] IV_192 = { 22, 156, 61, 54, 23, 99, 167, 3, 42, 5, 62, 83, 184, 7, 209, 23, 213, 43, 218, 54, 23, 56, 55, 211 };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Encrypt(string value)
        {
            string returnValue = string.Empty;
            string encryptData = value;
            if (!string.IsNullOrEmpty(encryptData))
            {
                TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_192, IV_192), CryptoStreamMode.Write);
                StreamWriter sw = new StreamWriter(cs);
                sw.Write(encryptData);
                sw.Flush();
                cs.FlushFinalBlock();
                ms.Flush();
                //convert back to a string
                returnValue = Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
            }
            return returnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Decrypt(string value)
        {
            string returnValue = string.Empty;
            string data = value;
            if (!string.IsNullOrEmpty(data))
            {
                TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
                //convert from string to byte array
                byte[] buffer = Convert.FromBase64String(data);
                MemoryStream ms = new MemoryStream(buffer);
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_192, IV_192), CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);
                returnValue = sr.ReadToEnd();
            }
            return returnValue;
        }
    }
}
