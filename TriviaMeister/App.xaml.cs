using TriviaMeister.Services;
using TriviaMeister.Views;
using Xamarin.Forms;

namespace TriviaMeister
{
    public partial class App : Application
    {
        readonly AuthService _authService;

        public App()
        {
            InitializeComponent();
            _authService = new AuthService();
            var messageService = new MessageService();
            var userStore = new UserStore();
            var triviaStore = new TriviaStore();

            DependencyService.RegisterSingleton(messageService);
            DependencyService.RegisterSingleton(userStore);
            DependencyService.RegisterSingleton(triviaStore);
            DependencyService.RegisterSingleton(_authService);
        }

        protected override async void OnStart()
        {
            var user = await _authService.GetUser();

            if (user != null)
            {
                MainPage = new MainPage();
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
