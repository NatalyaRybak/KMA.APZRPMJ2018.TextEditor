using System;
using System.Windows;
using KMA.APZRPMJ2018.TextEditor.Models;

namespace KMA.APZRPMJ2018.TextEditor.Managers
{
    public static class StationManager
    {
        public static User CurrentUser { get; set; }
        public static string CurrentFilepath { get; set; }

        public static void Initialize()
        {
            
        }

        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
