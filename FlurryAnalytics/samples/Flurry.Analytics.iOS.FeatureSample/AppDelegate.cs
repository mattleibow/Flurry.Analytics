using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Flurry.Analytics;

namespace Flurry.Analytics.iOS.FeatureSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		RootViewController rootViewController;

		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			FlurryAgent.SetAppVersion ("1.0.0.0");
			FlurryAgent.StartSession ("PQSZJRK4B5BW8Q7YQQXF");

			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			rootViewController = new RootViewController ();

			window.RootViewController = rootViewController;

			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

