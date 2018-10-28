using System;
using KMA.APZRPMJ2018.WalletSimulator.Models;
using KMA.APZRPMJ2018.WalletSimulator.Views;
using System.Windows;
using System.Windows.Input;
using KMA.APZRPMJ2018.WalletSimulator.Managers;

namespace KMA.APZRPMJ2018.WalletSimulator.ViewModels
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

        public MainViewModel()
        {
            _document = new DocumentModel();
            Help = new HelpViewModel();
            Editor = new EditorViewModel(_document);
            File = new FileViewModel(_document);
            HistoryCommand = new RelayCommand(DisplayHistory);


        }
        private void DisplayHistory()
        {
            new HistoryWindow(
                String.Join("\n", StationManager.CurrentUser.GetQueries(StationManager.CurrentFilepath))
            ).Show();
        }
    }
}
