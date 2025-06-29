﻿using System.Security.Cryptography;
using System.Text;
namespace Personal.Helpers
{
    public static class SecurityHelper
    {
        public static string Encrypt(string txtValueText, string hash)
        {
            byte[] data = Encoding.UTF8.GetBytes(txtValueText);
            byte[] keys = MD5.HashData(Encoding.UTF8.GetBytes(hash));
            using (var tripDes = TripleDES.Create())
            {
                tripDes.Key = keys;
                tripDes.Mode = CipherMode.CTS;
                tripDes.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = tripDes.CreateEncryptor();
                byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                return Convert.ToBase64String(results, 0, results.Length);
            }
        }
        public static string Decrypt(string txtEncryptText, string hash)
        {
            byte[] data = Convert.FromBase64String(txtEncryptText);
            byte[] keys = MD5.HashData(Encoding.UTF8.GetBytes(hash));
            using (var tripDes = TripleDES.Create())
            {
                tripDes.Key = keys;
                tripDes.Mode = CipherMode.CTS;
                tripDes.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = tripDes.CreateDecryptor();
                byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                return Encoding.UTF8.GetString(results);
            }
        }
    }
}