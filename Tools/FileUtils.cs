using System;
using System.IO;
using System.Security.Cryptography;

namespace KMA.APZRPMJ2018.TextEditor.Tools
{
    public class FileUtils
    {
        public static string CalculateMd5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}
