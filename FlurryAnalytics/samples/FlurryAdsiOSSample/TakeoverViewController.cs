using System;
using UIKit;

using Flurry.Ads.Interstitial;
using Flurry.Ads;

namespace FlurryAdsiOSSample
{
	partial class TakeoverViewController : UIViewController
	{
		private AdPickerSource pickerSource;
		private FlurryAdInterstitial adInterstitial;

		public TakeoverViewController (IntPtr handle)
			: base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//  the sample points to a number of different ad spaces - each is configured with different settings on the dev.flurry.com
			//  integration for each takeover ad is the same regardless of the configuration on the server side.
			//  all the entities in flurryAdSpaces refer to the ad space configured on dev.flurry.com
			//  under Publishers tab, left-hand nav Inventory / Ad Spaces

			pickerSource = new AdPickerSource (new [] {
				"Takeover",
				"TakeoverRich",
				"TakeoverVideo",
				"TakeoverVideoSkip"
			});
			adTypePicker.DataSource = pickerSource;
			adTypePicker.Delegate = pickerSource;

			showAd.Layer.BorderWidth = 0.5f;
			showAd.Layer.BorderColor = UIColor.Gray.CGColor;
			showAd.Layer.CornerRadius = 10;

			statusLbl.TextColor = UIColor.Orange;
			statusLbl.Text = "Request an Ad";
			statusLbl.TextAlignment = UITextAlignment.Center;
		}

		partial void showAdClickedButton (UIButton sender)
		{
			var space = pickerSource.Selected (adTypePicker);

			FetchAndDisplay (space);
		}

		private void FetchAndDisplay (string space)
		{
			adInterstitial = new FlurryAdInterstitial (space);

#if DEBUG
			// enable test ads
			var targeting = FlurryAdTargeting.Targeting;
			targeting.TestAdsEnabled = true;
			adInterstitial.Targeting = targeting;
#endif

			adInterstitial.DidFetchAd += delegate {
				statusLbl.Text = string.Format (" [{0}] Did Fetch Ad ", adInterstitial.Space);

				adInterstitial.Present (this);
			};
			adInterstitial.DidRenderAd += delegate {
				statusLbl.Text = string.Format (" [{0}] Did Render Ad ", adInterstitial.Space);
			};
			adInterstitial.DidDismissAd += delegate {
				statusLbl.Text = string.Format (" [{0}] Will Present Fullscreen Ad ", adInterstitial.Space);
			};
			adInterstitial.DidReceiveClick += delegate {
				statusLbl.Text = string.Format (" [{0}] Did Receive Click Ad ", adInterstitial.Space);
			};
			adInterstitial.DidDismissAd += delegate {
				statusLbl.Text = string.Format (" [{0}] Did Dismiss Fullscreen Ad ", adInterstitial.Space);
			};
			adInterstitial.WillLeaveApplication += delegate {
				statusLbl.Text = string.Format (" [{0}] Will Leave Application ", adInterstitial.Space);
			};
			adInterstitial.DidFinishVideo += delegate {
				statusLbl.Text = string.Format (" [{0}] Did Finish Video ", adInterstitial.Space);
			};
			adInterstitial.WillPresentAd += delegate {
				statusLbl.Text = string.Format (" [{0}] Will Present Fullscreen Ad ", adInterstitial.Space);
			};
			adInterstitial.Error += (_, e) => {
				statusLbl.Text = string.Format (" [{0}] Did Fail to Receive Ad with error [{1}] ", adInterstitial.Space, e.ErrorDescription);
			};

			statusLbl.Text = string.Format (" [{0}] Will Fetch Ad ", adInterstitial.Space);

			adInterstitial.FetchAd ();
		}
	}
}
