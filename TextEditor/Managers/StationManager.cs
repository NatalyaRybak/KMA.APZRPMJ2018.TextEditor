using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using KMA.APZRPMJ2018.TextEditor.Models;
using KMA.APZRPMJ2018.TextEditor.Tools;

namespace KMA.APZRPMJ2018.TextEditor.Managers
{
    public static class StationManager
    {
        public static User CurrentUser { get; set; }
        public static string CurrentFilepath { get; set; }

        static StationManager()
        {
            DeserializeLastUser();
        }

        private async static void DeserializeLastUser()
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                Thread.Sleep(3000);

                User userCandidate;
                userCandidate = SerializationManager.Deserialize<User>(Path.Combine(FileFolderHelper.LastUserFilePath));
                if (userCandidate == null)
                {
                     Logger.Log("User was not deserialized");
                     return false;
                }
                userCandidate = DBManager.CheckCachedUser(userCandidate);
                if (userCandidate == null)
                {
                    MessageBox.Show("Failed to relogin last user");
                    Logger.Log("Failed to relogin last user");
                    return false;
                 }
                 else
                 {
                     CurrentUser = userCandidate;
                     MessageBox.Show("Last user logged " + CurrentUser.ToString());
                     return true;
                 }
            });
            LoaderManager.Instance.HideLoader();
            if (result)
                NavigationManager.Instance.Navigate(ModesEnum.Main);
        }

        internal static void CloseApp()
        {
            SerializationManager.Serialize(CurrentUser, FileFolderHelper.LastUserFilePath);
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
