using System;
using System.Diagnostics;
using System.Threading;

using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Flurry.Analytics;

namespace Flurry.Analytics.iOS.FeatureSample
{
	public class AnalyticsViewController : DialogViewController
	{
		public AnalyticsViewController ()
			: base (new RootElement (""))
		{
			this.Title = "FlurryAnalytics";
		}

		public override void LoadView ()
		{
			base.LoadView ();

			var versionElement = new StringElement ("Version", FlurryAgent.GetFlurryAgentVersion ());

			var errorElement = new StringElement ("Throw & Log Exception", () => {
				try {
					throw new Exception ("Thar be dragons!");
				} catch (Exception ex) {
					FlurryAgent.LogError (ex.GetType ().Name, ex.Message, new NSError (NSError.CocoaErrorDomain, 3584));

					Debug.WriteLine ("Logged exception.");
				}
			});

			var shortEventElement = new StringElement ("Single Event", () => {
				FlurryAgent.LogEvent ("SingleEvent");

				Debug.WriteLine ("Logged event.");
			});

			var shortParameterEventElement = new StringElement ("Single Event with Parameters", () => {
				FlurryAgent.LogEvent ("SingleEventWithParameter", GetParameter ());

				Debug.WriteLine ("Logged event with parameter.");
			});

			var timedEventElement = new StringElement ("Timed Event", () => {
				FlurryAgent.LogEvent ("TimedEvent", true);
				var alert = new UIAlertView ("Please Wait", "Doing a longer running operation...", null, null);
				alert.Show ();
				Thread.Sleep (1000);
				FlurryAgent.EndTimedEvent ("TimedEvent");
				alert.DismissWithClickedButtonIndex (-1, true);

				Debug.WriteLine ("Logged timed event.");
			});

			var timedParameterEventElement = new StringElement ("Timed Event with Parameters", () => {
				FlurryAgent.LogEvent ("TimedEventWithParameter", GetParameter (), true);
				var alert = new UIAlertView ("Please Wait", "Doing a longer running operation...", null, null);
				alert.Show ();
				Thread.Sleep (1000);
				FlurryAgent.EndTimedEvent ("TimedEventWithParameter");
				alert.DismissWithClickedButtonIndex (-1, true);

				Debug.WriteLine ("Logged timed event with parameter.");
			});

			var idElement = new EntryElement ("User ID: ", "enter user id", "");
			idElement.Changed += (sender, e) => {
				FlurryAgent.SetUserId (((EntryElement)sender).Value);

				Debug.WriteLine ("Logged user id.");
			};
			
			var ageElement = new EntryElement ("Age: ", "enter age", "");
			ageElement.Changed += (sender, e) => {
				int age;
				var element = (EntryElement)sender;
				if (int.TryParse (element.Value, out age)) {
					FlurryAgent.SetAge (age);

					Debug.WriteLine ("Logged age.");
				}
			};

			var genderElement = new RootElement ("Gender: ", new RadioGroup (0)) {
				new Section () {
					new SelectableRadioElement ("Unknown", (sender, e) => {
						FlurryAgent.SetGender (Gender.Unknown);

						Debug.WriteLine ("Logged gender.");
					}),
					new SelectableRadioElement ("Male", (sender, e) => {
						FlurryAgent.SetGender (Gender.Male);

						Debug.WriteLine ("Logged gender.");
					}),
					new SelectableRadioElement ("Female", (sender, e) => {
						FlurryAgent.SetGender (Gender.Female);

						Debug.WriteLine ("Logged gender.");
					})
				}
			};
			
			this.Root.Add (new Section[] {
				new Section ("About Flurry Analytics") {
					versionElement
				}, 
				new Section ("Track Errors") {
					errorElement
				}, 
				new Section ("Track Events") {
					shortEventElement,
					shortParameterEventElement,
					timedEventElement,
					timedParameterEventElement
				}, 
				new Section ("Track Demographics") {
					idElement,
					ageElement,	
					genderElement,
				} 
			});
		}

		public NSDictionary GetParameter ()
		{
			return NSDictionary.FromObjectAndKey (
				(NSString)"Parameter Value",
				(NSString)"Parameter Key");
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}

		public override void ViewWillLayoutSubviews ()
		{
			base.ViewWillLayoutSubviews ();
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		protected override void Dispose (bool disposing)
		{
			base.Dispose (disposing);
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

