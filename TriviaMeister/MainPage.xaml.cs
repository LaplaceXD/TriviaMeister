﻿using Xamarin.Forms;

namespace TriviaMeister
{
    public partial class MainPage : TabbedPage
    {
        public MainPage() 
        {
            InitializeComponent();
            var pages = Children.GetEnumerator();
            pages.MoveNext(); // First page
            pages.MoveNext(); // Second page
            CurrentPage = pages.Current;
        }
    }
}
