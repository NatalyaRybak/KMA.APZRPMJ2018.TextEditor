using System;
using System.IO;

namespace KMA.APZRPMJ2018.TextEditor.Tools
{
    public static class FileFolderHelper
    {
        public static readonly string AppDataPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static readonly string ClientFolderPath =
            Path.Combine(AppDataPath, "TextEditor");

        public static readonly string LogFolderPath =
            Path.Combine(ClientFolderPath, "Log");

        public static readonly string LogFilepath = Path.Combine(LogFolderPath,
            "App_" + DateTime.Now.ToString("YYYY_MM_DD") + ".txt");

        public static readonly string StorageFilePath =
            Path.Combine(ClientFolderPath, "Storage.walsim");

        public static readonly string LastUserFilePath =
            Path.Combine(ClientFolderPath, "LastUser.walsim");

        public static void CheckAndCreateFile(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (!file.Directory.Exists)
                {
                    file.Directory.Create();
                }
                if (!file.Exists)
                {
                    file.Create().Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Failed to check and create file {filePath}", ex);
                throw;
            }
        }
    }
}