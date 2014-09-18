// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the MainView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MvvmCrossSample.iOS.Views
{
	using Core.ViewModels;
	using MonoTouch.Foundation;
	using MonoTouch.UIKit;

	/// <summary>
	/// Defines the MainView type.
	/// </summary>
	[Register("MainView")]
	public class MainView : BaseView
	{
		/// <summary>
		/// Views the did load.
		/// </summary>
		/// <summary>
		/// Called when the View is first loaded
		/// </summary>
		public override void ViewDidLoad()
		{
			this.View = new UIView { BackgroundColor = UIColor.White };

			base.ViewDidLoad();

			UITapGestureRecognizer tap = new UITapGestureRecognizer(() => this.View.ResignFirstResponder());
			this.View.AddGestureRecognizer(tap);
		}
	}
}
