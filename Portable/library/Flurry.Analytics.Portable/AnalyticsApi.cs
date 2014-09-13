using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

#if WINDOWS_PHONE
using NativeFlurry = FlurryWP8SDK.Api;
using NativeGender = FlurryWP8SDK.Models.Gender;
using NativeParameterCollection = System.Collections.Generic.List<FlurryWP8SDK.Models.Parameter>;
#elif __ANDROID__
using Android.Content;
using Java.Lang;
using NativeFlurry = Flurry.Analytics.FlurryAgent;
using NativeGender = Flurry.Analytics.Gender;
using NativeParameterCollection = System.Collections.Generic.IDictionary<System.String, System.String>;
#elif __IOS__
using MonoTouch.Foundation;
using NativeFlurry = Flurry.Analytics.FlurryAgent;
using NativeGender = Flurry.Analytics.Gender;
using NativeParameterCollection = MonoTouch.Foundation.NSDictionary;
#endif

namespace Flurry.Analytics.Portable
{
	/// <summary>
	/// The Flurry Android Analytics Agent allows you to track the usage and behavior of your Android application on 
	/// users' devices for viewing in the Flurry Analytics system.
	/// </summary>
	public static class AnalyticsApi
	{
		// Properties

		/// <summary>
		/// Gets or sets the Flurry Analytics application API key.
		/// </summary>
		/// <value>The API key.</value>
		public static string ApiKey { get; set; }

		// Platform specific methods

#if WINDOWS_PHONE 
		/// <summary>
		/// This method serves as the entry point to Flurry Analytics collection.
		/// The session will continue for the period the app is in the foreground until your app is backgrounded for the
		/// time specified in <see cref="SetSessionContinueTimeout"/>. If the app is resumed in that period the session 
		/// will continue, otherwise a new session will begin.
		/// </summary>
		/// <param name="apiKey">
		/// The Flurry Analytics application API key to use. This parameter will update the <see cref="ApiKey"/> 
		/// property.
		/// </param>
		public static void StartSession(string apiKey)
		{
			ApiKey = apiKey;

			CheckStartSessionParameters();

			NativeFlurry.StartSession(ApiKey);
		}
		/// <summary>
		/// This method serves as the entry point to Flurry Analytics collection.
		/// The session will continue for the period the app is in the foreground until your app is backgrounded for the
		/// time specified in <see cref="SetSessionContinueTimeout"/>. If the app is resumed in that period the session 
		/// will continue, otherwise a new session will begin.
		/// </summary>
		/// <remarks>
		/// This method requires that the <see cref="ApiKey"/> property has been set prior to calling this method. If 
		/// not, an ArgumentException will be thrown.
		/// </remarks>
		/// <exception cref="ArgumentException">
		/// This method requires that the <see cref="ApiKey"/> property has been set prior to calling this method. If 
		/// not, an ArgumentException will be thrown.
		/// </exception>
		public static void StartSession()
		{
			CheckStartSessionParameters();

			NativeFlurry.StartSession(ApiKey);
		}
		/// <summary>
		/// End a Flurry Analytics session.
		/// </summary>
		public static void EndSession()
		{
			NativeFlurry.EndSession();
		}
#elif __IOS__
		/// <summary>
		/// This method serves as the entry point to Flurry Analytics collection.
		/// The session will continue for the period the app is in the foreground until your app is backgrounded for the
		/// time specified in <see cref="SetSessionContinueTimeout"/>. If the app is resumed in that period the session 
		/// will continue, otherwise a new session will begin.
		/// </summary>
		/// <param name="apiKey">
		/// The Flurry Analytics application API key to use. This parameter will update the <see cref="ApiKey"/> 
		/// property.
		/// </param>
		public static void StartSession(string apiKey)
		{
			ApiKey = apiKey;

			CheckStartSessionParameters();

			NativeFlurry.StartSession(ApiKey);
		}
		/// <summary>
		/// This method serves as the entry point to Flurry Analytics collection.
		/// The session will continue for the period the app is in the foreground until your app is backgrounded for the
		/// time specified in <see cref="SetSessionContinueTimeout"/>. If the app is resumed in that period the session 
		/// will continue, otherwise a new session will begin.
		/// </summary>
		/// <remarks>
		/// This method requires that the <see cref="ApiKey"/> property has been set prior to calling this method. If 
		/// not, an ArgumentException will be thrown.
		/// </remarks>
		/// <exception cref="ArgumentException">
		/// This method requires that the <see cref="ApiKey"/> property has been set prior to calling this method. If 
		/// not, an ArgumentException will be thrown.
		/// </exception>
		public static void StartSession()
		{
			CheckStartSessionParameters();

			NativeFlurry.StartSession(ApiKey);
		}
#elif __ANDROID__
		/// <summary>
		/// This method serves as the entry point to Flurry Analytics collection.
		/// The session will continue for the period the app is in the foreground until your app is backgrounded for the
		/// time specified in <see cref="SetSessionContinueTimeout"/>. If the app is resumed in that period the session 
		/// will continue, otherwise a new session will begin.
		/// </summary>
		/// <param name="context">
		/// A reference to a <see cref="Android.Content.Context"/> object such as an <see cref="Android.App.Activity"/> 
		/// or an <see cref="Android.App.Activity"/>.
		/// </param>
		/// <param name="apiKey">
		/// The Flurry Analytics application API key to use. This parameter will update the <see cref="ApiKey"/> 
		/// property.
		/// </param>
		public static void StartSession(Context context, string apiKey)
		{
			ApiKey = apiKey;

			CheckStartSessionParameters();

			NativeFlurry.OnStartSession(context, ApiKey);
		}
		/// <summary>
		/// This method serves as the entry point to Flurry Analytics collection.
		/// The session will continue for the period the app is in the foreground until your app is backgrounded for the
		/// time specified in <see cref="SetSessionContinueTimeout"/>. If the app is resumed in that period the session 
		/// will continue, otherwise a new session will begin.
		/// </summary>
		/// <param name="context">
		/// A reference to a <see cref="Android.Content.Context"/> object such as an <see cref="Android.App.Activity"/> 
		/// or an <see cref="Android.App.Activity"/>.
		/// </param>
		/// <remarks>
		/// This method requires that the <see cref="ApiKey"/> property has been set prior to calling this method. If 
		/// not, an ArgumentException will be thrown.
		/// </remarks>
		/// <remarks>
		/// The session implementation for the Android SDK is implemented as a stack. It is important to match any call 
		/// to <see cref="StartSession"/> in the Android <see cref="Android.App.Activity.OnStart"/> method with a call 
		/// to <see cref="EndSession"/> in the Android <see cref="Android.App.Activity.OnEnd"/> method.
		/// </remarks>
		/// <exception cref="ArgumentException">
		/// This method requires that the <see cref="ApiKey"/> property has been set prior to calling this method. If 
		/// not, an ArgumentException will be thrown.
		/// </exception>
		public static void StartSession(Context context)
		{
			CheckStartSessionParameters();

			NativeFlurry.OnStartSession(context, ApiKey);
		}
		/// <summary>
		/// End a Flurry Analytics session.
		/// </summary>
		/// <param name="context">
		/// A reference to a <see cref="Android.Content.Context"/> object such as an <see cref="Android.App.Activity"/> 
		/// or an <see cref="Android.App.Activity"/>.
		/// </param>
		public static void EndSession(Context context)
		{
			NativeFlurry.OnEndSession(context);
		}
#endif

