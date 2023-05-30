using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TriviaMeister.Models;
using TriviaMeister.Views;
using Xamarin.Forms;

namespace TriviaMeister.ViewModels
{
    public class TriviaDetailViewModel : BaseViewModel
    {
        private string _id;
        private string _triviaId;
        private string _title;
        private string _description;
        private List<TriviaItem> _items;
        
        public string Id 
        { 
            get => _id; 
            set => SetProperty(ref _id, value); 
        }

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

        public string TriviaId
        {
            get
            {
                return _triviaId;
            }
            set
            {
                _triviaId = value;
                LoadTriviaById(value);
            }
        }

        public Command DeleteCommand { get; }
        public Command EditCommand { get; }
        public Command<TriviaItem> TriviaItemTapped { get; }

        public TriviaDetailViewModel()
        {
            DeleteCommand = new Command(OnDelete);
            EditCommand = new Command(OnEdit);
            TriviaItemTapped = new Command<TriviaItem>(OnTriviaItemTapped);
        }

        public async void LoadTriviaById(string triviaId)
        {
            try
            {
                var trivia = await TriviaStore.GetItemAsync(triviaId);
                Id = trivia.Id;
                Title = trivia.Title;
                Description = trivia.Description;
                Items = trivia.Items;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Trivia");
            }
        }

        private async void OnEdit()
        {
            await Navigation.PushAsync(new ModifyTriviaPage()
            {
                BindingContext = new ModifyTriviaViewModel()
                {
                    Id = Id,
                    Title = Title,
                    Description = Description,
                    Items = new ObservableCollection<TriviaItem>(Items),
                    IsEditing = true,
                    Navigation = Navigation,
                    RefreshParent = () => LoadTriviaById(Id)
                }
            });
        }

        private async void OnDelete()
        {
            var result = await MessageService.PromptAsync("Delete Trivia", $"Are you sure you want to delete {Title}?", "Yes", "No");

            if (result)
            {
                await TriviaStore.DeleteItemAsync(Id);

                await MessageService.ShowAsync("Trivia Deleted", $"{Title} deleted successfully.", "Confirm");
                await Navigation.PopAsync();
            }
        }

        private async void OnTriviaItemTapped(TriviaItem item)
        {
            await MessageService.ShowAsync($"{item.Prompt}", $"{item.Answer}", "Got it!");
        }
    }
}
