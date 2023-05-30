using System;
using System.Collections.Generic;
using System.Text;
using TriviaMeister.Views;
using Xamarin.Forms;

namespace TriviaMeister.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        private string _password;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            if (string.IsNullOrEmpty(Email))
            {
                await MessageService.ShowAsync("Required", "Email is required.", "Ok");
                return;
            }
            else if (string.IsNullOrEmpty(Password))
            {
                await MessageService.ShowAsync("Required", "Password is required.", "Ok");
                return;
            }

            var isSuccessful = await AuthService.SignInAsync(Email, Password);
            if(!isSuccessful)
            {
                await MessageService.ShowAsync("Invalid", "Invalid credentials.", "Ok");
                return;
            }

            // Fix this code to push to a new stack, instead of using the current navigation stack
            await Navigation.PushAsync(new AboutPage());
        }
    }
}
