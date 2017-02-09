using System;
using System.ComponentModel;
using Android.Graphics;
using CustomFont.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace CustomFont.Droid.Renderers
{
	public class CustomButtonRenderer: ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			if (Element == null)
				return;

			if (Control == null)
				return;

			ChangeFont();
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (Element == null)
				return;

			if (Control == null)
				return;


			if (e.PropertyName == Button.FontFamilyProperty.PropertyName)
			{
				ChangeFont();
			}
		}

		private void ChangeFont()
		{
			Control.TransformationMethod = (null);
			var typeface = string.IsNullOrEmpty(Element.FontFamily) ?
				Typeface.Default :
				FontManager.Current.GetTypeface(Element.FontFamily);
			Control.Typeface = typeface;
		}
	}
}
