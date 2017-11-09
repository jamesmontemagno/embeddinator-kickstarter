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
				Title = "Starbucks",
				Photo = "https://blog.xamarin.com/wp-content/uploads/2017/11/MSC16_fulcrum_036.jpg"
			},
			new Suggestion {
				Title = "Peets",
				Photo = "https://blog.xamarin.com/wp-content/uploads/2017/11/MSC17_fastFolks_009.jpg"
			},
			new Suggestion {
				Title = "Kaldis",
				Photo = "https://blog.xamarin.com/wp-content/uploads/2017/11/MSC16_fulcrum_029.jpg"
			},
			new Suggestion {
				Title = "Mississippi Mud",
				Photo = "https://blog.xamarin.com/wp-content/uploads/2017/11/MSC16_fulcrum_031.jpg"
			},
			new Suggestion {
				Title = "Clover",
				Photo = "https://blog.xamarin.com/wp-content/uploads/2017/11/OFC16_Andre_004.jpg"
			},
			new Suggestion {
				Title = "Clover",
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
