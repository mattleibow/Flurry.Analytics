using UIKit;

namespace FlurryTumblriOSSample
{
	public class RootViewController : UINavigationController
	{
		private TumblrViewController tumblrController;

		public override void LoadView ()
		{
			base.LoadView ();

			tumblrController = new TumblrViewController ();	
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			PushViewController (tumblrController, true);
		}
	}
}
