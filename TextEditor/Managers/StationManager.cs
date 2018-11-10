using System;
using System.IO;
using System.Windows;
using KMA.APZRPMJ2018.TextEditor.Models;
using KMA.APZRPMJ2018.TextEditor.Tools;

namespace KMA.APZRPMJ2018.TextEditor.Managers
{
    public static class StationManager
    {
        public static User CurrentUser { get; set; }
        public static string CurrentFilepath { get; set; }

//        public static void Initialize()
//        {
//            
//        }
        static StationManager()
        {
            DeserializeLastUser();
        }

        private static void DeserializeLastUser()
        {
            User userCandidate;
//            try
//            {
                userCandidate = SerializationManager.Deserialize<User>(Path.Combine(FileFolderHelper.LastUserFilePath));
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("catch");
//                MessageBox.Show(ex.Message);
//
//                userCandidate = null;
//                MessageBox.Show("userCandidate = null;");
//
//                Logger.Log("Failed to Deserialize last user", ex);
//            }
            if (userCandidate == null)
            {
              Logger.Log("User was not deserialized");
                return;
            }
            userCandidate = DBManager.CheckCachedUser(userCandidate);
            if (userCandidate == null)
            {
                MessageBox.Show("Failed to relogin last user");
                Logger.Log("Failed to relogin last user");
            }
            else
            {
                CurrentUser = userCandidate;
                MessageBox.Show("Last user logged " + CurrentUser.ToString());

                NavigationManager.Instance.Navigate(ModesEnum.Main);
            }
        }

        internal static void CloseApp()
        {
            SerializationManager.Serialize(CurrentUser, FileFolderHelper.LastUserFilePath);
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
