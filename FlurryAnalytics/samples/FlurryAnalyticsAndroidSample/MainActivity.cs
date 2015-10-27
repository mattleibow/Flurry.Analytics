using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;

using Flurry.Analytics;

namespace FlurryAnalyticsAndroidSample
{
	[Activity (Label = "Flurry Analytics", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			TextView VersionLabel = FindViewById<TextView> (Resource.Id.VersionLabel);
			EditText EventParameterText = FindViewById<EditText> (Resource.Id.EventParameterText);
			Button LogEventButton = FindViewById<Button> (Resource.Id.LogEventButton);

			VersionLabel.Text = FlurryAgent.ReleaseVersion;

			LogEventButton.Click += delegate {
				FlurryEventRecordStatus status;
				if (string.IsNullOrEmpty (EventParameterText.Text))
					status = FlurryAgent.LogEvent ("Button Click");
				else
					status = FlurryAgent.LogEvent ("Button Click", new Dictionary<string, string> { 
						{ "Log Parameter", EventParameterText.Text } 
					});

				using (Toast alert = Toast.MakeText (this, "Your event was logged along with the specified parameter. Result: " + status, ToastLength.Short))
					alert.Show ();
			};
		}

		protected override void OnStart ()
		{
			base.OnStart ();

			// this is not needed for android 4.0 and above
			FlurryAgent.OnStartSession (this);
		}

		protected override void OnStop ()
		{
			base.OnStop ();

			// this is not needed for android 4.0 and above
			FlurryAgent.OnEndSession (this);
		}
	}
}


