using System;
using System.Diagnostics;
using System.Threading.Tasks;

using MonoTouch.Dialog;
using Foundation;
using UIKit;

using Flurry.Tumblr;
using Flurry.Analytics;

namespace FlurryTumblriOSSample
{
	public class TumblrViewController : DialogViewController
	{
		public TumblrViewController ()
			: base (new RootElement ("Flurry Tumblr"))
		{
		}

		public override void LoadView ()
		{
			base.LoadView ();

			var versionElement = new StringElement ("Version", FlurryAgent.FlurryAgentVersion);

			var iconElement = new ImageStringElement ("Share Logo", FlurryTumblr.TumblrLogo);

			var postTextElement = new StringElement ("Post Text", () => {
				var text = new FlurryTextShareParameters {
					Title = "Title Here",
					Text = "This is the text for the post",
					WebLink = "https://github.com/mattleibow/Flurry.Analytics"
				};
				FlurryTumblr.Post (text, this);
			});

			var postImageElement = new StringElement ("Post Image Url", () => {
				var text = new FlurryImageShareParameters {
					ImageCaption = "Image Caption",
					ImageUrl = "https://xamarin.com/content/images/pages/branding/assets/xamagon.png",
					WebLink = "https://github.com/mattleibow/Flurry.Analytics"
				};
				FlurryTumblr.Post (text, this);
			});
			
			this.Root.Add (new Section[] {
				new Section ("About Flurry Tumblr") {
					versionElement,
					iconElement
				}, 
				new Section ("Share") {
					postTextElement,
					postImageElement
				}, 
//				new Section ("Track Demographics") {
//					idElement,
//					ageElement,	
//					genderElement,
//				} 
			});
		}
	}

	public class SelectableRadioElement : RadioElement
	{
		Action<SelectableRadioElement, EventArgs> onClick;

		public SelectableRadioElement (string s, Action<SelectableRadioElement, EventArgs> onClick) : base (s)
		{
			this.onClick = onClick;
		}

		public override void Selected (DialogViewController dvc, UITableView tableView, NSIndexPath path)
		{
			base.Selected (dvc, tableView, path);

			var selected = onClick;
			if (selected != null) {
				selected (this, EventArgs.Empty);
			}
		}
	}
}

