using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Flurry.Analytics.Portable;

namespace MvvmCrossSample.Core.ViewModels
{
	public class EventsViewModel : BaseViewModel
	{
		public void Init()
		{
			IsWorking = false;
		}

		private bool isWorking;
		public bool IsWorking
		{
			get { return isWorking; }
			set { SetProperty(ref isWorking, value, () => IsWorking); }
		}

		private string eventParameter;
		public string EventParameter
		{
			get { return eventParameter; }
			set { SetProperty(ref eventParameter, value, () => EventParameter); }
		}

		public ICommand LogErrorCommand
		{
			get
			{
				return new MvxCommand(() =>
				{
					try
					{
						throw new Exception("We hate exceptions!");
					}
					catch (Exception ex)
					{
						AnalyticsApi.LogError("LogError", ex);
					}
				});
			}
		}

		public ICommand LogNormalEventCommand
		{
			get
			{
				return new MvxCommand(() =>
				{
					AnalyticsApi.LogEvent("LogNormalEvent");
				});
			}
		}

		public ICommand LogParametrizedEventCommand
		{
			get
			{
				return new MvxCommand(() =>
				{
					AnalyticsApi.LogEvent(
						"LogParametrizedEvent",
						new Dictionary<string, string> {{"Parameter", EventParameter}});
				});
			}
		}

		public ICommand LogNormalTimedEventCommand
		{
			get
			{
				return new MvxCommand(async () =>
				{
					IsWorking = true;
					using (AnalyticsApi.LogTimedEvent("LogNormalTimedEvent"))
					{
						await Task.Delay(TimeSpan.FromSeconds(3));
					}
					IsWorking = false;
				});
			}
		}

		public ICommand LogParametrizedTimedEventCommand
		{
			get
			{
				return new MvxCommand(async () =>
				{
					IsWorking = true;
					using (AnalyticsApi.LogTimedEvent(
						"LogParametrizedTimedEvent",
						new Dictionary<string, string> { { "Parameter", EventParameter } }))
					{
						await Task.Delay(TimeSpan.FromSeconds(3));
					}
					IsWorking = false;
				});
			}
		}

		public ICommand LogParametrizedTimedEventWithEndParametersCommand
		{
			get
			{
				return new MvxCommand(async () =>
				{
					IsWorking = true;
					using (var timed = AnalyticsApi.LogTimedEvent(
						"LogParametrizedTimedEventWithEndParameters",
						new Dictionary<string, string> { { "Parameter", EventParameter } }))
					{
						await Task.Delay(TimeSpan.FromSeconds(3));
						timed.EndEvent(new Dictionary<string, string> { { "AdditionalParameter", "User loved this task." } });
					}
					IsWorking = false;
				});
			}
		}
	}
}
