using TriviaMeister.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaMeister.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage()
		{
			InitializeComponent();
			BindingContext = new RegisterViewModel()
			{
				Navigation = Navigation
			};
		}
	}
}