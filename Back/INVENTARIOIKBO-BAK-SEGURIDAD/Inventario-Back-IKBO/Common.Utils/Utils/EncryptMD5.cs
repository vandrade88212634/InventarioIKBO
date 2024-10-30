using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Common.Utils.Utils
{
    public class EncryptMD5
    {

        public string Encrypt( string mensaje)
        {
            string hash = "Softgic Cens";
            byte[] data = UTF32Encoding.UTF8.GetBytes(mensaje);
            MD5 md5 = MD5.Create();
            TripleDES tripleDES = TripleDES.Create();
            tripleDES.Key = md5.ComputeHash(UTF32Encoding.UTF8.GetBytes(hash));
            tripleDES.Mode = CipherMode.ECB;
            ICryptoTransform transform = tripleDES.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data,0, data.Length);
            return Convert.ToBase64String(result);



        }

        public string Decrypt(string menajeEncriptado)
        {
            string hash = "Softgic Cens";
            byte[] data = Convert.FromBase64String(menajeEncriptado);
            MD5 md5 = MD5.Create();
            TripleDES tripleDES = TripleDES.Create();
            tripleDES.Key = md5.ComputeHash(UTF32Encoding.UTF8.GetBytes(hash));
            tripleDES.Mode = CipherMode.ECB;
            ICryptoTransform transform = tripleDES.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
            return UTF8Encoding.UTF8.GetString(result);

        }
    }
}
