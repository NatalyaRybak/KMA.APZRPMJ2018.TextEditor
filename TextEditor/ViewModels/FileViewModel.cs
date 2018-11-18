using Microsoft.Win32;
using System.Windows.Input;
using KMA.APZRPMJ2018.TextEditor.Models;
using System.IO;
using KMA.APZRPMJ2018.TextEditor.Tools;
using KMA.APZRPMJ2018.TextEditor.Managers;

namespace KMA.APZRPMJ2018.TextEditor.ViewModels
{
    /// <summary>
    /// View model for the file toolbar.
    /// </summary>
    public class FileViewModel
    {
        public DocumentModel Document { get; private set; }
        private string _lastOpenedDocumentHash;
        
        //Toolbar commands
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }

        public FileViewModel(DocumentModel document)
        {
            Document = document;
            NewCommand = new RelayCommand<object>(NewFile);
            SaveCommand = new RelayCommand<object>(SaveFile, obj => !Document.IsEmpty);
            SaveAsCommand = new RelayCommand<object>(SaveFileAs);
            OpenCommand = new RelayCommand<object>(OpenFile);
        }

        public void NewFile(object obj)
        {
            Document.FileName = string.Empty;
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
            StationManager.CurrentFilepath = Document.FilePath;
            Logger.Log("New File");

        }

        private void SaveFile(object obj)
        {
            File.WriteAllText(Document.FilePath, Document.Text);
            RecordQuery();
            Logger.Log("Save File");

        }

        private void SaveFileAs(object obj)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            if(saveFileDialog.ShowDialog() == true)
            {
                DockFile(saveFileDialog);
                File.WriteAllText(saveFileDialog.FileName, Document.Text);
                RecordQuery();
                Logger.Log("Save As File");

            }
        }

        private void OpenFile(object obj)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                DockFile(openFileDialog);
                RecordQuery(true);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
                Logger.Log("Open File");

            }
        }

        private void RecordQuery(bool isOpened = false)
        {
            var currentHash = FileUtils.CalculateMd5(Document.FilePath);
            var edited = !isOpened && _lastOpenedDocumentHash != currentHash;
            _lastOpenedDocumentHash = currentHash;
            StationManager.CurrentFilepath = Document.FilePath;
            StationManager.CurrentUser.AddQuery(
                Document.FilePath, 
                isOpened ? QueryType.Opened : (edited ? QueryType.Edited : QueryType.NotEdited)
            );
            DbManager.UpdateUser(StationManager.CurrentUser);

        }

        private void DockFile<T>(T dialog) where T : FileDialog
        {
            Document.FilePath = dialog.FileName;
            Document.FileName = dialog.SafeFileName;
        }
    }
}
