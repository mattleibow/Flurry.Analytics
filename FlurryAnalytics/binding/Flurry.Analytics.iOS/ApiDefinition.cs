using System;

using Foundation;

namespace Flurry.Analytics {

	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "FlurryDelegate")]
	public partial interface FlurryAgentDelegate
	{
		[Abstract, Export ("flurrySessionDidCreateWithInfo:")]
		void OnSessionCreated (NSDictionary info);
	}

	[BaseType (typeof (NSObject), Name = "Flurry")]
	public partial interface FlurryAgent {
		
		[Static, Field ("kSyndicationiOSDeepLink", "__Internal")]
		NSString SyndicationiOSDeepLink { get; }

		[Static, Field ("kSyndicationAndroidDeepLink", "__Internal")]
		NSString SyndicationAndroidDeepLink { get; }

		[Static, Field ("kSyndicationWebDeepLink", "__Internal")]
		NSString SyndicationWebDeepLink { get; }


		[Static, Export ("setDelegate:")]
		void SetDelegate (FlurryAgentDelegate del);

		[Static, Export ("setAppVersion:")]
		void SetAppVersion (string version);

		[Static, Export ("getFlurryAgentVersion")]
		string FlurryAgentVersion { get; }

		[Static, Export ("setShowErrorInLogEnabled:")]
		void SetShowErrorInLogEnabled (bool value);

		[Static, Export ("setDebugLogEnabled:")]
		void SetDebugLogEnabled (bool value);

		[Static, Export ("setLogLevel:")]
		void SetLogLevel (FlurryLogLevel logLevel);

		[Static, Export ("setSessionContinueSeconds:")]
		void SetSessionContinueSeconds (int seconds);

		[Static, Export ("setCrashReportingEnabled:")]
		void SetCrashReportingEnabled (bool enabled);

		[Static, Export ("startSession:")]
		void StartSession (string apiKey);

		[Static, Export ("startSession:withOptions:")]
		void StartSession (string apiKey, NSObject options);

		[Static, Export ("activeSessionExists")]
		bool ActiveSessionExists { get; }

		[Static, Export("getSessionID")]
		string SessionId { get; }

		[Static, Export ("pauseBackgroundSession")]
		void PauseBackgroundSession ();

		[Static, Export ("addSessionOrigin:withDeepLink:")]
		void AddSessionOrigin (string sessionOriginName, string deepLink);

		[Static, Export ("addSessionOrigin:")]
		void AddSessionOrigin (string sessionOriginName);

		[Static, Export ("sessionProperties:")]
		void SetSessionProperties (NSDictionary parameters);

		[Static, Export ("addOrigin:withVersion:")]
		void AddOrigin (string originName, string originVersion);

		[Static, Export ("addOrigin:withVersion:withParameters:")]
		void AddOrigin (string originName, string originVersion, NSDictionary parameters);

		[Static, Export ("logEvent:")]
		FlurryEventStatus LogEvent (string eventName);

		[Static, Export ("logEvent:withParameters:")]
		FlurryEventStatus LogEvent (string eventName, NSDictionary parameters);

		[Static, Export ("logError:message:exception:")]
		void LogError (string errorID, string message, NSException exception);

		[Static, Export ("logError:message:error:")]
		void LogError (string errorID, string message, NSError error);

		[Static, Export ("logEvent:timed:")]
		FlurryEventStatus LogEvent (string eventName, bool timed);

		[Static, Export ("logEvent:withParameters:timed:")]
		FlurryEventStatus LogEvent (string eventName, NSDictionary parameters, bool timed);

		[Static, Export ("endTimedEvent:withParameters:")]
		void EndTimedEvent (string eventName, [NullAllowed] NSDictionary parameters);

		[Obsolete("Use LogAllPageViewsForTarget instead.")]
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

		[Static, Export("setPulseEnabled:")]
		void SetPulseEnabled (bool enabled);

		[Static, Export ("logEvent:syndicationID:parameters:")]
		FlurryEventStatus LogEvent (FlurrySyndicationEvent syndicationEvent, string syndicationID, NSDictionary parameters);
	}

	[BaseType (typeof (NSObject), Name = "FlurryWatch")]
	public partial interface FlurryWatchAgent {

		[Static, Export ("logWatchEvent:")]
		FlurryEventStatus LogWatchEvent (string eventName);

		[Static, Export ("logWatchEvent:withParameters:")]
		FlurryEventStatus LogWatchEvent (string eventName, NSDictionary parameters);

		[Static, Export ("logWatchError:message:exception:")]
		void LogWatchError (string errorID, string message, NSException exception);

		[Static, Export ("logWatchError:message:error:")]
		void LogWatchError (string errorID, string message, NSError error);
	}
}