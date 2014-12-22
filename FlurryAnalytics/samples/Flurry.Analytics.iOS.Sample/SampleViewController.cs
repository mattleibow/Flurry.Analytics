using System;
using System.Collections.Generic;
using System.Drawing;

#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

using Flurry.Analytics;

namespace Flurry.Analytics.iOS.Sample
{
	public partial class SampleViewController : UIViewController
	{
		public SampleViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			VersionLabel.Text = FlurryAgent.GetFlurryAgentVersion ();

			LogEventButton.TouchUpInside += delegate {
				if (string.IsNullOrEmpty (EventParameterText.Text))
					FlurryAgent.LogEvent("Button Click");
				else
					FlurryAgent.LogEvent("Button Click", NSDictionary.FromObjectAndKey(
						new NSString (EventParameterText.Text), 
						new NSString ("Log Parameter")));

				using (UIAlertView alert = new UIAlertView("Event Logged", "Your event was logged along with the specified parameter.", null, "OK", null))
					alert.Show();
			};
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion
	}
}

