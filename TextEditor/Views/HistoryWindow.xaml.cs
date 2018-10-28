using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
