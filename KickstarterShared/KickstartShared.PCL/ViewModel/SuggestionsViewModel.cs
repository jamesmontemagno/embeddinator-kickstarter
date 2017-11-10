using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using KickstarterShared.Model;

namespace KickstarterShared.ViewModel
{
	public class SuggestionsViewModel : BaseViewModel
	{
		private List<Suggestion> _suggestions = new List<Suggestion>(){
			new Suggestion {
				Title = "La Colombe Coffee",
				Price = "$$",
				Distance = "0.1 Miles",
				Rating = 4.0,
				Photo = "https://blog.xamarin.com/wp-content/uploads/2017/11/MSC16_fulcrum_036.jpg"
			},
			new Suggestion {
				Title = "Jack’s Stir Brew Coffee",
				Price = "$$",
				Distance = "0.1 Miles",
				Rating = 4.5,
				Photo = "https://blog.xamarin.com/wp-content/uploads/2017/11/MSC17_fastFolks_009.jpg"
			},
			new Suggestion {
				Title = "Prologue Coffee Room",
				Price = "$",
				Distance = "0.3 Miles",
				Rating = 4.5,
				Photo = "https://blog.xamarin.com/wp-content/uploads/2017/11/MSC16_fulcrum_029.jpg"
			},
			new Suggestion {
				Title = "Bell’s Coffee & Design",
				Price = "$$",
				Distance = "0.2 Miles",
				Rating = 4.5,
				Photo = "https://blog.xamarin.com/wp-content/uploads/2017/11/MSC16_fulcrum_031.jpg"
			},
			new Suggestion {
				Title = "Everyman Espresso",
				Price = "$$",
				Distance = "0.09 Miles",
				Rating = 4.0,
				Photo = "https://blog.xamarin.com/wp-content/uploads/2017/11/OFC16_Andre_004.jpg"
			},
			new Suggestion {
				Title = "Zibetto",
				Price = "$$",
				Distance = "0.05 Miles",
				Rating = 5.0,
				Photo = "https://blog.xamarin.com/wp-content/uploads/2017/11/MSC16_fulcrum_025.jpg"
			}
		};

		public List<Suggestion> Suggestions
		{
			get{
				return _suggestions;
			}
			set {
				_suggestions = value;
				SetProperty(ref _suggestions, value);


			}
		}

	}
}
