using TriviaMeister.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaMeister.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TriviasPage : ContentPage
	{
		readonly TriviasViewModel _viewModel;

		public TriviasPage ()
		{
			InitializeComponent ();

			BindingContext = _viewModel = new TriviasViewModel();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
			_viewModel.OnAppearing();
        }
    }
}