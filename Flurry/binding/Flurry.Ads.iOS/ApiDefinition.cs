using System;

using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Flurry.Ads {

	[BaseType (typeof(NSObject), Name = "FlurryAdTargeting")]
	interface FlurryAdTargeting
	{
		// + (FlurryAdTargeting *) targeting;
		[Static, Export ("targeting")]
		FlurryAdTargeting Targeting { get; }

		// @property (nonatomic, strong) CLLocation* location;
		[Export ("location", ArgumentSemantic.Strong)]
		CLLocation Location { get; set; }

		// @property (nonatomic, strong) NSDictionary *userCookies;
		[Export ("userCookies", ArgumentSemantic.Strong)]
		NSDictionary UserCookies { get; set; }

		// @property (nonatomic, strong) NSDictionary *keywords;
		[Export ("keywords", ArgumentSemantic.Strong)]
		NSDictionary Keywords { get; set; }

		// @property (nonatomic, assign) BOOL testAdsEnabled;
		[Export ("testAdsEnabled")]
		bool TestAdsEnabled { get; set; }
	}

	[BaseType (typeof(NSObject), Name = "FlurryAds")]
	interface FlurryAds
	{
		// +(void) fetchAdForSpace:(NSString*)space frame:(CGRect)frame size:(FlurryAdSize)size;
		[Static, Export ("fetchAdForSpace:frame:size:")]
		void FetchAd (string space, CGRect frame, AdSize size);

		// +(BOOL) adReadyForSpace:(NSString*)space;
		[Static, Export ("adReadyForSpace:")]
		bool IsAdReady (string space);

		// + (void)displayAdForSpace:(NSString*)space onView:(UIView *)view viewControllerForPresentation:(UIViewController*) viewControllerForPresentation;
		[Static, Export ("displayAdForSpace:onView:viewControllerForPresentation:")]
		void DisplayAd (string space, UIView view, UIViewController viewControllerForPresentation);

		// + (void)displayAdForSpace:(NSString*)space modallyForViewController:(UIViewController *)viewController  __attribute__ ((deprecated));
		[Obsolete ("This method has been deprecated. Use the overload that accepts a UIView instead.")]
		[Static, Export ("displayAdForSpace:modallyForViewController:")]
		void DisplayAd (string space, UIViewController viewController);

		// + (void)fetchAndDisplayAdForSpace:(NSString*)space view:(UIView *)viewContainer viewController:(UIViewController*) viewControllerForPresentation size:(FlurryAdSize)size;
		[Static, Export ("fetchAndDisplayAdForSpace:view:viewController:size:")]
		void FetchAndDisplayAd (string space, UIView viewContainer, UIViewController viewControllerForPresentation, AdSize size);

		// + (void) removeAdFromSpace:(NSString*)space;
		[Static, Export ("removeAdFromSpace:")]
		void RemoveAd (string space);

		// + (void) initialize: (UIViewController *)rvc;
		[Static, Export ("initialize:")]
		void Initialize (UIViewController rvc);

		// + (void)setAdDelegate:(id)delegate;
		[Static, Export ("setAdDelegate:")]
		void SetAdDelegate (NSObject @delegate);

		// + (void)enableTestAds:(BOOL)enable;
		[Static, Export ("enableTestAds:")]
		void EnableTestAds (bool enable);

		// + (void) setUserCookies:(NSDictionary *) userCookies;
		[Static, Export ("setUserCookies:")]
		void SetUserCookies (NSDictionary userCookies);

		// + (void) clearUserCookies;
		[Static, Export ("clearUserCookies")]
		void ClearUserCookies ();

		// + (void) setKeywordsForTargeting:(NSDictionary*) keywords;
		[Static, Export ("setKeywordsForTargeting:")]
		void SetTargetingKeywords (NSDictionary keywords);

		// + (void) clearKeywords;
		[Static, Export ("clearKeywords")]
		void ClearTargetingKeywords ();

		// + (void) addCustomAdNetwork:(Class<FlurryCustomAdNetwork>)adNetworkClass withProperties:(id<FlurryCustomAdNetworkProperties>)adNetworkProperties;
//		[Static, Export ("addCustomAdNetwork:withProperties:")]
//		void AddCustomAdNetwork (FlurryCustomAdNetwork adNetworkClass, FlurryCustomAdNetworkProperties adNetworkProperties);
	}

	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "FlurryAdDelegate")]
	interface FlurryAdDelegate
	{
		// - (void) spaceDidReceiveAd:(NSString*)adSpace;
		[Export ("spaceDidReceiveAd:")]
		void SpaceDidReceiveAd (string adSpace);

		// - (void) spaceDidFailToReceiveAd:(NSString*)adSpace error:(NSError *)error;
		[Export ("spaceDidFailToReceiveAd:error:")]
		void SpaceDidFailToReceiveAd (string adSpace, NSError error);

		// - (BOOL) spaceShouldDisplay:(NSString*)adSpace interstitial:(BOOL)interstitial;
		[Export ("spaceShouldDisplay:interstitial:")]
		bool SpaceShouldDisplay (string adSpace, bool interstitial);

		// - (BOOL)spaceShouldDisplay:(NSString*)adSpace  forType:(FlurryAdType)type __attribute__ ((deprecated));
		[Obsolete ("This method has been deprecated. Use the overload that accepts a Boolean instead.")]
		[Export ("spaceShouldDisplay:forType:")]
		bool SpaceShouldDisplay (string adSpace, AdType type);

		// - (void) spaceDidRender:(NSString *)space interstitial:(BOOL)interstitial;
		[Export ("spaceDidRender:interstitial:")]
		void SpaceDidRender (string space, bool interstitial);

		// - (void) spaceDidFailToRender:(NSString *)space error:(NSError *)error;
		[Export ("spaceDidFailToRender:error:")]
		void SpaceDidFailToRender (string space, NSError error);

		// - (void)spaceWillDismiss:(NSString *)adSpace interstitial:(BOOL)interstitial;
		[Export ("spaceWillDismiss:interstitial:")]
		void SpaceWillDismiss (string adSpace, bool interstitial);

		// - (void)spaceDidDismiss:(NSString *)adSpace interstitial:(BOOL)interstitial;
		[Export ("spaceDidDismiss:interstitial:")]
		void SpaceDidDismiss (string adSpace, bool interstitial);

		// - (void)spaceWillLeaveApplication:(NSString *)adSpace;
		[Export ("spaceWillLeaveApplication:")]
		void SpaceWillLeaveApplication (string adSpace);

		// - (void) spaceWillExpand:(NSString *)adSpace;
		[Export ("spaceWillExpand:")]
		void SpaceWillExpand (string adSpace);

		// - (void) spaceWillCollapse:(NSString *)adSpace;
		[Export ("spaceWillCollapse:")]
		void SpaceWillCollapse (string adSpace);

		// - (void) spaceDidCollapse:(NSString *)adSpace;
		[Export ("spaceDidCollapse:")]
		void SpaceDidCollapse (string adSpace);

		// - (void) spaceDidReceiveClick:(NSString*)adSpace;
		[Export ("spaceDidReceiveClick:")]
		void SpaceDidReceiveClick (string adSpace);

		// - (void) spaceClickActionDidFail:(NSString*)adSpace error:(NSError *)error;
		[Export ("spaceClickActionDidFail:error:")]
		void SpaceClickActionDidFail (string adSpace, NSError error);

		// - (void)videoDidFinish:(NSString *)adSpace;
		[Export ("videoDidFinish:")]
		void VideoDidFinish (string adSpace);

		// - (void)videoDidNotFinish:(NSString *)adSpace;
		[Export ("videoDidNotFinish:")]
		void VideoDidNotFinish (string adSpace);

		// - (NSString *)appSpotMillennialAppKey;
		[Export ("appSpotMillennialAppKey")]
		string AppSpotMillennialAppKey ();

		// - (NSString *)appSpotMillennialInterstitalAppKey;
		[Export ("appSpotMillennialInterstitalAppKey")]
		string AppSpotMillennialInterstitalAppKey ();

		// - (NSString *)appSpotInMobiAppKey;
		[Export ("appSpotInMobiAppKey")]
		string AppSpotInMobiAppKey ();

		// - (NSString *)appSpotFANAppPlacementID;
		[Export ("appSpotFANAppPlacementID")]
		string AppSpotFANAppPlacementID ();

		// - (NSString *)appSpotAdMobPublisherID;
		[Export ("appSpotAdMobPublisherID")]
		string AppSpotAdMobPublisherID ();

		// - (NSString *)appSpotMobclixApplicationID;
		[Export ("appSpotMobclixApplicationID")]
		string AppSpotMobclixApplicationID ();

		// - (NSString *)appSpotJumptapPublisherID;
		[Export ("appSpotJumptapPublisherID")]
		string AppSpotJumptapPublisherID ();

		// - (NSString *)appSpotJumptapSiteID;
		[Export ("appSpotJumptapSiteID")]
		string AppSpotJumptapSiteID ();

		// - (NSString *)appSpotJumptapBannerAdSpotID;
		[Export ("appSpotJumptapBannerAdSpotID")]
		string AppSpotJumptapBannerAdSpotID ();

		// - (NSString *)appSpotJumptapLeaderboardAdSpotID;
		[Export ("appSpotJumptapLeaderboardAdSpotID")]
		string AppSpotJumptapLeaderboardAdSpotID ();

		// - (NSString *)appSpotJumptapMediumRectangleAdSpotID;
		[Export ("appSpotJumptapMediumRectangleAdSpotID")]
		string AppSpotJumptapMediumRectangleAdSpotID ();

		// - (id)appSpotRootViewController __attribute__ ((deprecated));
		[Obsolete ("This method has been deprecated. Use FlurryAds.Initialze() instead.")]
		[Export ("appSpotRootViewController")]
		NSObject AppSpotRootViewController ();

		// - (BOOL)appSpotAccelerometerEnabled;
		[Export ("appSpotAccelerometerEnabled")]
		bool AppSpotAccelerometerEnabled ();
	}
}

