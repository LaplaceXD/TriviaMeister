using System.ComponentModel;
using TriviaMeister.ViewModels;
using Xamarin.Forms;

namespace TriviaMeister.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}