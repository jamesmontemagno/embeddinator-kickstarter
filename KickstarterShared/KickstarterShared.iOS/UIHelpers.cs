using System;
using System.Linq;
using Foundation;
using KickstarterShared.View;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace KickstarterShared
{

	public class SuggestionHelper
	{

		Page view, view2;
		public SuggestionHelper()
		{
			Xamarin.Forms.Forms.Init();
			view = new SuggestionsView();
			(view as SuggestionsView).GoBack += HandleGoBack;
		}

		private void HandleGoBack(object sender, EventArgs e)
		{
			var vc = GetVisibleViewController();
			vc.DismissViewController(true, () => { });
		}

		public void ShowSuggestionView()
		{
			var controller = view.CreateViewController();
			var vc = GetVisibleViewController();

			vc.PresentViewController(controller, true, () => { });
		}
		 
		UIViewController GetVisibleViewController()
		{
			UIViewController viewController = null;
			var window = UIApplication.SharedApplication.KeyWindow;


			if (window != null && window.WindowLevel == UIWindowLevel.Normal)
				viewController = window.RootViewController;

			if (viewController == null)
			{
				window = UIApplication.SharedApplication.Windows.OrderByDescending(w => w.WindowLevel).FirstOrDefault(w => w.RootViewController != null && w.WindowLevel == UIWindowLevel.Normal);
				if (window == null)
					throw new InvalidOperationException("Could not find current view controller");
				else
					viewController = window.RootViewController;
			}

			while (viewController.PresentedViewController != null)
				viewController = viewController.PresentedViewController;


			return viewController;
		}
	}

	//public class SuggestionViewController : UIViewController
	//{
	//    public override void ViewDidLoad()
	//    {
	//        base.ViewDidLoad();
	//        Xamarin.Forms.Forms.Init();
	//        View = new SuggestionsView().CreateViewController().View;

	//    }
	//}
}
