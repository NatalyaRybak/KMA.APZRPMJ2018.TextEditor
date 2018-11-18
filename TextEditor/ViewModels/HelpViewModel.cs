using System.Windows.Input;
using KMA.APZRPMJ2018.TextEditor.Tools;

namespace KMA.APZRPMJ2018.TextEditor.ViewModels
{
    /// <summary>
    /// View model for a help dialog.
    /// </summary>
    public class HelpViewModel : ObservableObject
    {
        public ICommand HelpCommand { get; }

        public HelpViewModel()
        {
            HelpCommand = new RelayCommand<object>(DisplayAbout);
        }

        private void DisplayAbout(object obj)
        {
            var helpDialog = new HelpDialog();
            helpDialog.ShowDialog();
        }
    }
}
