using System;
using System.Security.Cryptography;
using System.Text;

namespace SecretDrawer
{
    public static class GlobalCode
    {
        public static Data.Secret CreateSecret(string _title, string content, int _order, string _color, int? category)
        {
            var _hash = RandomHash();
            return new Data.Secret
            {
                Title = _title,
                Hash = _hash,
                Content = EncryptText(content, _hash),
                Order = _order,
                Color = _color,
                IdCategory = category
            }; ;
        }
        public static Data.Secret CreateSecret(string _title, string content, int _order, string _color)
        {
            return CreateSecret(_title, content, _order, _color, null);
        }
        public static Data.Secret CreateSecret(string _title, string content, int _order)
        {
            return CreateSecret(_title, content, _order, "000000");
        }
        public static Data.Secret CreateSecret(string _title, string content)
        {
            return CreateSecret(_title, content, 1);
        }

        public static string RandomHash()
        {
            var buffer = new byte[10];
            RandomNumberGenerator.Create().GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }

        private static Aes CreateAES()
        {
            var aes = Aes.Create();
            aes.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(App.Pass));
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            return aes;

        }
        private static Aes CreateAES(string pass)
        {
            var aes = Aes.Create();
            aes.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(pass));
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            return aes;

        }
        public static string DecryptText(string encryptedText)
        {
            var decryptedText = string.Empty;
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            var aes = CreateAES();
            using (var transform = aes.CreateDecryptor())
            {
                var decryptedBytes = transform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                decryptedText = Encoding.UTF8.GetString(decryptedBytes);
            }
            return decryptedText;
        }
        public static string EncryptText(string decryptedText)
        {
            var encryptedText = string.Empty;
            var aes = CreateAES();
            using (var transform = aes.CreateEncryptor())
            {
                var encryptedBytes = transform.TransformFinalBlock(Encoding.UTF8.GetBytes(decryptedText), 0, Encoding.UTF8.GetBytes(decryptedText).Length);
                encryptedText = Convert.ToBase64String(encryptedBytes);
            }
            return encryptedText;
        }
        public static string DecryptText(string encryptedText, string pass)
        {
            var decryptedText = string.Empty;
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            var aes = CreateAES(pass);
            using (var transform = aes.CreateDecryptor())
            {
                var decryptedBytes = transform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                decryptedText = Encoding.UTF8.GetString(decryptedBytes);
            }
            return decryptedText;
        }
        public static string EncryptText(string decryptedText, string pass)
        {
            var encryptedText = string.Empty;
            var aes = CreateAES(pass);
            using (var transform = aes.CreateEncryptor())
            {
                var encryptedBytes = transform.TransformFinalBlock(Encoding.UTF8.GetBytes(decryptedText), 0, Encoding.UTF8.GetBytes(decryptedText).Length);
                encryptedText = Convert.ToBase64String(encryptedBytes);
            }
            return encryptedText;
        }
    }
}