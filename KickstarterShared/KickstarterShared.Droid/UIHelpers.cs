using System;
using Android.Content;
using Android.Support.V4.App;
using KickstarterShared.View;
using Xamarin.Forms.Platform.Android;

namespace KickstarterShared
{
    public class SuggestionFragment
    {
        public Fragment CreateFragment(Context context) =>
            new SuggestionView().CreateSupportFragment(context);
    }
}
