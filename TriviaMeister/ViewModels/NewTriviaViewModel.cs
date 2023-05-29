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
        private List<TriviaItem> _items;

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
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_title)
                && !String.IsNullOrWhiteSpace(_description);
        }

        private async void OnCancel()
        {
            await Navigation.PopAsync();
        }

        private async void OnSave()
        {
            await TriviaStore.AddItemAsync(new Trivia()
            {
                Title = Title,
                Description = Description,
                Items = Items
            });

            await Navigation.PopAsync();
        }
    }
}
