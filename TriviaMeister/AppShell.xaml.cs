using System;
using System.Collections.Generic;
using TriviaMeister.ViewModels;
using TriviaMeister.Views;
using Xamarin.Forms;

namespace TriviaMeister
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
