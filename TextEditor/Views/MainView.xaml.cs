using KMA.APZRPMJ2018.TextEditor.ViewModels;
using KMA.APZRPMJ2018.TextEditor.Models;

namespace KMA.APZRPMJ2018.TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
