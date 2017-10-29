using System;

using Xamarin.Forms;

namespace KickstarterShared.View
{
    class SuggestionView : ContentPage
    {
        public SuggestionView()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

