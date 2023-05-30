﻿using System.Collections.ObjectModel;
using System.Linq;
using TriviaMeister.Models;
using TriviaMeister.Views;
using Xamarin.Forms;

namespace TriviaMeister.ViewModels
{
    public class NewTriviaViewModel : BaseViewModel
    {
        private string _title;
        private string _description;
        private ObservableCollection<TriviaItem> _items = new ObservableCollection<TriviaItem>();

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

        public ObservableCollection<TriviaItem> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public Command SaveCommand { get; }
        public Command ClearCommand { get; }
        public Command AddTriviaItemCommand { get; }
        public Command<TriviaItem> TriviaItemSelected { get; }

        public NewTriviaViewModel()
        {
            PageTitle = "Create Trivia";

            SaveCommand = new Command(OnSave, ValidateSave);
            ClearCommand = new Command(Reset);
            AddTriviaItemCommand = new Command(OnTrivaItemAdd);
            TriviaItemSelected = new Command<TriviaItem>(OnTriviaItemSelected);
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
            Items.Clear();
        }

        private async void OnSave()
        {
            await TriviaStore.AddItemAsync(new Trivia()
            {
                Title = Title,
                Description = Description,
                Items = Items.ToList()
            });

            Reset();
        }

        private async void OnTrivaItemAdd()
        {
            await Navigation.PushModalAsync(new ModifyTriviaItemPage()
            {
                BindingContext = new ModifyTriviaItemViewModel(_items)
                {
                    Navigation = Navigation
                }
            });
        }

        private async void OnTriviaItemSelected(TriviaItem item)
        {
            await Navigation.PushModalAsync(new ModifyTriviaItemPage()
            {
                BindingContext = new ModifyTriviaItemViewModel(_items)
                {
                    Id = item.Id,
                    Prompt = item.Prompt,
                    Answer = item.Answer,
                    Navigation = Navigation,
                    IsEditing = true
                }
            });
        }
    }
}
