using System;
using KickstarterShared.View;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace KickstarterShared
{

    public class SuggestionViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Xamarin.Forms.Forms.Init();
            View = new SuggestionView().CreateViewController().View;

        }
    }
}
