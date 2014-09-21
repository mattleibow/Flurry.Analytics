using Android.Animation;
using Android.App;
using Android.OS;
using Android.Views;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.Binding.BindingContext;
using MvvmCrossSample.Core.ViewModels;

namespace MvvmCrossSample.Droid.Views
{
	[Activity(Label = "Events", WindowSoftInputMode = SoftInput.StateHidden)]
	public class EventsView : BaseView
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			this.SetContentView(Resource.Layout.EventsView);
		}

		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();

			// show a progress box if there is some work
			var events = ViewModel as EventsViewModel;
			if (events != null)
			{
				ProgressDialog progress = null;
				events.PropertyChanged += (sender, e) =>
				{
					if (e.PropertyName == "IsWorking")
					{
						if (events.IsWorking)
						{
							if (progress == null)
							{
								progress = new ProgressDialog(this);
								progress.SetProgressStyle(ProgressDialogStyle.Spinner);
								progress.SetMessage("Doing absolutely nothing in the background...");
								progress.Show();
							}
						}
						else
						{
							if (progress != null)
							{
								progress.Dismiss();
								progress = null;
							}
						}
					}
				};
			}
		}
	}
}