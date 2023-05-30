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

        public bool IsEditing
        {
            get => _isEditing;
            set => _isEditing = value;
        }

        public ObservableCollection<TriviaItem> Items { get; set; }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command DeleteCommand { get; }

        public ModifyTriviaItemViewModel()
        {
            PageTitle = "Create Trivia Item";

            CancelCommand = new Command(OnCancel);
            SaveCommand = new Command(OnSave, ValidateSave);
            DeleteCommand = new Command(OnDelete);
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

        private async void OnDelete()
        {
            var item = Items.Where((TriviaItem t) => t.Id == Id).First();
            Items.Remove(item);

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
                    Answer = Answer
                });
            } 
            else
            {
                Items.Add(new TriviaItem()
                {
                    Prompt = Prompt,
                    Answer = Answer
                });
            }

            await Navigation.PopModalAsync();
        }
    }
}
