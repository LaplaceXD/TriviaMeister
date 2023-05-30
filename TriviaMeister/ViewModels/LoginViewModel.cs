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
        public Command RegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnLoginClicked()
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

            App.Current.MainPage = new MainPage();
        }

        private async void OnRegisterClicked()
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
