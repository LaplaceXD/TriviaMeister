using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TriviaMeister.Models;
using TriviaMeister.Views;
using Xamarin.Forms;

namespace TriviaMeister.ViewModels
{
    public class TriviasViewModel : BaseViewModel
    {
        private Trivia _selectedTrivia;

        public ObservableCollection<Trivia> Trivias { get; }
        public Command LoadTriviasCommand { get; }
        public Command<Trivia> TriviaTapped { get; }
        public Trivia SelectedTrivia
        {
            get => _selectedTrivia;
            set
            {
                SetProperty(ref _selectedTrivia, value);
                OnTriviaSelected(value);
            }
        }

        public TriviasViewModel()
        {
            PageTitle = "Browse";
            Trivias = new ObservableCollection<Trivia>();

            LoadTriviasCommand = new Command(async () => await OnTriviasLoad());
            TriviaTapped = new Command<Trivia>(OnTriviaSelected);
        }

        async Task OnTriviasLoad()
        {
            IsBusy = true;

            try
            {
                Trivias.Clear();
                var trivias = await TriviaStore.GetItemsAsync(true);
                foreach (var trivia in trivias)
                {
                    Trivias.Add(trivia);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedTrivia = null;
        }

        async void OnTriviaSelected(Trivia trivia)
        {
            if (trivia == null) return;
            
            await Navigation.PushAsync(new TriviaDetailPage()
            {
                TriviaId = trivia.Id
            });
        }
    }
}
