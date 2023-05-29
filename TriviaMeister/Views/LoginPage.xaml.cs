using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaMeister.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaMeister.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel()
            {
                Navigation = Navigation
            };
        }
    }
}