using System;
using System.Collections.Generic;
using TriviaMeister.Models;
using Xamarin.Forms;

namespace TriviaMeister.ViewModels
{
    public class NewTriviaViewModel : BaseViewModel
    {
        private string _title;
        private string _description;
        private List<TriviaItem> _items = new List<TriviaItem>();

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public List<TriviaItem> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public NewTriviaViewModel()
        {
            PageTitle = "Create Trivia";

            SaveCommand = new Command(OnSave, ValidateSave);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(_title)
                && !string.IsNullOrWhiteSpace(_description);
        }

        private void Reset()
        {
            Title = string.Empty;
            Description = string.Empty;
            Items = new List<TriviaItem>();
        }

        private async void OnSave()
        {
            await TriviaStore.AddItemAsync(new Trivia()
            {
                Title = Title,
                Description = Description,
                Items = Items
            });

            Reset();
        }
    }
}
