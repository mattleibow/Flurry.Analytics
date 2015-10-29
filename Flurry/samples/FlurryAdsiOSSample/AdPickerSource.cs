using System;
using UIKit;

namespace FlurryAdsiOSSample
{
	public class AdPickerSource : UIPickerViewDelegate, IUIPickerViewDataSource
	{
		public readonly string[] flurryAdSpaces;

		public AdPickerSource (string[] flurryAdSpaces)
		{
			this.flurryAdSpaces = flurryAdSpaces;
		}

		public nint GetComponentCount (UIPickerView pickerView)
		{
			return 1;
		}

		public nint GetRowsInComponent (UIPickerView pickerView, nint component)
		{
			return flurryAdSpaces.Length;
		}

		public override string GetTitle (UIPickerView pickerView, nint row, nint component)
		{
			return flurryAdSpaces [row];
		}

		public string Selected(UIPickerView picker)
		{
			var adTypeIx = picker.SelectedRowInComponent (0);
			return flurryAdSpaces [adTypeIx];
		}
	}
}
