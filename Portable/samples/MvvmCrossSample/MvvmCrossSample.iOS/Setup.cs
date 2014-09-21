using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Dialog.Touch;
using Flurry.Analytics.Portable;

namespace MvvmCrossSample.iOS
{
	public class Setup : MvxTouchDialogSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, IMvxTouchViewPresenter presenter)
			: base(applicationDelegate, presenter)
		{
			// set up the iOS Application Api Key
			AnalyticsApi.ApiKey = "PQSZJRK4B5BW8Q7YQQXF";

			// Starting and ending the sessions specifically for iOS
			AnalyticsApi.StartSession();
		}

		protected override IMvxApplication CreateApp()
		{
			return new Core.App();
		}
	}
}
