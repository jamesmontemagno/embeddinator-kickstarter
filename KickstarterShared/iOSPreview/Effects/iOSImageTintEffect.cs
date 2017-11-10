using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using RoutingEffects = KickstartShared.Shared.Effects;
using PlatformEffects = iOSPreview.Effects;
using System.ComponentModel;
using UIKit;

[assembly: ResolutionGroupName("KickstartShared.Shared.Effects")]
[assembly: ExportEffect(typeof(PlatformEffects.iOSImageTintEffect), nameof(RoutingEffects.ImageTintEffect))]
namespace iOSPreview.Effects
{
	public class iOSImageTintEffect : PlatformEffect
	{
		protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(args);

			var visualElement = Element as VisualElement;
			if (args.PropertyName == nameof(visualElement.Width) || args.PropertyName == nameof(visualElement.Height))
			{
				var color = (Color)Element.GetValue(RoutingEffects.ImageTint.TintColorProperty);

				if(Control != null)
				{
					(Control as UIImageView).TintColor = color.ToUIColor();
				}
			}
		}

		protected override void OnAttached()
		{
		}

		protected override void OnDetached()
		{
		}
	}
}