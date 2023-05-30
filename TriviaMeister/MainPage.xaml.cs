using Xamarin.Forms;
using TriviaMeister.ViewModels;

namespace TriviaMeister
{
    public partial class MainPage : TabbedPage
    {
        public MainPage() 
        {
            InitializeComponent();
            var pages = Children.GetEnumerator();
            pages.MoveNext(); // ModifyTriviaItemPage
            pages.Current.BindingContext = new ModifyTriviaViewModel()
            {
                PageTitle = "Create Trivia",
                Navigation = pages.Current.Navigation
            };

            pages.MoveNext(); // TriviasPage
            CurrentPage = pages.Current; // Set it as the main page
        }
    }
}
