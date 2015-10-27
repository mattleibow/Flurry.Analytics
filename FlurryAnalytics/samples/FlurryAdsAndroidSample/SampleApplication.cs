using System;
using Android.App;
using Android.Runtime;
using Android.Util;

using Flurry.Analytics;

[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]

namespace FlurryAdsAndroidSample
{
	[Application]
	public class SampleApplication : Application
	{
		public SampleApplication (IntPtr javaReference, JniHandleOwnership transfer)
			: base (javaReference, transfer)
		{
		}

		public override void OnCreate ()
		{
			base.OnCreate ();

			FlurryAgent.SetLogEnabled (true);
			FlurryAgent.SetLogEvents (true);
			FlurryAgent.SetLogLevel (LogPriority.Verbose);
			FlurryAgent.Init (this, "36TWHT3RMTBTF2G46KGH");
		}
	}
}