namespace Flurry.Ads.Banner {

	interface IFlurryAdBannerDelegate { }

	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "FlurryAdBannerDelegate")]
	interface FlurryAdBannerDelegate
	{
		// - (void) adBannerDidFetchAd:(FlurryAdBanner*)bannerAd;
		[Export ("adBannerDidFetchAd:"), EventArgs ("DidFetchAd")]
		void DidFetchAd (FlurryAdBanner bannerAd);

		// - (void) adBannerDidRender:(FlurryAdBanner*)bannerAd;
		[Export ("adBannerDidRender:"), EventArgs ("DidRenderAd")]
		void DidRenderAd (FlurryAdBanner bannerAd);

		// - (void) adBannerWillPresentFullscreen:(FlurryAdBanner*)bannerAd;
		[Export ("adBannerWillPresentFullscreen:"), EventArgs ("WillPresentFullscreen")]
		void WillPresentFullscreen (FlurryAdBanner bannerAd);

		// - (void) adBannerWillLeaveApplication:(FlurryAdBanner*)bannerAd;
		[Export ("adBannerWillLeaveApplication:"), EventArgs ("WillLeaveApplication")]
		void WillLeaveApplication (FlurryAdBanner bannerAd);

		// - (void) adBannerWillDismissFullscreen:(FlurryAdBanner*)bannerAd;
		[Export ("adBannerWillDismissFullscreen:"), EventArgs ("WillDismissFullscreen")]
		void WillDismissFullscreen (FlurryAdBanner bannerAd);

		// - (void) adBannerDidDismissFullscreen:(FlurryAdBanner*)bannerAd;
		[Export ("adBannerDidDismissFullscreen:"), EventArgs ("DidDismissFullscreen")]
		void DidDismissFullscreen (FlurryAdBanner bannerAd);

		// - (void) adBannerDidReceiveClick:(FlurryAdBanner*)bannerAd;
		[Export ("adBannerDidReceiveClick:"), EventArgs ("DidReceiveClick")]
		void DidReceiveClick (FlurryAdBanner bannerAd);

		// - (void) adBannerVideoDidFinish:(FlurryAdBanner*)bannerAd;
		[Export ("adBannerVideoDidFinish:"), EventArgs ("DidFinishVideo")]
		void DidFinishVideo (FlurryAdBanner bannerAd);

		// - (void) adBanner:(FlurryAdBanner*) bannerAd adError:(FlurryAdError) adError errorDescription:(NSError*) errorDescription;
		[Export ("adBanner:adError:errorDescription:"), EventArgs ("BannerAdError")]
		void Error (FlurryAdBanner bannerAd, AdError adError, NSError errorDescription);
	}

	[BaseType (typeof(NSObject), Name = "FlurryAdBanner", Delegates = new[] { "AdDelegate" }, Events = new[] { typeof (FlurryAdBannerDelegate) })]
	interface FlurryAdBanner
	{
		// @property (nonatomic, copy) NSString* space;
		[Export ("space")]
		string Space { get; set; }

		// @property (nonatomic, strong) FlurryAdTargeting* targeting;
		[Export ("targeting", ArgumentSemantic.Strong)]
		FlurryAdTargeting Targeting { get; set; }

		// @property (nonatomic, weak) id<FlurryAdBannerDelegate> adDelegate;
		[NullAllowed, Export ("adDelegate", ArgumentSemantic.Weak)]
		IFlurryAdBannerDelegate AdDelegate { get; set; }

		// @property (nonatomic, readonly) BOOL ready;
		[Export ("ready")]
		bool IsReady { get; }

		// - (id) initWithSpace:(NSString *)space;
		[Export ("initWithSpace:")]
		IntPtr Constructor (string space);

		// - (void) fetchAdForFrame:(CGRect)frame;
		[Export ("fetchAdForFrame:")]
		void FetchAd (CGRect frame);

		// - (void) displayAdInView:(UIView *)view viewControllerForPresentation:(UIViewController *)viewController;
		[Export ("displayAdInView:viewControllerForPresentation:")]
		void DisplayAd (UIView view, UIViewController viewController);

		// - (void) fetchAndDisplayAdInView:(UIView *)view viewControllerForPresentation:(UIViewController *)viewController;
		[Export ("fetchAndDisplayAdInView:viewControllerForPresentation:")]
		void FetchAndDisplayAd (UIView view, UIViewController viewController);
	}
}

