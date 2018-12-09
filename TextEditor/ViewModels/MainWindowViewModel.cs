using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using KMA.APZRPMJ2018.TextEditor.Managers;
using KMA.APZRPMJ2018.TextEditor.Properties;
using KMA.APZRPMJ2018.TextEditor.Tools;

namespace KMA.APZRPMJ2018.TextEditor.ViewModels
{
    public class MainWindowViewModel : ILoaderOwner
    {
        private Visibility _visibility = Visibility.Hidden;
        private bool _isEnabled = true;

        public Visibility LoaderVisibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }

        internal void StartApplication()
        {
            NavigationManager.Instance.Navigate(StationManager.CurrentUser != null ? ModesEnum.Main : ModesEnum.SignIn);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
