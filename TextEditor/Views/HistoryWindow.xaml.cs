using System.Windows;
using KMA.APZRPMJ2018.TextEditor.ViewModels;

namespace KMA.APZRPMJ2018.TextEditor.Views
{
    /// <summary>
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        public HistoryWindow(string historyText)
        {
            InitializeComponent();
            DataContext = new HistoryWindowViewModel(historyText);
        }
    }
}