		// Methods

		/// <summary>
		/// Returns True if Flurry Analytics is supported on this platform,
		/// otherwise, False.
		/// </summary>
		public static bool IsSupported
		{
			get
			{
#if WINDOWS_PHONE || __ANDROID__ || __IOS__
				return true;
#else
				return false;
#endif
			}
		}

		/// <summary>
		/// Explicitly specifies the App Version that Flurry Analytics will use to group collected analytics data.
		/// </summary>
		/// <param name="version">The app version to use for the app.</param>
		public static void SetAppVersion(string version)
		{
#if WINDOWS_PHONE
			NativeFlurry.SetVersion(version);
#elif __ANDROID__
			NativeFlurry.SetVersionName(version);
#elif __IOS__
			NativeFlurry.SetAppVersion(version);
#endif
		}

		public static void SetUserId(string version)
		{
#if WINDOWS_PHONE || __ANDROID__ || __IOS__
			NativeFlurry.SetUserId(version);
#endif
		}

		public static void SetSessionContinueTimeout(int seconds)
		{
#if WINDOWS_PHONE
			NativeFlurry.SetSessionContinueSeconds(seconds);
#elif __ANDROID__
			NativeFlurry.SetContinueSessionMillis(seconds*1000);
#elif __IOS__
			NativeFlurry.SetSessionContinueSeconds(seconds);
#endif
		}

		public static void EnableSecureTransport()
		{
#if WINDOWS_PHONE
			NativeFlurry.SetSecureTransportEnabled();
#elif __ANDROID__
			NativeFlurry.UseHttps = true;
#elif __IOS__
			NativeFlurry.SetSecureTransportEnabled(true);
#endif
		}

		public static void SetLocation(float latitude, float longitude, float accuracy)
		{
#if WINDOWS_PHONE
			NativeFlurry.SetLocation(latitude, longitude, accuracy);
#elif __ANDROID__
			NativeFlurry.SetLocation(latitude, longitude);
#elif __IOS__
			NativeFlurry.SetLocation(latitude, longitude, accuracy, accuracy);
#endif
		}

		public static void SetAge(int age)
		{
#if WINDOWS_PHONE || __ANDROID__ || __IOS__
			NativeFlurry.SetAge(age);
#endif
		}

