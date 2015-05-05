using Cirrious.CrossCore;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;
using Foundation;
using UIKit;

namespace MvvmCrossSample.iOS
{
	[Register("AppDelegate")]
	public class AppDelegate : MvxApplicationDelegate
	{
		private UIWindow window;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			window = new UIWindow(UIScreen.MainScreen.Bounds);

			MvxModalNavSupportTouchViewPresenter presenter = new MvxModalNavSupportTouchViewPresenter(this, window);

			Setup setup = new Setup(this, presenter);
			setup.Initialize();

			IMvxAppStart startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();

			window.MakeKeyAndVisible();

			return true;
		}
	}
}