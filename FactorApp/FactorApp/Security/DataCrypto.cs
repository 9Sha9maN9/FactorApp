using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace FactorApp.Security
{
    class DataCrypto
    {
        private HashAlgorithm hashAlgm;
        private AesCryptoServiceProvider aesAlgm;

        public DataCrypto()
        {
            hashAlgm = HashAlgorithm.Create();
            aesAlgm = new AesCryptoServiceProvider();
            aesAlgm.Key = (new UnicodeEncoding()).GetBytes("fghW[%+d");
            aesAlgm.IV = (new UnicodeEncoding()).GetBytes("o%df(c䣝$");
            aesAlgm.Mode = CipherMode.CBC;
            aesAlgm.Padding = PaddingMode.PKCS7;
        }

        public byte[] HashPasswordEncrypt(string password)
        {
            return hashAlgm.ComputeHash((new UnicodeEncoding()).GetBytes(password));
        }

        public byte[] AesDataEncrypt(object data)
        {
            byte[] result;
            ICryptoTransform encryptor = aesAlgm.CreateEncryptor(aesAlgm.Key, aesAlgm.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(data);
                    }
                    result = msEncrypt.ToArray();
                }
            }
            return result;
        }

        public object AesDataDecrypt(byte[] data)
        {
            object result;
            ICryptoTransform decryptor = aesAlgm.CreateDecryptor(aesAlgm.Key, aesAlgm.IV);
            using (MemoryStream msDecrypt = new MemoryStream(data))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        result = (object)srDecrypt.ReadToEnd();
                    }
                }
            }
            return result;
        }
    }
}