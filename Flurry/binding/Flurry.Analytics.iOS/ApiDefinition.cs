using System;

using Foundation;
#if __TVOS__
using JavaScriptCore;
#endif

namespace Flurry.Analytics {

	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "FlurryDelegate")]
	public partial interface FlurryAgentDelegate
	{
		// - (void)flurrySessionDidCreateWithInfo:(NSDictionary*)info;
		[Abstract, Export ("flurrySessionDidCreateWithInfo:")]
		void OnSessionCreated (NSDictionary info);
	}

	[BaseType (typeof (NSObject), Name = "Flurry")]
	public partial interface FlurryAgent {
		
		// extern NSString* const kSyndicationiOSDeepLink;
		[Static, Field ("kSyndicationiOSDeepLink", "__Internal")]
		NSString SyndicationiOSDeepLink { get; }

		// extern NSString* const kSyndicationAndroidDeepLink;
		[Static, Field ("kSyndicationAndroidDeepLink", "__Internal")]
		NSString SyndicationAndroidDeepLink { get; }

		// extern NSString* const kSyndicationWebDeepLink;
		[Static, Field ("kSyndicationWebDeepLink", "__Internal")]
		NSString SyndicationWebDeepLink { get; }


		// + (void)setDelegate:(id<FlurryDelegate>)delegate;
		[Static, Export ("setDelegate:")]
		void SetDelegate (FlurryAgentDelegate del);

		// + (void)setAppVersion:(NSString *)version;
		[Static, Export ("setAppVersion:")]
		void SetAppVersion (string version);

#if __TVOS__

		[Static, Export ("setTVEventFlushCount:")]
		void SetTVEventFlushCount (short count);

		[Static, Export ("setTVSessionReportingInterval:")]
		void SetTVSessionReportingInterval (short duration);

#endif

		// + (NSString *)getFlurryAgentVersion;
		[Static, Export ("getFlurryAgentVersion")]
		string FlurryAgentVersion { get; }

		// + (void)setShowErrorInLogEnabled:(BOOL)value;
		[Static, Export ("setShowErrorInLogEnabled:")]
		void SetShowErrorInLogEnabled (bool value);

		// + (void)setDebugLogEnabled:(BOOL)value;
		[Static, Export ("setDebugLogEnabled:")]
		void SetDebugLogEnabled (bool value);

		// + (void)setLogLevel:(FlurryLogLevel)value;
		[Static, Export ("setLogLevel:")]
		void SetLogLevel (FlurryLogLevel logLevel);

		// + (void)setSessionContinueSeconds:(int)seconds;
		[Static, Export ("setSessionContinueSeconds:")]
		void SetSessionContinueSeconds (int seconds);

#if !__TVOS__

		// + (void)setCrashReportingEnabled:(BOOL)value;
		[Static, Export ("setCrashReportingEnabled:")]
		void SetCrashReportingEnabled (bool enabled);

#endif

		// + (void)startSession:(NSString *)apiKey;
		[Static, Export ("startSession:")]
		void StartSession (string apiKey);

		// + (void) startSession:(NSString *)apiKey withOptions:(id)options;
		[Static, Export ("startSession:withOptions:")]
		void StartSession (string apiKey, NSObject options);

		// + (BOOL)activeSessionExists;
		[Static, Export ("activeSessionExists")]
		bool ActiveSessionExists { get; }

		// + (NSString*)getSessionID;
		[Static, Export("getSessionID")]
		string SessionId { get; }

#if !__TVOS__

		// + (void)pauseBackgroundSession;
		[Static, Export ("pauseBackgroundSession")]
		void PauseBackgroundSession ();

#endif

		// + (void)addSessionOrigin:(NSString *)sessionOriginName  withDeepLink:(NSString*)deepLink;
		[Static, Export ("addSessionOrigin:withDeepLink:")]
		void AddSessionOrigin (string sessionOriginName, string deepLink);

		// + (void)addSessionOrigin:(NSString *)sessionOriginName;
		[Static, Export ("addSessionOrigin:")]
		void AddSessionOrigin (string sessionOriginName);

		// + (void)sessionProperties:(NSDictionary *)parameters;
		[Static, Export ("sessionProperties:")]
		void SetSessionProperties (NSDictionary parameters);

		// + (void)addOrigin:(NSString *)originName withVersion:(NSString*)originVersion;
		[Static, Export ("addOrigin:withVersion:")]
		void AddOrigin (string originName, string originVersion);

		// + (void)addOrigin:(NSString *)originName withVersion:(NSString*)originVersion withParameters:(NSDictionary *)parameters;
		[Static, Export ("addOrigin:withVersion:withParameters:")]
		void AddOrigin (string originName, string originVersion, NSDictionary parameters);

		// + (FlurryEventRecordStatus)logEvent:(NSString *)eventName;
		[Static, Export ("logEvent:")]
		FlurryEventRecordStatus LogEvent (string eventName);

		// + (FlurryEventRecordStatus)logEvent:(NSString *)eventName withParameters:(NSDictionary *)parameters;
		[Static, Export ("logEvent:withParameters:")]
		FlurryEventRecordStatus LogEvent (string eventName, NSDictionary parameters);

		// + (void)logError:(NSString *)errorID message:(NSString *)message exception:(NSException *)exception;
		[Static, Export ("logError:message:exception:")]
		void LogError (string errorID, string message, NSException exception);

		// + (void)logError:(NSString *)errorID message:(NSString *)message error:(NSError *)error;
		[Static, Export ("logError:message:error:")]
		void LogError (string errorID, string message, NSError error);

		// + (FlurryEventRecordStatus)logEvent:(NSString *)eventName timed:(BOOL)timed;
		[Static, Export ("logEvent:timed:")]
		FlurryEventRecordStatus LogEvent (string eventName, bool timed);

		// + (FlurryEventRecordStatus)logEvent:(NSString *)eventName withParameters:(NSDictionary *)parameters timed:(BOOL)timed;
		[Static, Export ("logEvent:withParameters:timed:")]
		FlurryEventRecordStatus LogEvent (string eventName, NSDictionary parameters, bool timed);

		// + (void)endTimedEvent:(NSString *)eventName withParameters:(NSDictionary *)parameters;
		[Static, Export ("endTimedEvent:withParameters:")]
		void EndTimedEvent (string eventName, [NullAllowed] NSDictionary parameters);

#if !__TVOS__

		// + (void)logAllPageViews:(id)target __attribute__ ((deprecated));
		[Obsolete("Use LogAllPageViewsForTarget instead.")]
		[Static, Export ("logAllPageViews:")]
		void LogAllPageViews (NSObject target);

		// + (void)logAllPageViewsForTarget:(id)target;
		[Static, Export ("logAllPageViewsForTarget:")]
		void LogAllPageViewsForTarget (NSObject target);

		// + (void)stopLogPageViewsForTarget:(id)target;
		[Static, Export ("stopLogPageViewsForTarget:")]
		void StopLogPageViewsForTarget (NSObject target);

		// + (void)logPageView;
		[Static, Export ("logPageView")]
		void LogPageView ();

#endif

		// + (void)setUserID:(NSString *)userID;
		[Static, Export ("setUserID:")]
		void SetUserId (string userId);

		// + (void)setAge:(int)age;
		[Static, Export ("setAge:")]
		void SetAge (int age);

		// + (void)setGender:(NSString *)gender;
		[Static, Export ("setGender:")]
		void SetGender (string gender);

		// + (void)setLatitude:(double)latitude longitude:(double)longitude horizontalAccuracy:(float)horizontalAccuracy verticalAccuracy:(float)verticalAccuracy;
		[Static, Export ("setLatitude:longitude:horizontalAccuracy:verticalAccuracy:")]
		void SetLocation (double latitude, double longitude, float horizontalAccuracy, float verticalAccuracy);

		// + (void)setSessionReportsOnCloseEnabled:(BOOL)sendSessionReportsOnClose;
		[Static, Export ("setSessionReportsOnCloseEnabled:")]
		void SetSessionReportsOnCloseEnabled (bool sendSessionReportsOnClose);

		// + (void)setSessionReportsOnPauseEnabled:(BOOL)setSessionReportsOnPauseEnabled;
		[Static, Export ("setSessionReportsOnPauseEnabled:")]
		void SetSessionReportsOnPauseEnabled (bool enabled);

		// + (void)setBackgroundSessionEnabled:(BOOL)setBackgroundSessionEnabled;
		[Static, Export ("setBackgroundSessionEnabled:")]
		void SetBackgroundSessionEnabled (bool enabled);

		// + (void)setEventLoggingEnabled:(BOOL)value;
		[Static, Export ("setEventLoggingEnabled:")]
		void SetEventLoggingEnabled (bool enabled);

#if !__TVOS__

		// + (void)setPulseEnabled:(BOOL)value;
		[Static, Export("setPulseEnabled:")]
		void SetPulseEnabled (bool enabled);

#endif

		// + (FlurryEventRecordStatus) logEvent:(FlurrySyndicationEvent) syndicationEvent syndicationID:(NSString*) syndicationID parameters:(NSDictionary*) parameters;
		[Static, Export ("logEvent:syndicationID:parameters:")]
		FlurryEventRecordStatus LogEvent (FlurrySyndicationEvent syndicationEvent, string syndicationID, NSDictionary parameters);

#if __TVOS__

		[Static, Export ("registerJSContextWithContext:")]
		void RegisterJSContextWithContext (JSContext jscontext);

#endif
	}

	[BaseType (typeof (NSObject), Name = "FlurryWatch")]
	public partial interface FlurryWatchAgent {

		// + (FlurryEventRecordStatus)logWatchEvent:(NSString *)eventName;
		[Static, Export ("logWatchEvent:")]
		FlurryEventRecordStatus LogWatchEvent (string eventName);

		// + (FlurryEventRecordStatus)logWatchEvent:(NSString *)eventName withParameters:(NSDictionary *)parameters;
		[Static, Export ("logWatchEvent:withParameters:")]
		FlurryEventRecordStatus LogWatchEvent (string eventName, NSDictionary parameters);

		// + (void) logWatchError:(NSString *)errorID message:(NSString *)message exception:(NSException *)exception  __attribute__ ((deprecated));
		[Obsolete ("This routine is deprecated and will be removed in the next release, please use LogWatchEvent in its place.")]
		[Static, Export ("logWatchError:message:exception:")]
		void LogWatchError (string errorID, string message, NSException exception);

		// + (void) logWatchError:(NSString *)errorID message:(NSString *)message error:(NSError *)error  __attribute__ ((deprecated));
		[Obsolete ("This routine is deprecated and will be removed in the next release, please use LogWatchEvent in its place.")]
		[Static, Export ("logWatchError:message:error:")]
		void LogWatchError (string errorID, string message, NSError error);
	}
}