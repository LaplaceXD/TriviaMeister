using TriviaMeister.Services;
using Xamarin.Forms;

namespace TriviaMeister
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<TriviaStore>();
            MainPage = new MainPage();
        }
    }
}
