using TriviaMeister.Services;
using Xamarin.Forms;

namespace TriviaMeister
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var authService = new AuthService();
            var messageService = new MessageService();
            var userStore = new UserStore();
            var triviaStore = new TriviaStore();

            DependencyService.RegisterSingleton(messageService);
            DependencyService.RegisterSingleton(userStore);
            DependencyService.RegisterSingleton(triviaStore);
            DependencyService.RegisterSingleton(authService);

            MainPage = new MainPage();
        }
    }
}
