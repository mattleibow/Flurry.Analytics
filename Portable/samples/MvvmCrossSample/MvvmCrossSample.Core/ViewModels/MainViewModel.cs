// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the MainViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.MvvmCross.ViewModels;
using Flurry.Analytics.Portable;

namespace MvvmCrossSample.Core.ViewModels
{
	/// <summary>
	/// Define the MainViewModel type.
	/// </summary>
	public class MainViewModel : BaseViewModel
	{
		private readonly IMvxLocationWatcher locationWatcher;

		public MainViewModel(IMvxLocationWatcher locationWatcher)
		{
			this.locationWatcher = locationWatcher;
		}

		public void Init()
		{
			if (!locationWatcher.Started)
			{
				locationWatcher.Start(
					new MvxLocationOptions{Accuracy = MvxLocationAccuracy.Coarse},
					loc =>
					{
						UserLocation = loc;
						const double tolerance = 0.001;
						if (Math.Abs(loc.Coordinates.Latitude) > tolerance && 
							Math.Abs(loc.Coordinates.Longitude) > tolerance)
							locationWatcher.Stop();
					}, 
					error => { });
			}

			// defaults
			userAge = 0;
			userId = string.Empty;
			userGender = Gender.Unknown;
			userLocation = new MvxGeoLocation
			{
				Coordinates = new MvxCoordinates
				{
					Latitude = 0,
					Longitude = 0,
					Accuracy = 0
				}
			};
		}

		public bool IsFlurrySupported
		{
			get { return AnalyticsApi.IsSupported; }
		}

		public string FlurryApiKey
		{
			get { return AnalyticsApi.ApiKey; }
		}

		public string FlurryVersion
		{
			get { return AnalyticsApi.ApiVersion; }
		}

		private int userAge;
		public int UserAge
		{
			get { return userAge; }
			set
			{
				SetProperty(ref userAge, value, () => UserAge);
				AnalyticsApi.SetAge(userAge);
			}
		}

		private string userId;
		public string UserId
		{
			get { return userId; }
			set
			{
				SetProperty(ref userId, value, () => UserId);
				AnalyticsApi.SetUserId(userId);
			}
		}

		private Gender userGender;
		public Gender UserGender
		{
			get { return userGender; }
			set
			{
				SetProperty(ref userGender, value, () => UserGender);
				AnalyticsApi.SetGender(userGender);
			}
		}

		private MvxGeoLocation userLocation;
		public MvxGeoLocation UserLocation
		{
			get { return userLocation; }
			set
			{
				SetProperty(ref userLocation, value, () => UserLocation);
				AnalyticsApi.SetLocation(
					(float)userLocation.Coordinates.Latitude,
					(float)userLocation.Coordinates.Longitude,
					(float)(userLocation.Coordinates.Accuracy ?? 0));
			}
		}

		public ICommand ShowEventsCommand
		{
			get
			{
				return new MvxCommand(() =>
				{
					AnalyticsApi.LogEvent("Initiating events...");

					ShowViewModel<EventsViewModel>();
				});
			}
		}
	}
}
