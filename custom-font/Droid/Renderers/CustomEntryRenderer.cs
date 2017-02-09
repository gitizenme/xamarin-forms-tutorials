using System;
using System.ComponentModel;
using Android.Graphics;
using CustomFont.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace CustomFont.Droid.Renderers
{
	public class CustomEntryRenderer: EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
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
			
			if (e.PropertyName == Entry.FontFamilyProperty.PropertyName)
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
