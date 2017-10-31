using System;
using KickstarterShared.Interfaces;
using KickstarterShared.ViewModel;
using Xamarin.Forms;

namespace KickstarterShared.View
{
    public class SuggestionView : ContentPage
    {
        void CallButton_Clicked(object sender, EventArgs e)
        {

        }



        SuggestionViewModel vm;
        Button callButton, translateButton;
        Entry phoneNumberText;
        public SuggestionView()
        {
            BindingContext = vm = new SuggestionViewModel();

            Content = new StackLayout
            {
                Padding=new Thickness(40),
                Children = 
                {
                    new Label { Text = "Enter a Phoneword:" },
                    (phoneNumberText = new Entry
                    {
                        Text ="1-855-XAMARIN"
                    }),
                    (callButton = new Button
                    {
                        Text = "Call"
                    }),
                    (translateButton = new Button
                    {
                        Text = "Translate" 
                    })
 
                }
            };

            callButton.Clicked += OnCall;
            translateButton.Clicked += OnTranslate;
        }
        string translatedNumber;
        void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = vm.ToNumber();
            if (!string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }

        async void OnCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                    "Dial a Number",
                    "Would you like to call " + translatedNumber + "?",
                    "Yes",
                    "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                    dialer.Dial(translatedNumber);
            }
        }
    }
}

