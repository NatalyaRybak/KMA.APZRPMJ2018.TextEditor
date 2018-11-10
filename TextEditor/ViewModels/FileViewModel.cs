using System.Drawing.Text;
using Microsoft.Win32;
using System.Windows.Input;
using KMA.APZRPMJ2018.TextEditor.Models;
using System.IO;
using System.Runtime.CompilerServices;
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
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile, () => !Document.isEmpty);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);
        }

        public void NewFile()
        {
            Document.FileName = string.Empty;
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
            StationManager.CurrentFilepath = Document.FilePath;
        }

        private void SaveFile()
        {
            File.WriteAllText(Document.FilePath, Document.Text);
            RecordQuery();
        }

        private void SaveFileAs()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            if(saveFileDialog.ShowDialog() == true)
            {
                DockFile(saveFileDialog);
                File.WriteAllText(saveFileDialog.FileName, Document.Text);
                RecordQuery();
            }
        }

        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                DockFile(openFileDialog);
                RecordQuery(true);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void RecordQuery(bool isOpened = false)
        {
            var currentHash = FileUtils.CalculateMD5(Document.FilePath);
            var edited = !isOpened && _lastOpenedDocumentHash != currentHash;
            _lastOpenedDocumentHash = currentHash;
            StationManager.CurrentFilepath = Document.FilePath;
            StationManager.CurrentUser.AddQuery(
                Document.FilePath, 
                isOpened ? QueryType.OPENED : (edited ? QueryType.EDITED : QueryType.NOT_EDITED)
            );
            DBManager.UpdateUser(StationManager.CurrentUser);

        }

        private void DockFile<T>(T dialog) where T : FileDialog
        {
            Document.FilePath = dialog.FileName;
            Document.FileName = dialog.SafeFileName;
        }
    }
}