		public static void SetGender(Gender gender)
		{
#if WINDOWS_PHONE || __ANDROID__ || __IOS__
			NativeFlurry.SetGender((NativeGender)gender);
#endif
		}

		public static void LogPageView()
		{
#if WINDOWS_PHONE || __IOS__
			NativeFlurry.LogPageView();
#elif __ANDROID__
			NativeFlurry.OnPageView();
#endif
		}

		public static void LogEvent(string eventId)
		{
#if WINDOWS_PHONE || __ANDROID__ || __IOS__
			NativeFlurry.LogEvent(eventId);
#endif
		}

		public static void LogEvent(string eventId, IDictionary<string, string> parameters)
		{
#if WINDOWS_PHONE || __ANDROID__ || __IOS__
			NativeParameterCollection p = GetParameters(parameters);
			if (p == null)
				LogEvent(eventId);
			else
				NativeFlurry.LogEvent(eventId, p);
#endif
		}

		public static void LogEvent(string eventId, bool timed)
		{
#if WINDOWS_PHONE || __ANDROID__ || __IOS__
			NativeFlurry.LogEvent(eventId, timed);
#endif
		}

		public static void LogEvent(string eventId, IDictionary<string, string> parameters, bool timed)
		{
#if WINDOWS_PHONE || __ANDROID__ || __IOS__
			NativeParameterCollection p = GetParameters(parameters);
			if (p == null)
				LogEvent(eventId, timed);
			else
				NativeFlurry.LogEvent(eventId, p, timed);
#endif
		}

		public static TimedEvent LogTimedEvent(string eventId)
		{
			LogEvent(eventId, true);
			return new TimedEvent(eventId);
		}

		public static TimedEvent LogTimedEvent(string eventId, IDictionary<string, string> parameters)
		{
			LogEvent(eventId, parameters, true);
			return new TimedEvent(eventId);
		}

		public static TimedEvent LogTimedEvent(string eventId, IDictionary<string, string> startParameters, IDictionary<string, string> endParameters)
		{
			LogEvent(eventId, startParameters, true);
			return new TimedEvent(eventId, endParameters);
		}

		public static void EndTimedEvent(string eventId)
		{
#if WINDOWS_PHONE || __ANDROID__ || __IOS__
			NativeFlurry.EndTimedEvent(eventId);
#endif
		}

		public static void EndTimedEvent(string eventId, IDictionary<string, string> parameters)
		{
#if WINDOWS_PHONE || __ANDROID__ || __IOS__
			NativeParameterCollection p = GetParameters(parameters);
			if (p == null)
				EndTimedEvent(eventId);
			else
				NativeFlurry.EndTimedEvent(eventId, p);
#endif
		}

		public static void LogError(System.Exception exception)
		{
			LogError(exception.Message, exception);
		}

		public static void LogError(string message, System.Exception exception)
		{
#if __IOS__
			NativeFlurry.LogError(
				string.Format(exception.GetType().FullName, message), 
				exception.ToString(),
				new NSException (exception.GetType().FullName, exception.Message, null));
#elif __ANDROID__
			Java.Lang.Exception javaEx = new Java.Lang.Exception(exception.Message);
			StackTrace stackTrace = new StackTrace(exception, true);
			StackTraceElement[] trace = new StackTraceElement[stackTrace.FrameCount];
			for (int index = 0; index < stackTrace.FrameCount; ++index)
			{
				StackFrame frame = stackTrace.GetFrame(index);
				trace[index] = new StackTraceElement(frame.GetMethod().DeclaringType.Name, frame.GetMethod().Name, frame.GetFileName(), frame.GetFileLineNumber());
			}
			javaEx.SetStackTrace(trace);
			NativeFlurry.OnError(
				string.Format(exception.GetType().FullName, message),
				exception.ToString(),
				javaEx);
#elif WINDOWS_PHONE
			NativeFlurry.LogError(message, exception);
#endif
		}

		// Helper Methods

#if WINDOWS_PHONE || __ANDROID__ || __IOS__
		private static NativeParameterCollection GetParameters(IDictionary<string, string> parameters)
		{
			if (parameters == null || parameters.Count == 0)
				return null;

#if WINDOWS_PHONE
			return parameters.Select(p => new FlurryWP8SDK.Models.Parameter(p.Key, p.Value)).ToList();
#elif __ANDROID__
			return parameters;
#elif __IOS__
			return NSDictionary.FromObjectsAndKeys(
				parameters.Values.Cast<object>().ToArray(), 
				parameters.Keys.Cast<object>().ToArray());
#endif
		}

		private static void CheckStartSessionParameters()
		{
			if (string.IsNullOrEmpty(ApiKey))
			{
				throw new ArgumentException (
					"An API key must be specified. Either use the overload that takes an API key, or first set the " +
					"ApiKey property prior to calling the StartSession method.");
			}
		}
#endif
	}
}
