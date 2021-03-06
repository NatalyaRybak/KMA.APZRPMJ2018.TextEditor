﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using KMA.APZRPMJ2018.TextEditor.Properties;
using KMA.APZRPMJ2018.TextEditor.Tools;
using KMA.APZRPMJ2018.TextEditor.Managers;
using KMA.APZRPMJ2018.TextEditor.Models;
using System.Threading.Tasks;

namespace KMA.APZRPMJ2018.TextEditor.ViewModels.Authentication
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _password;
        private string _login;

        #region Commands
        private ICommand _closeCommand;
        private ICommand _signInCommand;
        private ICommand _signUpCommand;
        #endregion
        #endregion

        #region Properties
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        #region Commands

        public ICommand CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute));

        public ICommand SignInCommand => _signInCommand ?? (_signInCommand = new RelayCommand<object>(SignInExecute, SignInCanExecute));

        public ICommand SignUpCommand => _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(SignUpExecute));

        #endregion
        #endregion

        #region ConstructorAndInit
        internal SignInViewModel()
        {
        }
        #endregion

        private void SignUpExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.SingUp);
        }

        private async void SignInExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                User currentUser;
                try
                {
                    currentUser = DbManager.GetUserByLogin(_login);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format(Resources.SignIn_FailedToGetUser, Environment.NewLine,
                        ex.Message));
                    Logger.Log($"SignIn_FailedToGetUser",ex);

                    return false;
                }
                if (currentUser == null)
                {
                    MessageBox.Show(String.Format(Resources.SignIn_UserDoesntExist, _login));
                    Logger.Log("SignIn_UserDoesntExist");

                    return false;
                }
                try
                {
                    if (!currentUser.CheckPassword(_password))
                    {
                        MessageBox.Show(Resources.SignIn_WrongPassword);
                        Logger.Log("SignIn_WrongPassword");

                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format(Resources.SignIn_FailedToValidatePassword, Environment.NewLine,
                        ex.Message));
                    Logger.Log("SignIn_FailedToValidatePassword",ex);

                    return false;
                }
                StationManager.CurrentUser = currentUser;
                SerializationManager.Serialize(StationManager.CurrentUser, FileFolderHelper.LastUserFilePath);

                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                Login = string.Empty;
                Password = string.Empty;
                NavigationManager.Instance.Navigate(ModesEnum.Main);
            }
        }

        private bool SignInCanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login) && !String.IsNullOrWhiteSpace(_password);
        }

        private void CloseExecute(object obj)
        {
            StationManager.CloseApp();
        }

        #region EventsAndHandlers
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}
