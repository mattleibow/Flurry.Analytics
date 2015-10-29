Yahoo App Publishing provides a flexible ad-serving platform that is easy to set 
up and use, enabling you to maximize your ad revenue and engage actively with 
your users. As a Publisher, you can drive revenue by creating banners, 
interstitials, native and video ads for your app.

## Get your API Keys

Start by creating an app. Once you create the app, you’ll receive a Flurry API 
Key, which you’ll need when using the SDK. 

[**Sign Up**][1] or [**Create an App**][2]

## Integrate Flurry Analytics

We have example code below to get you up and running as quickly as possible.

### iOS 

    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // start Flurry
            FlurryAgent.StartSession("FLURRY_API_KEY");

            // continue . . .
        }
    }

### Android

    [Application]
    public class SampleApplication : Application
    {
        public SampleApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            
            // start Flurry
            FlurryAgent.Init(this, "FLURRY_API_KEY");
            
            // continue . . .
        }
    }

## Configure Ad Serving

Configuring ad serving is quick. After you [create an ad space][3], integrate 
the Flurry ads (step 5) into your app. For additional help with creating an ad 
space, check this [documentation][4]. 

[**Create an Ad Space**][3]

## Integrate Flurry Ads

Now, integrate the Ad Space code into your app and start earning revenue. 

### iOS 

    // create the ad instance
    var adBanner = new FlurryAdBanner("AD_SPACE_NAME);
    adBanner.DidFetchAd += delegate {
        // display the ad
        adBanner.DisplayAd(View, this);
    };
    
    // fetch the ad
    adBanner.FetchAd(View.Frame);   

### Android

    // create the ad instance
    var adBanner = new FlurryAdBanner(this, bannerContainerView, "AD_SPACE_NAME");
    adBanner.Fetched += delegate {
        // display the ad
        adBanner.DisplayAd();
    };
    
    // fetch the ad
    adBanner.FetchAd();

Besides the basic banner ad, we can include other ad types, one such type is the 
interstitial ad.

### iOS

    // create the ad instance
    var adInterstitial = new FlurryAdInterstitial("AD_SPACE_NAME");
    adInterstitial.DidFetchAd += delegate {
        // display the ad
        adInterstitial.Present(this);
    };
    
    // fetch the ad
    adInterstitial.FetchAd();
     
### Android

    // create the ad instance
    var adInterstitial = new FlurryAdInterstitial(this, "AD_SPACE_NAME");
    adInterstitial.Fetched += delegate {
        // display the ad
        adInterstitial.DisplayAd();
    };
    
    // fetch the ad
    adInterstitial.FetchAd();
            
[1]: https://dev.flurry.com/secure/signup.do
[2]: https://dev.flurry.com/createProjectSelectPlatform.do
[3]: https://dev.flurry.com/appSpotSignup.do
[4]: https://developer.yahoo.com/flurry/docs/publisher/gettingstarted/basicadspacesetup/
