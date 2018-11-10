using System.Windows.Controls;
using KMA.APZRPMJ2018.TextEditor.Tools;
using KMA.APZRPMJ2018.TextEditor.Managers;
using KMA.APZRPMJ2018.TextEditor.ViewModels;

namespace KMA.APZRPMJ2018.TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IContentWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
           // navigationModel.Navigate(ModesEnum.SignIn);
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
            mainWindowViewModel.StartApplication();
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}
