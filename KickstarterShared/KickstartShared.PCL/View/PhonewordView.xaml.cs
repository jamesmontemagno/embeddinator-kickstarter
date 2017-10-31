using System;
using System.Collections.Generic;
using KickstarterShared.Interfaces;
using KickstarterShared.ViewModel;
using Xamarin.Forms;

namespace KickstartShared.Shared.View
{
    partial class PhonewordView : ContentPage
    {
        SuggestionViewModel vm;
        public PhonewordView()
        {
            InitializeComponent();
            BindingContext = vm = new SuggestionViewModel();
        }


        string translatedNumber;
        void OnTranslate(object sender, EventArgs e)
        {
            vm.Entered = phoneNumberText.Text;
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
