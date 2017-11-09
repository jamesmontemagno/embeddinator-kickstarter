using System;
using KickstarterShared.View;
using Xamarin.Forms;

namespace KickstartShared.Shared
{
	public class App : Application
	{
		public App()
		{
			MainPage = new SuggestionsView();
		}
	}
}