namespace Flurry.Ads.Interstitial {

	interface IFlurryAdInterstitialDelegate { }

	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "FlurryAdInterstitialDelegate")]
	interface FlurryAdInterstitialDelegate
	{
		// - (void) adInterstitialDidFetchAd:(FlurryAdInterstitial*)interstitialAd;
		[Export ("adInterstitialDidFetchAd:"), EventArgs ("DidFetchAd")]
		void DidFetchAd (FlurryAdInterstitial interstitialAd);

		// - (void) adInterstitialDidRender:(FlurryAdInterstitial*)interstitialAd;
		[Export ("adInterstitialDidRender:"), EventArgs ("DidRenderAd")]
		void DidRenderAd (FlurryAdInterstitial interstitialAd);

		// - (void) adInterstitialWillPresent:(FlurryAdInterstitial*)interstitialAd;
		[Export ("adInterstitialWillPresent:"), EventArgs ("WillPresentAd")]
		void WillPresentAd (FlurryAdInterstitial interstitialAd);

		// - (void) adInterstitialWillLeaveApplication:(FlurryAdInterstitial*)interstitialAd;
		[Export ("adInterstitialWillLeaveApplication:"), EventArgs ("WillLeaveApplication")]
		void WillLeaveApplication (FlurryAdInterstitial interstitialAd);

		// - (void) adInterstitialWillDismiss:(FlurryAdInterstitial*)interstitialAd;
		[Export ("adInterstitialWillDismiss:"), EventArgs ("WillDismissAd")]
		void WillDismissAd (FlurryAdInterstitial interstitialAd);

		// - (void) adInterstitialDidDismiss:(FlurryAdInterstitial*)interstitialAd;
		[Export ("adInterstitialDidDismiss:"), EventArgs ("DidDismissAd")]
		void DidDismissAd (FlurryAdInterstitial interstitialAd);

		// - (void) adInterstitialDidReceiveClick:(FlurryAdInterstitial*)interstitialAd;
		[Export ("adInterstitialDidReceiveClick:"), EventArgs ("DidReceiveClick")]
		void DidReceiveClick (FlurryAdInterstitial interstitialAd);

		// - (void) adInterstitialVideoDidFinish:(FlurryAdInterstitial*)interstitialAd;
		[Export ("adInterstitialVideoDidFinish:"), EventArgs ("DidFinishVideo")]
		void DidFinishVideo (FlurryAdInterstitial interstitialAd);

		// - (void) adInterstitial:(FlurryAdInterstitial*) interstitialAd adError:(FlurryAdError) adError errorDescription:(NSError*) errorDescription;
		[Export ("adInterstitial:adError:errorDescription:"), EventArgs ("InterstitialAdError")]
		void Error (FlurryAdInterstitial interstitialAd, AdError adError, NSError errorDescription);
	}

	[BaseType (typeof(NSObject), Name = "FlurryAdInterstitial", Delegates = new[] { "AdDelegate" }, Events = new[] { typeof (FlurryAdInterstitialDelegate) })]
	interface FlurryAdInterstitial
	{
		// @property (nonatomic, copy, readonly) NSString *space;
		[Export ("space")]
		string Space { get; }

		// @property (nonatomic, strong) FlurryAdTargeting *targeting;
		[Export ("targeting", ArgumentSemantic.Strong)]
		FlurryAdTargeting Targeting { get; set; }

		// @property (nonatomic, weak) id<FlurryAdInterstitialDelegate> adDelegate;
		[NullAllowed, Export ("adDelegate", ArgumentSemantic.Weak)]
		IFlurryAdInterstitialDelegate AdDelegate { get; set; }

		// @property (nonatomic, readonly) BOOL ready;
		[Export ("ready")]
		bool IsReady { get; }

		// - (id)   initWithSpace:(NSString *)space;
		[Export ("initWithSpace:")]
		IntPtr Constructor (string space);

		// - (void) fetchAd;
		[Export ("fetchAd")]
		void FetchAd ();

		// - (void) presentWithViewController: (UIViewController *) presentingViewController;
		[Export ("presentWithViewController:")]
		void Present (UIViewController presentingViewController);
	}
}

