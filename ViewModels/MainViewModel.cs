﻿using System;
using KMA.APZRPMJ2018.TextEditor.Models;
using System.Windows.Input;
using KMA.APZRPMJ2018.TextEditor.Views;
using KMA.APZRPMJ2018.TextEditor.Managers;
using KMA.APZRPMJ2018.TextEditor.Tools;
using System.Threading.Tasks;
using Exception = System.Exception;
using System.Windows;

namespace KMA.APZRPMJ2018.TextEditor.ViewModels
{
    /// <summary>
    /// Main view model for the Notepad application main window.
    /// </summary>
    public class MainViewModel
    {
        //Document that is saved, loaded and hold editor text
        private DocumentModel _document;
        //Manages user input for document and format styles
        public EditorViewModel Editor { get; set; }
        //Manages saving and loading text files
        public FileViewModel File { get; set; }
        //Manage help dialog
        public HelpViewModel Help { get; set; }
        public ICommand HistoryCommand { get; }
        public ICommand LogOutCommand { get; }

        public MainViewModel()
        {
            _document = new DocumentModel();
            Help = new HelpViewModel();
            Editor = new EditorViewModel(_document);
            File = new FileViewModel(_document);
            HistoryCommand = new RelayCommand<object>(DisplayHistory);
            LogOutCommand = new RelayCommand<object>(LogOut);


        }
        private void DisplayHistory(object obj)
        {
            new HistoryWindow(
            String.Join("\n", StationManager.CurrentUser.GetQueries(StationManager.CurrentFilepath))
            ).Show();
        }

        private async void LogOut(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    if (System.IO.File.Exists(FileFolderHelper.LastUserFilePath))
                    {
                        System.IO.File.Delete(FileFolderHelper.LastUserFilePath);

                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Logger.Log($"Update user exception ", ex);
                    return false;
                }
            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                _document.Text = "";
                _document.FilePath = null;
                StationManager.CurrentUser = null;
                NavigationManager.Instance.Navigate(ModesEnum.SignIn);
            }
        }

    }
}