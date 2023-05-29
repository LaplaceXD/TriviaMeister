using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaMeister.ViewModels;

namespace TriviaMeister.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TriviaDetailPage : ContentPage
	{
		public string TriviaId { get; set; }
		public TriviaDetailPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new TriviaDetailViewModel()
            {
                TriviaId = TriviaId
            };
        }
    }
}