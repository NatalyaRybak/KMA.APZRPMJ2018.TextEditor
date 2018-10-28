using KMA.APZRPMJ2018.TextEditor.ViewModels.Authentication;

namespace KMA.APZRPMJ2018.TextEditor.Views.Authentication
{  
    internal partial class SignUpView
    {
        #region Constructor
        internal SignUpView()
        {
            InitializeComponent();
            var signUpViewModel = new SignUpViewModel();
            DataContext = signUpViewModel;
        }
        #endregion
    }
}
