// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace Flurry.Analytics.iOS.Sample
{
	[Register ("Flurry_Analytics_iOS_SampleViewController")]
	partial class Flurry_Analytics_iOS_SampleViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField EventParameterText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton LogEventButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel VersionLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (EventParameterText != null) {
				EventParameterText.Dispose ();
				EventParameterText = null;
			}
			if (LogEventButton != null) {
				LogEventButton.Dispose ();
				LogEventButton = null;
			}
			if (VersionLabel != null) {
				VersionLabel.Dispose ();
				VersionLabel = null;
			}
		}
	}
}
