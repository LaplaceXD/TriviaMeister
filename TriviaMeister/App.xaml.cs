using System;
using TriviaMeister.Services;
using TriviaMeister.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaMeister
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<TriviaStore>();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
