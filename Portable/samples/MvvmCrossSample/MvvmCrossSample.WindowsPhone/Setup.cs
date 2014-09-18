using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Flurry.Analytics.Portable;

namespace MvvmCrossSample.WindowsPhone
{
	public class Setup : MvxPhoneSetup
	{
		public Setup(PhoneApplicationFrame rootFrame)
			: base(rootFrame)
		{
			// set up the Windows Phone Application Api Key
			AnalyticsApi.ApiKey = "VVBG8GG7Y99CKDMRFJ6X";
			
			// Start the sessions specifically for Windows Phone
			PhoneApplicationService.Current.Launching += (sender, args) => AnalyticsApi.StartSession();
			PhoneApplicationService.Current.Activated += (sender, args) => AnalyticsApi.StartSession();
		}

		protected override IMvxApplication CreateApp()
		{
			return new Core.App();
		}
	}
}