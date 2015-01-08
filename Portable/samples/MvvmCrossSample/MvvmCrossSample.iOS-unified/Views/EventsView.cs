using Cirrious.MvvmCross.Binding.BindingContext;
using CrossUI.Touch.Dialog.Elements;
using Foundation;
using UIKit;
using MvvmCrossSample.Core.ViewModels;

namespace MvvmCrossSample.iOS.Views
{
	[Register("EventsView")]
	public class EventsView : BaseView
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Initialize();
		}

		private void Initialize()
		{
			Root = new RootElement("Events")
			{
				new Section("Normal Events")
				{
					new Element("Log Single Event").Bind(this, "SelectedCommand LogNormalEventCommand"),
					new Element("Log Parametrized Event").Bind(this, "SelectedCommand LogParametrizedEventCommand"),
				},
				new Section("Timed Events")
				{
					new Element("Log Single Event").Bind(this, "SelectedCommand LogNormalTimedEventCommand"),
					new Element("Log Parametrized Timed Event").Bind(this, "SelectedCommand LogParametrizedTimedEventCommand"),
					new Element("Log Updated Parametrized Timed Event").Bind(this,
						"SelectedCommand LogParametrizedTimedEventWithEndParametersCommand"),
				},
				new Section("Errors")
				{
					new Element("Log Error").Bind(this, "SelectedCommand LogErrorCommand")
				},
			};

			// show a progress box if there is some work
			var events = ViewModel as EventsViewModel;
			if (events != null)
			{
				UIAlertView progress = null;
				events.PropertyChanged += (sender, e) =>
				{
					if (e.PropertyName == "IsWorking")
					{
						if (events.IsWorking)
						{
							if (progress == null)
							{
								progress = new UIAlertView("Working...", "Doing absolutely nothing in the background...", null, null, null);
								UIActivityIndicatorView indicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray);
								indicator.StartAnimating();
								progress.SetValueForKey(indicator, (NSString)"accessoryView");
								progress.Show();
							}
						}
						else
						{
							if (progress != null)
							{
								progress.DismissWithClickedButtonIndex(0, true);
								progress = null;
							}
						}
					}
				};
			}
		}
	}
}
