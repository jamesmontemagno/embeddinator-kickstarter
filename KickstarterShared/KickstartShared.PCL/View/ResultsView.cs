using System;
using KickstarterShared.ViewModel;
using Xamarin.Forms;

namespace KickstarterShared.View
{
	public class ResultsView : ContentPage
	{
		SuggestionsViewModel _vm;

		public ResultsView()
		{
			BindingContext = _vm = new SuggestionsViewModel();

			Content = new StackLayout
			{
				Children = {
					new ListView {
						ItemsSource = _vm.Suggestions,
						ItemTemplate = new DataTemplate(() =>
						{
							// Create views with bindings for displaying each property.
							Label nameLabel = new Label();
							nameLabel.SetBinding(Label.TextProperty, "Title");

							// Return an assembled ViewCell.
							return new ViewCell
							{
								View = new StackLayout
								{
									Padding = new Thickness(0, 5),
									Orientation = StackOrientation.Horizontal,
									Children = 
									{
										new StackLayout
										{
											VerticalOptions = LayoutOptions.Center,
											Spacing = 0,
											Children = 
											{
												nameLabel
									
											}
										}
									}
								}
							};
						}) // end datatemplate
					}
				}
			};
		}
	}
}