namespace Flurry.Ads.Native {
	
	[BaseType (typeof(NSObject), Name = "FlurryAdNativeAsset")]
	interface FlurryAdNativeAsset
	{
		// @property (nonatomic, strong, readonly) NSString *name;
		[Export ("name", ArgumentSemantic.Strong)]
		string Name { get; }

		// @property (nonatomic, readonly) kAssetType type;
		[Export ("type")]
		AssetType Type { get; }

		// @property (nonatomic, strong, readonly) NSString *value;
		[Export ("value", ArgumentSemantic.Strong)]
		string Value { get; }

		// @property (nonatomic, assign, readonly) int width;
		[Export ("width")]
		int Width { get; }

		// @property (nonatomic, assign, readonly) int height;
		[Export ("height")]
		int Height { get; }
	}

	interface IFlurryAdNativeDelegate { }

	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "FlurryAdNativeDelegate")]
	interface FlurryAdNativeDelegate
	{
		// - (void) adNativeDidFetchAd:(FlurryAdNative*) nativeAd;
		[Export ("adNativeDidFetchAd:"), EventArgs("DidFetchAd")]
		void DidFetchAd (FlurryAdNative nativeAd);

		// - (void) adNativeWillPresent:(FlurryAdNative*) nativeAd;
		[Export ("adNativeWillPresent:"), EventArgs("WillPresentAd")]
		void WillPresentAd (FlurryAdNative nativeAd);

		// - (void) adNativeWillLeaveApplication:(FlurryAdNative*) nativeAd;
		[Export ("adNativeWillLeaveApplication:"), EventArgs("WillLeaveApplication")]
		void WillLeaveApplication (FlurryAdNative nativeAd);

		// - (void) adNativeWillDismiss:(FlurryAdNative*) nativeAd;
		[Export ("adNativeWillDismiss:"), EventArgs("WillDismissAd")]
		void WillDismissAd (FlurryAdNative nativeAd);

		// - (void) adNativeDidDismiss:(FlurryAdNative*) nativeAd;
		[Export ("adNativeDidDismiss:"), EventArgs("DidDismissAd")]
		void DidDismissAd (FlurryAdNative nativeAd);

		// - (void) adNativeDidReceiveClick:(FlurryAdNative*) nativeAd;
		[Export ("adNativeDidReceiveClick:"), EventArgs("DidReceiveClick")]
		void DidReceiveClick (FlurryAdNative nativeAd);

		// - (void) adNative:(FlurryAdNative*) nativeAd adError:(FlurryAdError) adError errorDescription:(NSError*) errorDescription;
		[Export ("adNative:adError:errorDescription:"), EventArgs("NativeAdError")]
		void Error (FlurryAdNative nativeAd, AdError adError, NSError errorDescription);

		// - (void) adNativeDidLogImpression:(FlurryAdNative*) nativeAd;
		[Export ("adNativeDidLogImpression:"), EventArgs("DidLogImpression")]
		void DidLogImpression (FlurryAdNative nativeAd);

		// - (void) adNativeExpandToggled:(FlurryAdNative*)nativeAd;
		[Export ("adNativeExpandToggled:"), EventArgs("DidToggleExpand")]
		void DidToggleExpand (FlurryAdNative nativeAd);
	}

	[BaseType (typeof(NSObject), Name = "FlurryAdNative", Delegates = new[] { "AdDelegate" }, Events = new[] { typeof (FlurryAdNativeDelegate) })]
	interface FlurryAdNative
	{
		// @property (nonatomic, copy, readonly) NSString *space;
		[Export ("space", ArgumentSemantic.Copy)]
		string Space { get; }

		// @property (nonatomic, weak) id<FlurryAdNativeDelegate> adDelegate;
		[NullAllowed, Export ("adDelegate", ArgumentSemantic.Weak)]
		IFlurryAdNativeDelegate AdDelegate { get; set; }

		// @property (nonatomic, readonly) BOOL ready;
		[Export ("ready")]
		bool IsReady { get; }

		// @property (nonatomic, readonly) BOOL expired;
		[Export ("expired")]
		bool IsExpired { get; }

		// @property (nonatomic, assign) kFlurryAdNativeDisplayState displayState;
		[Export ("displayState")]
		NativeAdDisplayState DisplayState { get; set; }

		// @property (nonatomic, strong, readonly) NSArray *assetList;
		[Export ("assetList", ArgumentSemantic.Strong)]
		NSObject[] AssetList { get; }

		// @property (nonatomic, strong) UIView *trackingView;
		[Export ("trackingView", ArgumentSemantic.Strong)]
		UIView TrackingView { get; set; }

		// @property (nonatomic, strong) UIViewController* viewControllerForPresentation;
		[Export ("viewControllerForPresentation", ArgumentSemantic.Strong)]
		UIViewController PresentationViewController { get; set; }

		// @property (nonatomic, strong) UIView* videoViewContainer;
		[Export ("videoViewContainer", ArgumentSemantic.Strong)]
		UIView VideoViewContainer { get; set; }

		// @property (nonatomic, strong) FlurryAdTargeting *targeting;
		[Export ("targeting", ArgumentSemantic.Strong)]
		FlurryAdTargeting Targeting { get; set; }

		// - (id) initWithSpace:(NSString *)space;
		[Export ("initWithSpace:")]
		IntPtr Constructor (string space);

		// - (void) fetchAd;
		[Export ("fetchAd")]
		void FetchAd ();

		// - (NSArray*) assetListForType:(kAssetType)type;
		[Export ("assetListForType:")]
		NSObject[] GetAssetList (AssetType type);

		// - (void) removeTrackingView;
		[Export ("removeTrackingView")]
		void RemoveTrackingView ();

		// - (BOOL)isVideoAd;
		[Export ("isVideoAd")]
		bool IsVideoAd { get; }

		// - (void)setPencilViewToTrack:(UIView*)pencilView withExpandButton:(UIButton*)expandButton andCTAButton:(UIButton*)ctaButton;
		[Export ("setPencilViewToTrack:withExpandButton:andCTAButton:")]
		void SetPencilViewToTrack (UIView pencilView, UIButton expandButton, [NullAllowed] UIButton ctaButton);

		// - (void)setExpandedViewToTrack:(UIView*)expandedView withExpandButton:(UIButton*)expandButton andCTAButton:(UIButton*)ctaButton;
		[Export ("setExpandedViewToTrack:withExpandButton:andCTAButton:")]
		void SetExpandedViewToTrack (UIView expandedView, UIButton expandButton, [NullAllowed] UIButton ctaButton);
	}

