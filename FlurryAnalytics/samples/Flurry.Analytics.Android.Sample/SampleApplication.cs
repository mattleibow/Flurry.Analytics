using Android.App;
using System;
using Android.Runtime;

namespace Flurry.Analytics.Android.Sample
{
	[Application]
	public class SampleApplication : Application
	{
		public SampleApplication (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer)
		{
		}

		public override void OnCreate ()
		{
			base.OnCreate ();

			FlurryAgent.Init (this, "36TWHT3RMTBTF2G46KGH");
		}
	}
}
