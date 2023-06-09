﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TriviaMeister.Models;
using TriviaMeister.Services;
using Xamarin.Forms;

namespace TriviaMeister.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Trivia> TriviaStore => DependencyService.Get<IDataStore<Trivia>>();
        public IDataStore<User> UserStore => DependencyService.Get<IDataStore<User>>();
        public IMessageService MessageService => DependencyService.Get<IMessageService>();
        public IAuthService AuthService => DependencyService.Get<IAuthService>();

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private string _pageTitle = string.Empty;
        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetProperty(ref _pageTitle, value); }
        }

        private INavigation _navigation;
        public INavigation Navigation
        {
            get { return _navigation; }
            set { _navigation = value; }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