//	[BaseType (typeof(NSObject), Name = "FlurryAdNativeStyle")]
//	interface FlurryAdNativeStyle
//	{
//		// extern int const STYLE1_SMALL;
//		[Static, Field ("STYLE1_SMALL", "__Internal")]
//		int Style1Small { get; }
//
//		// extern int const STYLE1_MEDIUM;
//		[Static, Field ("STYLE1_MEDIUM", "__Internal")]
//		int Style1Medium { get; }
//
//		// extern int const STYLE1_LARGE;
//		[Static, Field ("STYLE1_LARGE", "__Internal")]
//		int Style1Large { get; }
//
//		// extern int const STYLE1_XLARGE;
//		[Static, Field ("STYLE1_XLARGE", "__Internal")]
//		int Style1XLarge { get; }
//
//		// extern int const STYLE2_SMALL;
//		[Static, Field ("STYLE2_SMALL", "__Internal")]
//		int Style2Small { get; }
//
//		// extern int const STYLE2_MEDIUM;
//		[Static, Field ("STYLE2_MEDIUM", "__Internal")]
//		int Style2Medium { get; }
//
//
//		// @property (nonatomic, readonly) NSString *style;
//		[Export ("style")]
//		string Style { get; }
//
//		// - (id)initWithStyle:(int)styleNum;
//		[Export ("initWithStyle:")]
//		IntPtr Constructor (int styleNum);
//	}
}
