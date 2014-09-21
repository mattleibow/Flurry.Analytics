using Cirrious.MvvmCross.Dialog.Touch;
using MonoTouch.UIKit;

namespace MvvmCrossSample.iOS.Views
{
	public abstract class BaseView : MvxDialogViewController
	{
		protected BaseView()
			: base (UITableViewStyle.Grouped, null, true)
		{
			EdgesForExtendedLayout = UIRectEdge.None;
		}
	}
}
