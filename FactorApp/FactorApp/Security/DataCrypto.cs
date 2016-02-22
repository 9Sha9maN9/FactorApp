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
        public delegate void CannotDecrypt(Exception ex);
        public event CannotDecrypt onCannotDecrypt;

        public DataCrypto()
        {
            hashAlgm = HashAlgorithm.Create();
            aesAlgm = new AesCryptoServiceProvider();
            aesAlgm.Key = DataCrypto.GetBytes("sd&*Kx{Q");
            aesAlgm.IV = DataCrypto.GetBytes("SD78kX[q");
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
                        try
                        {
                            result = (object)srDecrypt.ReadToEnd();
                        }
                        catch(Exception ex)
                        {
                            onCannotDecrypt(ex);
                            result = false;
                        }
                    }
                }
            }
            return result;
        }

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            string result = new string(chars);
            return result;
        }


    }
}