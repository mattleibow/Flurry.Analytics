using System;

using Android.App;
using Android.Content;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.OS;

using Flurry.Ads;

namespace FlurryAdsAndroidSample
{
	[Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
	public class MainActivity : AppCompatActivity
	{
		private FlurryAdBanner adBanner;
		private FlurryAdInterstitial adInterstitial;

		private TextView statusLabel;
		private ViewGroup bannerContainer;
		private Button showInterstitial;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			statusLabel = FindViewById<TextView> (Resource.Id.statusLabel);
			bannerContainer = FindViewById<ViewGroup> (Resource.Id.bannerContainer);
			showInterstitial = FindViewById<Button> (Resource.Id.showInterstitial);

			showInterstitial.Click += delegate {
				ShowInterstitialAd ();
			};

			ShowBannerAd ();
		}

		private void ShowBannerAd ()
		{
			if (adBanner != null)
			{
				adBanner.Destroy ();
				bannerContainer.RemoveAllViews ();
			}

			adBanner = new FlurryAdBanner (this, bannerContainer, "Banner");

			adBanner.Fetched += delegate {
				statusLabel.Text = "Banner.Fetched";

				adBanner.DisplayAd ();
			};
			adBanner.Rendered += delegate {
				statusLabel.Text = "Banner.Rendered";
			};
			adBanner.ShowFullscreen += delegate {
				statusLabel.Text = "Banner.ShowFullscreen";
			};
			adBanner.Clicked += delegate {
				statusLabel.Text = "Banner.Clicked";
			};
			adBanner.CloseFullscreen += delegate {
				statusLabel.Text = "Banner.CloseFullscreen";
			};
			adBanner.AppExit += delegate {
				statusLabel.Text = "Banner.AppExit";
			};
			adBanner.VideoCompleted += delegate {
				statusLabel.Text = "Banner.VideoCompleted";
			};
			adBanner.Error += (_, e) => {
				statusLabel.Text = string.Format ("Banner.Error [{0}] [{1}] ", e.ErrorType, e.ErrorCode);
			};

			statusLabel.Text = "Banner.FetchAd";

			adBanner.FetchAd ();
		}

		private void ShowInterstitialAd ()
		{
			if (adInterstitial != null)
			{
				adInterstitial.Destroy ();
			}

			adInterstitial = new FlurryAdInterstitial (this, "Takeover");

			adInterstitial.Fetched += delegate {
				statusLabel.Text = "Interstitial.Fetched";

				adInterstitial.DisplayAd ();
			};
			adInterstitial.Rendered += delegate {
				statusLabel.Text = "Interstitial.Rendered";
			};
			adInterstitial.Display += delegate {
				statusLabel.Text = "Interstitial.Display";
			};
			adInterstitial.Clicked += delegate {
				statusLabel.Text = "Interstitial.Clicked";
			};
			adInterstitial.Close += delegate {
				statusLabel.Text = "Interstitial.Close";
			};
			adInterstitial.AppExit += delegate {
				statusLabel.Text = "Interstitial.AppExit";
			};
			adInterstitial.VideoCompleted += delegate {
				statusLabel.Text = "Interstitial.VideoCompleted";
			};
			adInterstitial.Error += (_, e) => {
				statusLabel.Text = string.Format ("Interstitial.Error [{0}] [{1}] ", e.ErrorType, e.ErrorCode);
			};

			statusLabel.Text = "Interstitial.FetchAd";

			adInterstitial.FetchAd ();
		}
	}
}
