using System;
using KMA.APZRPMJ2018.TextEditor.Views.Authentication;

namespace KMA.APZRPMJ2018.TextEditor.Tools
{
    internal enum ModesEnum
    {
        SignIn,
        SingUp,
        Main
    }

    internal class NavigationModel
    {
        private readonly IContentWindow _contentWindow;
        private SignInView _signInView;
        private SignUpView _signUpView;
        private MainView _mainView;

        internal NavigationModel(IContentWindow contentWindow)
        {
            _contentWindow = contentWindow;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.SignIn:
                    _contentWindow.ContentControl.Content = _signInView ?? (_signInView = new SignInView());
                    Logger.Log("Navigate to SignIn");

                    break;
                case ModesEnum.SingUp:
                    _contentWindow.ContentControl.Content = _signUpView ?? (_signUpView = new SignUpView());
                    Logger.Log("Navigate to SignUp");

                    break;
                case ModesEnum.Main:
                    _contentWindow.ContentControl.Content = _mainView ?? (_mainView = new MainView());
                    Logger.Log("Navigate to Main");
                    break;
                default:
                    Logger.Log("Fail to Navigate: ArgumentOutOfRangeException");
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

    }
}