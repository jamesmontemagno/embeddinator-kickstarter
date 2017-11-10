using System;
using System.Linq;
using Xamarin.Forms;

namespace KickstartShared.Shared.Effects
{
	public static class ImageTint
	{
		public static readonly BindableProperty TintColorProperty = BindableProperty.CreateAttached("TintColor", typeof(Color), typeof(ImageTint), Color.Default, propertyChanged: OnTintColorChanged);

		private static void OnTintColorChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var view = bindable as View;
			if (view == null)
				return;

			Color color = (Color)newValue;
			var attachedEffect = view.Effects.FirstOrDefault(e => e is ImageTintEffect);
			if (color != null && attachedEffect == null)
			{
				view.Effects.Add(new ImageTintEffect());
			}
			else if (color == null && attachedEffect != null)
			{
				view.Effects.Remove(attachedEffect);
			}
		}

		public static Color GetTintColor(BindableObject view)
		{
			return (Color)view.GetValue(TintColorProperty);
		}

		public static void SetTintColorAmount(BindableObject view, Color color)
		{
			view.SetValue(TintColorProperty, color);
		}
	}

	public class ImageTintEffect : RoutingEffect
	{
		public ImageTintEffect() : base(typeof(ImageTintEffect).FullName)
		{
		}
	}
}
