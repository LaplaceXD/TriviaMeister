using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaMeister.ViewModels;
using TriviaMeister.Models;

namespace TriviaMeister.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModifyTriviaItemPage : ContentPage
	{
		public ModifyTriviaItemPage(ObservableCollection<TriviaItem> items)
		{
			InitializeComponent();
			BindingContext = new ModifyTriviaItemViewModel(items)
			{
				Navigation = Navigation
			};
		}
	}
}