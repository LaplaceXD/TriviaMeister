using System;
using System.Collections.Generic;
using System.ComponentModel;
using TriviaMeister.Models;
using TriviaMeister.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaMeister.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}