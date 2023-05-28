using TriviaMeister.Views;
using Xamarin.Forms;

namespace TriviaMeister
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TriviaDetailPage), typeof(TriviaDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
