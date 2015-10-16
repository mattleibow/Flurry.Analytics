using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace FlurryAdsiOSSample
{
	partial class MasterViewController : UITableViewController
	{
		private List<string> options = new List<string> {
			"Flurry Banners", 
			"Flurry Takovers"  
		};

		public MasterViewController (IntPtr handle)
			: base (handle)
		{
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return options.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("Cell", indexPath);

			cell.TextLabel.Text = options [indexPath.Row];

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			string segue = "banners";
			switch (indexPath.Row) {
			case 0:
				segue = "banners";
				break;
			case 1:
				segue = "takeovers";
				break;
			}
			PerformSegue (segue, this);
		}
	}
}
