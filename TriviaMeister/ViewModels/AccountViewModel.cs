using TriviaMeister.Views;
using Xamarin.Forms;

namespace TriviaMeister.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public string Name { get; private set; }
        public Command SignOut { get; }

        public AccountViewModel()
        {
            PageTitle = "Account";
            LoadAccount();

            SignOut = new Command(OnSignOut);
        }

        private async void LoadAccount()
        {
            var user = await AuthService.GetUser();
            Name = user.Name;
        }

        private async void OnSignOut()
        {
            var isSuccessful = await AuthService.SignOutAsync();

            if(isSuccessful)
            {
                await MessageService.ShowAsync("Sign Out", "You have signed out.", "Confirm");
                App.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                await MessageService.ShowAsync("Error", "An error occurred while signing out.", "Confirm");
            }
        }
    }
}