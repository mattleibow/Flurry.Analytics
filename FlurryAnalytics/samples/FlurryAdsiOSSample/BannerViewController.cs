using System;
using UIKit;

using Flurry.Ads;
using Flurry.Ads.Banner;

namespace FlurryAdsiOSSample
{
	partial class BannerViewController : UIViewController
	{
		private FlurryAdBanner adBanner;
		private AdPickerSource pickerSource;

		public BannerViewController (IntPtr handle)
			: base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//  the sample points to a number of different ad spaces - each is configured with different settings on the dev.flurry.com
			//  integration for each banner ad is the same regardless of the configuration on the server side.
			//  all the entities in flurryAdSpaces refer to the ad space configured on dev.flurry.com
			//  under Publishers tab, left-hand nav Inventory / Ad Spaces

			pickerSource = new AdPickerSource (new[] {
				"Banner",
				"BannerTop",
				"BannerRich",
				"BannerTopRich"
			});
			adTypePicker.DataSource = pickerSource;
			adTypePicker.Delegate = pickerSource;

			showAd.Layer.BorderWidth = 0.5f;
			showAd.Layer.BorderColor = UIColor.Gray.CGColor;
			showAd.Layer.CornerRadius = 10;

			// Fetch and display banner ad for a given ad space.
			// Note: Choose an adspace name that
			// will uniquely identifiy the ad's placement within your app
			showAdClickedButton (null);
		}

		private void FetchAndDisplay (string  adspaceName)
		{
			adBanner = new FlurryAdBanner (adspaceName);

#if DEBUG
			// enable test ads
			var targeting = FlurryAdTargeting.Targeting;
			targeting.TestAdsEnabled = true;
			adBanner.Targeting = targeting;
#endif

			adBanner.DidFetchAd += delegate {
				Console.WriteLine (" Ad Space [{0}] Did Fetch Ad ===== ", adBanner.Space);
				statusLbl.Text = "Ad fetched for " + adBanner.Space;
				adBanner.DisplayAdInView (View, this);
			};
			adBanner.DidRenderAd += delegate {
				Console.WriteLine (" Ad Space [{0}] Did Render Ad ===== ", adBanner.Space);
				statusLbl.Text = "Ad displayed for " + adBanner.Space;
			};
			adBanner.WillPresentFullscreen += delegate {
				Console.WriteLine (" Ad Space [{0}] Will Present Fullscreen Ad ===== ", adBanner.Space);
			};
			adBanner.DidReceiveClick += delegate {
				Console.WriteLine (" Ad Space [{0}] Did Receive Click Ad ===== ", adBanner.Space);
			};
			adBanner.DidDismissFullscreen += delegate {
				Console.WriteLine (" Ad Space [{0}] Did Dismiss Fullscreen Ad ===== ", adBanner.Space);
			};
			adBanner.WillLeaveApplication += delegate {
				Console.WriteLine (" Ad Space [{0}] Will Leave Application ===== ", adBanner.Space);
			};
			adBanner.DidFinishVideo += delegate {
				Console.WriteLine (" Ad Space [{0}] Did Finish Video ===== ", adBanner.Space);
			};
			adBanner.WillPresentFullscreen += delegate {
				Console.WriteLine (" Ad Space [{0}] Will Present Fullscreen Ad ===== ", adBanner.Space);
			};
			adBanner.Error += (_, e) => {
				Console.WriteLine (" Ad Space [{0}] Did Fail to Receive Ad with error [{1}] ===== ", adBanner.Space, e.ErrorDescription);
			};

			adBanner.FetchAdForFrame (View.Frame);
		
			statusLbl.TextColor = UIColor.Orange;
			statusLbl.Text = "Ad being fetched for " + adBanner.Space;
		}

		partial void showAdClickedButton (UIButton sender)
		{
			// Get ad space selection
			var space = pickerSource.Selected (adTypePicker);
			FetchAndDisplay (space);
		}
	}
}
