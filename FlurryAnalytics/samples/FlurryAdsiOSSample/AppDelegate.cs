using Foundation;
using UIKit;

using Flurry.Analytics;
using Flurry.Ads;

namespace FlurryAdsiOSSample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow Window { get; set; }

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
#if DEBUG
			// enable test ads
			FlurryAds.EnableTestAds (true);
#endif

			FlurryAgent.StartSession ("PQSZJRK4B5BW8Q7YQQXF");

			FlurryAgent.SetDebugLogEnabled (true);
			FlurryAgent.SetLogLevel (FlurryLogLevel.All);

			Window.MakeKeyAndVisible ();

			return true;
		}
	}
}
