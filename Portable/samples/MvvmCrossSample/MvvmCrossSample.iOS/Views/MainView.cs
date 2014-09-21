using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Dialog.Touch.Elements;
using CrossUI.Touch.Dialog.Elements;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MvvmCrossSample.iOS.Views
{
	[Register("MainView")]
	public class MainView : BaseView
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Initialize();
		}

		private void Initialize()
		{
			Root = new RootElement("Flurry Analytics Portable")
			{
				new Section("Basics")
				{
					new StringElement("Flurry Supported").Bind(this, "Value IsFlurrySupported"),
					new StringElement("Flurry Version").Bind(this, "Value FlurryVersion"),
					new StringElement("Flurry API Key").Bind(this, "Value FlurryApiKey"),
				},
				new Section("User Information")
				{
					new EntryElement("User Id", "enter user id").Bind(this, "Value UserId"),
					new EntryElement("User Age", "enter user age").Bind(this, "Value UserAge, Converter=Int"),
					new SimplePickerElement("User Gender", null, null).Bind(this, "Value UserGender; Entries UserGender, Converter=EnumToEnumerable")
				},
				new Section("Location")
				{
					new StringElement("Latitude").Bind(this, "Value UserLocation.Coordinates.Latitude, Mode=TwoWay"),
					new StringElement("Longitude").Bind(this, "Value UserLocation.Coordinates.Longitude"),
					new StringElement("Accuracy").Bind(this, "Value UserLocation.Coordinates.Accuracy"),
				},
				new Section("Events")
				{
					new StyledStringElement("Show Events")
					{
						Accessory = UITableViewCellAccessory.DisclosureIndicator,
						Font = UIFont.SystemFontOfSize(UIFont.LabelFontSize)
					}.Bind(this, "SelectedCommand ShowEventsCommand"),
				},
			};
		}
	}
}
