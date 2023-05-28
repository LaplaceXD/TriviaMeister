﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using TriviaMeister.Models;
using Xamarin.Forms;

namespace TriviaMeister.ViewModels
{
    [QueryProperty(nameof(TriviaId), nameof(TriviaId))]
    public class TriviaDetailViewModel : BaseViewModel
    {
        private string _triviaId;
        private string _title;
        private string _description;
        private List<TriviaItem> _items;
        public string Id { get; set; }

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