using System;
using System.Collections.Generic;
using System.Diagnostics;
using TriviaMeister.Models;
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

        public async void LoadTriviaById(string triviaId)
        {
            try
            {
                Debug.WriteLine(triviaId);
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
    }
}
