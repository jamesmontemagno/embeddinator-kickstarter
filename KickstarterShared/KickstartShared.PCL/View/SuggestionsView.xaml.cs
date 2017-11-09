using System;
using System.Collections.Generic;
using KickstarterShared.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace KickstarterShared.View
{
	public partial class SuggestionsView : ContentPage
	{
		SuggestionsViewModel _vm;

		public event EventHandler GoBack;

		public SuggestionsView()
		{
			BindingContext = _vm = new SuggestionsViewModel();

			On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

			InitializeComponent();
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			EventHandler handler = GoBack;   

			if (handler != null)
			{
				// invoke the subscribed event-handler(s)
				handler(this, EventArgs.Empty);  
			}
		}

	}
}
