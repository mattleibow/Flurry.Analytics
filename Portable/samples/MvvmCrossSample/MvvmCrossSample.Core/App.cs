using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using Flurry.Analytics.Portable;

using MvvmCrossSample.Core.ViewModels;

namespace MvvmCrossSample.Core
{
	/// <summary>
	/// Define the App type.
	/// </summary>
	public class App : MvxApplication
	{
		/// <summary>
		/// Initializes this instance.
		/// </summary>
		public override void Initialize()
		{
			this.CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			this.SetUpAnalytics();

			// Start the app with the First View Model.
			this.RegisterAppStart<MainViewModel>();
		}

		private void SetUpAnalytics()
		{
			AnalyticsApi.SetAppVersion("2.0.0.0");
			AnalyticsApi.SetSessionContinueTimeout(30);
		}
	}
}