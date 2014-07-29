# Getting Started with Flurry Analytics
Now that you are going to be adding Flurry Analytics to your mobile app, here are a few things to help you get going. Here we show you how to first add Flurry Analytics to your app and then to extend statistics to logged events, user demographics and device location.

## Adding Flurry Analytics
Adding Flurry Analytics to your app is very simple and only requires a few steps. Each platform differs slightly in the setup.

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

## Advanced Features
Not only can Flurry Analytics track your app's usage, but also many other aspects for analysis.

### Event Logging
Use the `LogEvent` methods to track user events that happen during a session. You can track how many times each event occurs, what order events happen in, how long events are, as well as what the most common parameters are for each event. This can be useful for measuring how often users take various actions, or what sequences of actions they usually perform.

#### Instance Event Logging
All three platforms support event logging with and without parameters through the `LogEvent` method. The only difference is the container for the parameters:

* **iOS** takes a `NSDictionary` of `NSString`
* **Android** takes a `IDictionary<string, string>` 
* **Windows Phone** takes `List<Parameter>`
 
```csharp
// example usage of a single event
FlurryAgent.LogEvent("User Shared Link");

// and an event with parameters
var parameters = new Dictionary<string, string> {
    {"destination", "Facebook"},
    {"content-type", "image"}
}
FlurryAgent.LogEvent("User Shared Link", parameters);
```

#### Timed Event Logging
Timed events allow you to capture the length of an event, both with and without parameters. This can be extremely valuable to understand the level of engagement with a particular action and the characteristics associated with that action. 
*For example, you can capture how long a user spends on a level or reading an article. Parameters can be used to capture, for example, the author of an article or if something was purchased while on the level.*

All three platforms support timed event logging with and without parameters through the `LogEvent` method. Timed events are started using the `LogEvent` methods with the extra `bool` parameter with a value of `true`. After the event is completed, it should be marked as ended by calling the `EndTimedEvent` method. This method can also take parameters, which will be used to update the original parameters.

```csharp
// start a timed event
var parameters = new Dictionary<string, string> {
    {"connection-type", "3G"}
}
FlurryAgent.LogEvent("User Started Login", parameters, true);

// do the login work here...

// end the timed event
FlurryAgent.EndTimedEvent("User Started Login");
```

### Tracking Demographics
All three platforms allow you to track various user demographics:

* A user id to identify a single user (`SetUserId`)
* A user's age (`SetAge`)
* A user's gender (`SetGender`)

### Tracking Location
Flurry Analytics can also track where in the world your app is being used.

#### Android
If you have added the `ACCESS_COARSE_LOCATION` or `ACCESS_FINE_LOCATION` permissions to the manifest, then the location will automatically be tracked. If not, only country level location information will be available. 
To disable detailed location reporting even when your app has permission, call `FlurryAgent.SetReportLocation(false);` before calling `FlurryAgent.onStartSession();`
After disabling automatic location tracking, you can still setn location data to Flurry: `FlurryAgent.SetLocation(latitude, longitude);`.

#### iOS
Flurry Analytics for iOS does not automatically track location, but it is easy to obtain a location and send it to Flurry. Flurry will keep only the last location information.
*NOTE: If your app does not use location services in a meaningful way, using `CLLocationManager` can result in Apple rejecting the app submission.*

```csharp
CLLocationManager locationManager = new CLLocationManager();
locationManager.LocationsUpdated += (sender, e) => {
    // there will always be at least one in e.Locations
    CLLocation location = e.Locations[0];
    // send the location to Flurry
    FlurryAgent.SetLocation(location.Coordinate.Latitude,
                            location.Coordinate.Longitude,
                            location.HorizontalAccuracy,
                            location.VerticalAccuracy);
    // we no longer need the location tracking
    locationManager.StopUpdatingLocation();
};
locationManager.StartUpdatingLocation();
```

#### Windows Phone
Flurry Analytics for Windows Phone also does not automatically track location. However, it is also easy to obtain the location and send it to Flurry.
*NOTE: Make sure you have added the `ID_CAP_LOCATION` capability to the manifest*

```csharp
Geolocator geolocator = new Geolocator();
geolocator.DesiredAccuracyInMeters = 50; // any value can be here
Geoposition geoposition = await geolocator.GetGeopositionAsync();
FlurryWP8SDK.Api.SetLocation(geoposition.Coordinate.Latitude, 
                             geoposition.Coordinate.Longitude, 
                             geoposition.Coordinate.Accuracy);
```

## FAQ
### Can I Use Secure Transport?
Yes. Each platform allows secure data transporting:

* **Windows Phone** provides the `FlurryWP8SDK.Api.SetSecureTransportEnabled();` method
* **iOS** provides the `FlurryAgent.SetSecureTransportEnabled(true);` method
* **Android** provides the `FlurryAgent.UseHttps = true;` property

### How Much Data Does The Flurry Agent Send?
All data sent by the Flurry Agent is sent in a compact binary format. The total amount of data can vary but in most cases it is around 2Kb per session.

### What data does the Flurry Agent send?
The data sent by the Flurry Agent includes time stamps, logged events, logged errors, and various device specific  information. This is the same information that can be seen in the custom event logs on in the Event Analytics 
section. We do not collect personally identifiable information.   