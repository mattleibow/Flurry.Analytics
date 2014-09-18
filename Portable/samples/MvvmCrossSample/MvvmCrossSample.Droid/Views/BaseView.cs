using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Flurry.Analytics.Portable;

namespace MvvmCrossSample.Droid.Views
{
	public abstract class BaseView : MvxActivity
	{
		protected override void OnStart()
		{
			base.OnStart();

			AnalyticsApi.StartSession(this);
		}

		protected override void OnStop()
		{
			base.OnStop();

			AnalyticsApi.EndSession(this);
		}
	}
}