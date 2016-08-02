using System;

using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Flurry.Tumblr {

	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "FlurryTumblrDelegate")]
	interface FlurryTumblrDelegate
	{
		// - (void) flurryTumblrPostError: (NSError*) error errorType:(FlurryTumblrErrorType) errorType;
		[Export ("flurryTumblrPostError:errorType:")]
		void PostError (NSError error, TumblrErrorType errorType);

		// - (void) flurryTumblrPostSuccess;
		[Export ("flurryTumblrPostSuccess")]
		void PostSuccess ();
	}

	interface IFlurryTumblrShareParameters { }

	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "IFlurryTumblrShareParameters")]
	interface FlurryTumblrShareParameters
	{
		// @property (nonatomic, retain) NSString*     iOSDeepLink;
		[Export ("iOSDeepLink", ArgumentSemantic.Retain)]
		string IOSDeepLink { get; set; }

		// @property (nonatomic, retain) NSString*     androidDeepLink;
		[Export ("androidDeepLink", ArgumentSemantic.Retain)]
		string AndroidDeepLink { get; set; }

		// @property (nonatomic, retain) NSString*     webLink;
		[Export ("webLink", ArgumentSemantic.Retain)]
		string WebLink { get; set; }
	}

	[BaseType (typeof(NSObject), Name = "FlurryTextShareParameters")]
	interface FlurryTextShareParameters : FlurryTumblrShareParameters
	{
		// @property (nonatomic, strong) NSString* text;
		[Export ("text", ArgumentSemantic.Strong)]
		string Text { get; set; }

		// @property (nonatomic, strong) NSString* title;
		[Export ("title", ArgumentSemantic.Strong)]
		string Title { get; set; }
	}

	[BaseType (typeof(NSObject), Name = "FlurryImageShareParameters")]
	interface FlurryImageShareParameters : FlurryTumblrShareParameters
	{
		// @property (nonatomic, strong) NSString* imageURL;
		[Export ("imageURL", ArgumentSemantic.Strong)]
		string ImageUrl { get; set; }

		// @property (nonatomic, strong) NSString* imageCaption;
		[Export ("imageCaption", ArgumentSemantic.Strong)]
		string ImageCaption { get; set; }
	}

	[BaseType (typeof(NSObject), Name = "FlurryTumblr")]
	interface FlurryTumblr
	{
		// + (void) setConsumerKey: (NSString*) consumerKey consumerSecret: (NSString*) consumerSecret;
		[Static, Export ("setConsumerKey:consumerSecret:")]
		void SetConsumerKey (string consumerKey, string consumerSecret);

		// + (void) setConsumerKey: (NSString*) consumerKey consumerSecret: (NSString*) consumerSecret consumerScheme:(NSString*)urlScheme;
		[Static, Export ("setConsumerKey:consumerSecret:consumerScheme:")]
		void SetConsumerKey (string consumerKey, string consumerSecret, string urlScheme);

		// + (void) post: (id<IFlurryTumblrShareParameters>)parameters  presentingViewController:(UIViewController*) presentingController;
		[Static, Export ("post:presentingViewController:")]
		void Post (IFlurryTumblrShareParameters parameters, UIViewController presentingController);

		// + (void) setDelegate: (id<FlurryTumblrDelegate>) delegate;
		[Static, Export ("setDelegate:")]
		void SetDelegate (FlurryTumblrDelegate @delegate);

		// + (UIImage*) tumblrLogo;
		[Static, Export ("tumblrLogo")]
		UIImage TumblrLogo { get; }

		// + (BOOL)handleURL:(NSURL*)url;
		[Static, Export ("handleURL:")]
		bool HandleUrl (NSUrl url);
	}
}
