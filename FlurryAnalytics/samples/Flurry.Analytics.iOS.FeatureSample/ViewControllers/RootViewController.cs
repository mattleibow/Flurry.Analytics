using System;
using System.Collections.Generic;
using System.Diagnostics;

using MonoTouch.CoreLocation;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

using Flurry.Analytics;

namespace Flurry.Analytics.iOS.FeatureSample
{
	public class RootViewController : UINavigationController
	{
		AnalyticsViewController analyticsController;

		public RootViewController ()
			: base ()
		{
		}

		public override void LoadView ()
		{
			base.LoadView ();

			FlurryAgent.LogAllPageViewsForTarget (this);

			analyticsController = new AnalyticsViewController ();	
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			PushViewController (analyticsController, true);
		}

		public override void ViewWillLayoutSubviews ()
		{
			base.ViewWillLayoutSubviews ();
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			CLLocationManager locationManager = new CLLocationManager ();
			locationManager.LocationsUpdated += (sender, e) => {
				CLLocation location = locationManager.Location;
				FlurryAgent.SetLocation (
					location.Coordinate.Latitude,
					location.Coordinate.Longitude,
					(float)location.HorizontalAccuracy,
					(float)location.VerticalAccuracy);
				locationManager.StopUpdatingLocation ();

				Debug.WriteLine ("Logged location.");
			};
			locationManager.StartUpdatingLocation ();
		}

		public override void PushViewController (UIViewController viewController, bool animated)
		{
			FlurryAgent.LogEvent (string.Format ("Pushed ViewController with Name: {0}", viewController.GetType ().Name));

			base.PushViewController (viewController, animated);
		}
	}
}

