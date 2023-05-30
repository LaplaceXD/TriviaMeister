using Xamarin.Forms;
using TriviaMeister.ViewModels;

namespace TriviaMeister.Views
{
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
            BindingContext = new AccountViewModel();
        }
    }
}