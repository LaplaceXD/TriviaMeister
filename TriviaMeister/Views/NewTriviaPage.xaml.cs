using TriviaMeister.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaMeister.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTriviaPage : ContentPage
    {
        public NewTriviaPage()
        {
            InitializeComponent();
            BindingContext = new NewTriviaViewModel() 
            {
                Navigation = Navigation
            };
        }
    }
}