using KMA.APZRPMJ2018.TextEditor.ViewModels.Authentication;

namespace KMA.APZRPMJ2018.TextEditor.Views.Authentication
{
    internal partial class SignInView
    {
        #region Constructor
        internal SignInView()
        {
            InitializeComponent();
            var signInViewModel = new SignInViewModel();
            DataContext = signInViewModel;
        }
        #endregion
    }
}
