﻿using System.Windows;
using KMA.APZRPMJ2018.TextEditor.Tools;

namespace KMA.APZRPMJ2018.TextEditor.Managers
{
    public class LoaderManager
    {
        #region static
        private static readonly object Lock = new object();
        private static LoaderManager _instance;

        public static LoaderManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Lock)
                {
                    return _instance = new LoaderManager();
                }
            }
        }
        #endregion
        private ILoaderOwner _loaderOwner;

        public void Initialize(ILoaderOwner loaderOwner)
        {
            _loaderOwner = loaderOwner;
        }

        public void ShowLoader()
        {
            _loaderOwner.LoaderVisibility = Visibility.Visible;
            _loaderOwner.IsEnabled = false;

        }

        public void HideLoader()
        {
            _loaderOwner.LoaderVisibility = Visibility.Hidden;
            _loaderOwner.IsEnabled = true;
        }
    }
}
