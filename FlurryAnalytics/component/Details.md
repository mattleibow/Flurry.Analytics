The Flurry Analytics Agent allows you to track the usage and behavior of your Android, iOS or Windows Phone application on users' phones for viewing in the Flurry Analytics system. It is designed to be as easy as possible with a basic setup complete in few minutes.

## Features

There are many features available in the Flurry Analytics API, such as:

* Session tracking
* Event logging, with optional parameters
* Page View tracking
* Demographics tracking, such as age, gender and user id
* Location tracking
* App version tracking
* And much more...

## Getting Started
The setup for all the platforms is very easy with only a few steps:

### Android
1. Add the `INTERNET` permission to `AndroidManifest.xml`.
2. Add `Google Play Services` [NuGet](http://www.NuGet.org) or [Component](http://components.xamarin.com) to your app. Make sure you select the correct version for your application.
3. Add `FlurryAgent.OnStartSession(this, "YOUR_API_KEY");` to the `OnStart` method of the Activity or Service.
4. Add `FlurryAgent.OnEndSession(this);` to the `OnStop` method of the Activity or Service.

### iOS
1. Add `FlurryAgent.StartSession("YOUR_API_KEY");` to the `FinishedLaunching` method of the Application Delegate

### Windows Phone
1. Add `ID_CAP_NETWORKING` and `ID_CAP_IDENTITY_DEVICE` capabilities to `WMAppManifest.xml`.
2. Add `FlurryWP8SDK.Api.StartSession("YOUR_API_KEY");` to `Launching` and `Activated` events of the Application.

And that's it, your mobile app will start sending activity usage statistics to the Flurry servers!


## Advanced

Flurry Analytics SDK supported versions:

* SDK for iOS supports **Xcode tools 4.5** and above
* SDK for Android supports **Android API level 10** (Gingerbread) and above
* SDK for Windows Phone supports **Windows Phone 8** and above