using System;

using MonoTouch.Foundation;

namespace Flurry.Analytics {

	[BaseType (typeof (NSObject), Name="Flurry")]
	public partial interface FlurryAgent {

		[Static, Export ("setAppVersion:")]
		void SetAppVersion (string version);

		[Static, Export ("getFlurryAgentVersion")]
		string GetFlurryAgentVersion ();

		[Static, Export ("setShowErrorInLogEnabled:")]
		void SetShowErrorInLogEnabled (bool value);

		[Static, Export ("setDebugLogEnabled:")]
		void SetDebugLogEnabled (bool value);

		[Static, Export ("setLogLevel:")]
		void SetLogLevel (FlurryLogLevel logLevel);

		[Static, Export ("setSessionContinueSeconds:")]
		void SetSessionContinueSeconds (int seconds);

		[Static, Export ("setSecureTransportEnabled:")]
		void SetSecureTransportEnabled (bool value);

		[Static, Export ("setCrashReportingEnabled:")]
		void SetCrashReportingEnabled (bool enabled);

		[Static, Export ("startSession:")]
		void StartSession (string apiKey);

		[Static, Export ("startSession:withOptions:")]
		void StartSession (string apiKey, NSObject options);

		[Static, Export ("pauseBackgroundSession")]
		void PauseBackgroundSession ();

		[Static, Export ("addOrigin:withVersion:")]
		void AddOrigin (string originName, string originVersion);

		[Static, Export ("addOrigin:withVersion:withParameters:")]
		void AddOrigin (string originName, string originVersion, NSDictionary parameters);

		[Static, Export ("logEvent:")]
		void LogEvent (string eventName);

		[Static, Export ("logEvent:withParameters:")]
		void LogEvent (string eventName, NSDictionary parameters);

		[Static, Export ("logError:message:exception:")]
		void LogError (string errorID, string message, NSException exception);

		[Static, Export ("logError:message:error:")]
		void LogError (string errorID, string message, NSError error);

		[Static, Export ("logEvent:timed:")]
		void LogEvent (string eventName, bool timed);

		[Static, Export ("logEvent:withParameters:timed:")]
		void LogEvent (string eventName, NSDictionary parameters, bool timed);

		[Static, Export ("endTimedEvent:withParameters:")]
		void EndTimedEvent (string eventName, NSDictionary parameters);

		[Static, Export ("logAllPageViews:")]
		void LogAllPageViews (NSObject target);

		[Static, Export ("logAllPageViewsForTarget:")]
		void LogAllPageViewsForTarget (NSObject target);

		[Static, Export ("stopLogPageViewsForTarget:")]
		void StopLogPageViewsForTarget (NSObject target);

		[Static, Export ("logPageView")]
		void LogPageView ();

		[Static, Export ("setUserID:")]
		void SetUserId (string userId);

		[Static, Export ("setAge:")]
		void SetAge (int age);

		[Static, Export ("setGender:")]
		void SetGender (string gender);

		[Static, Export ("setLatitude:longitude:horizontalAccuracy:verticalAccuracy:")]
		void SetLocation (double latitude, double longitude, float horizontalAccuracy, float verticalAccuracy);

		[Static, Export ("setSessionReportsOnCloseEnabled:")]
		void SetSessionReportsOnCloseEnabled (bool sendSessionReportsOnClose);

		[Static, Export ("setSessionReportsOnPauseEnabled:")]
		void SetSessionReportsOnPauseEnabled (bool enabled);

		[Static, Export ("setBackgroundSessionEnabled:")]
		void SetBackgroundSessionEnabled (bool enabled);

		[Static, Export ("setEventLoggingEnabled:")]
		void SetEventLoggingEnabled (bool enabled);
	}
}