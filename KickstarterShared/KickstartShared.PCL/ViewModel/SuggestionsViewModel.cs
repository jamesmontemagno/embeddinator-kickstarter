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
				Title = "Starbucks"
			},
			new Suggestion {
				Title = "Peets"
			},
			new Suggestion {
				Title = "Kaldis"
			},
			new Suggestion {
				Title = "Mississippi Mud"
			},
			new Suggestion {
				Title = "Clover"
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
