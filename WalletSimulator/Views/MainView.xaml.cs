using System.Windows;
using KMA.APZRPMJ2018.WalletSimulator.ViewModels;

namespace KMA.APZRPMJ2018.WalletSimulator
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
