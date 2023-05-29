using System;
using System.Collections.Generic;
using System.Text;
using TriviaMeister.Views;
using Xamarin.Forms;

namespace TriviaMeister.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Fix this code to push to a new stack, instead of using the current navigation stack
            await Navigation.PushAsync(new AboutPage());
        }
    }
}
