using Foundation;
using UIKit;

using Flurry.Tumblr;

namespace FlurryTumblriOSSample
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
			FlurryTumblr.SetConsumerKey ("EzSiK7715joH2hhghNaRUEXzgRAz4IybhHhJx3aPmuZ2m3TSba", "R7vQvwcJ7aK2xQ0eDQCCF1R6pjMGmx2QANS0HQgDnCaT6XCQXt");

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

