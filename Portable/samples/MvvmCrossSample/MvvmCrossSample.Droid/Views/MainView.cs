using Android.App;
using Android.OS;
using Android.Views;

namespace MvvmCrossSample.Droid.Views
{
	[Activity(Label = "Basics", WindowSoftInputMode = SoftInput.StateHidden)]
	public class MainView : BaseView
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			this.SetContentView(Resource.Layout.MainView);
		}
	}
}