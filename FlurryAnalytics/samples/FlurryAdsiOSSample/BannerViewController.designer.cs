// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FlurryAdsiOSSample
{
	[Register ("BannerViewController")]
	partial class BannerViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIPickerView adTypePicker { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton showAd { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel statusLbl { get; set; }

		[Action ("showAdClickedButton:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void showAdClickedButton (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (adTypePicker != null) {
				adTypePicker.Dispose ();
				adTypePicker = null;
			}
			if (showAd != null) {
				showAd.Dispose ();
				showAd = null;
			}
			if (statusLbl != null) {
				statusLbl.Dispose ();
				statusLbl = null;
			}
		}
	}
}
