using KMA.APZRPMJ2018.TextEditor.Tools;

namespace KMA.APZRPMJ2018.TextEditor.Models
{
    /// <inheritdoc />
    /// <summary>
    /// Model for the text editor document.
    /// </summary>
    public class DocumentModel : ObservableObject
    {
        private string _text;
        public string Text
        {
            get => _text;
            set => OnPropertyChanged(ref _text, value);
        }

        private string _filePath;
        public string FilePath
        {
            get => _filePath;
            set => OnPropertyChanged(ref _filePath, value);
        }

        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set => OnPropertyChanged(ref _fileName, value);
        }

        public bool IsEmpty => string.IsNullOrEmpty(FileName) ||
                               string.IsNullOrEmpty(FilePath);
    }
}
