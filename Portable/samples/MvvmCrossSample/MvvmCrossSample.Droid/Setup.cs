using Android.App;
using Android.Content;
using Android.OS;
using Cirrious.MvvmCross.Binding.Bindings.Target;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;

using Flurry.Analytics.Portable;
using MvvmCrossSample.Droid.Views;

namespace MvvmCrossSample.Droid
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext)
			: base(applicationContext)
		{
			// set up the Android Application Api Key
			AnalyticsApi.ApiKey = "36TWHT3RMTBTF2G46KGH";

			// Starting and ending the sessions specifically for Android is found in the BaseView
		}

		protected override IMvxApplication CreateApp()
		{
			return new Core.App();
		}
	}
}