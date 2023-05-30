using System.Collections.ObjectModel;
using System.Linq;
using TriviaMeister.Models;
using Xamarin.Forms;

namespace TriviaMeister.ViewModels
{
    public class ModifyTriviaItemViewModel : BaseViewModel
    {
        private string _prompt;
        private string _answer;
        private bool _caseSensitive = false;
        private bool _isEditing = false;

        public string Id { get; set; }

        public string Prompt
        {
            get => _prompt;
            set => SetProperty(ref _prompt, value);
        }

        public string Answer
        {
            get => _answer;
            set => SetProperty(ref _answer, value);
        }

        public bool CaseSensitive
        {
            get => _caseSensitive;
            set => SetProperty(ref _caseSensitive, value);
        }

        public bool IsEditing
        {
            get => _isEditing;
            set => _isEditing = value;
        }

        public ObservableCollection<TriviaItem> Items { get; }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public ModifyTriviaItemViewModel(ObservableCollection<TriviaItem> items)
        {
            PageTitle = "Create Trivia Item";
            Items = items;

            CancelCommand = new Command(OnCancel);
            SaveCommand = new Command(OnSave, ValidateSave);
            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(_prompt)
                && !string.IsNullOrWhiteSpace(_answer);
        }

        private async void OnCancel()
        {
            await Navigation.PopModalAsync();
        }

        private async void OnSave()
        {
            if(IsEditing)
            {
                var item = Items.Where((TriviaItem t) => t.Id == Id).First();
                var index = Items.IndexOf(item);

                Items.Remove(item);
                Items.Insert(index, new TriviaItem()
                {
                    Id = Id,
                    Prompt = Prompt,
                    Answer = Answer,
                    CaseSensitive = CaseSensitive
                });
            } 
            else
            {
                Items.Add(new TriviaItem()
                {
                    Prompt = Prompt,
                    Answer = Answer,
                    CaseSensitive = CaseSensitive
                });
            }

            await Navigation.PopModalAsync();
        }
    }
}
