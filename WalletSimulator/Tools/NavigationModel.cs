using System;
using System.Windows;
using KMA.APZRPMJ2018.TextEditor.Views.Authentication;
using KMA.APZRPMJ2018.TextEditor.Views;
using SignUpView = KMA.APZRPMJ2018.TextEditor.Views.Authentication.SignUpView;

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
        private Views.Authentication.SignUpView _signUpView;
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
                    break;
                case ModesEnum.SingUp:
                    _contentWindow.ContentControl.Content = _signUpView ?? (_signUpView = new Views.Authentication.SignUpView());
                    break;
                case ModesEnum.Main:
                    _contentWindow.ContentControl.Content = _mainView ?? (_mainView = new MainView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

    }
}