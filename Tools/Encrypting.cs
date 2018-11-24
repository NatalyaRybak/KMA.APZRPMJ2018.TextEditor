using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace KMA.APZRPMJ2018.TextEditor.Tools
{
    public static class Encrypting
    {
        public static string EncryptText(string text, string publicKey)
        {
            text = GetMd5HashForString(text);
            text = EncryptString(text, publicKey);
            return text;
        }
        public static string GetMd5HashForString(string text)
        {
            var md5Hasher = new MD5CryptoServiceProvider();

            var hashValue = md5Hasher.ComputeHash(ConvertStringToByteArray(text));
            var hashData = BitConverter.ToString(hashValue);
            hashData = hashData.Replace("-", "");
            var result = hashData;
            return result;
        }
        public static string DecryptString(string inputString, string xmlString)
        {
            var rsaCryptoServiceProvider = new RSACryptoServiceProvider(1024);
            rsaCryptoServiceProvider.FromXmlString(xmlString);
            const int base64BlockSize = 128 / 3 * 4 + 4;
            var iterations = inputString.Length / base64BlockSize;
            var arrayList = new ArrayList();
            for (var i = 0; i < iterations; i++)
            {
                var encryptedBytes = Convert.FromBase64String(inputString.Substring(base64BlockSize * i, base64BlockSize));
                Array.Reverse(encryptedBytes);
                arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(encryptedBytes, true));
            }
            return Encoding.UTF32.GetString(arrayList.ToArray(typeof(byte)) as byte[]);
        }

        private static string EncryptString(string inputString, string xmlString)
        {
            var rsaCryptoServiceProvider = new RSACryptoServiceProvider(1024);
            rsaCryptoServiceProvider.FromXmlString(xmlString);
            var keySize = 128;
            var bytes = Encoding.UTF32.GetBytes(inputString);
            var maxLength = keySize - 42;
            var dataLength = bytes.Length;
            var iterations = dataLength / maxLength;
            var stringBuilder = new StringBuilder();
            for (var i = 0; i <= iterations; i++)
            {
                var tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
                Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0, tempBytes.Length);
                var encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes, true);
                Array.Reverse(encryptedBytes);
                stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
            }
            return stringBuilder.ToString();
        }
        private static byte[] ConvertStringToByteArray(string data)
        {
            return new UnicodeEncoding().GetBytes(data);
        }
    }
}
