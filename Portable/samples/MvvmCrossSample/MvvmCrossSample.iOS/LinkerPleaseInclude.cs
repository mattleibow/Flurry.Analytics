using System;
using System.Collections.Specialized;
using System.Windows.Input;

using UIKit;
using Foundation;

namespace MvvmCrossSample.iOS
{
	// This class is never actually executed, but when Xamarin linking is enabled it does how to 
	// ensure types and properties are preserved in the deployed app. 
	public class LinkerPleaseInclude
	{
		public void Include(UIButton uiButton)
		{
			uiButton.TouchUpInside += (s, e) => uiButton.SetTitle(uiButton.Title(UIControlState.Normal), UIControlState.Normal);
		}

		public void Include(UIBarButtonItem barButton)
		{
			barButton.Clicked += (s, e) => barButton.Title = barButton.Title + string.Empty;
		}

		public void Include(UITextField textField)
		{
			textField.Text = textField.Text + string.Empty;
			textField.EditingChanged += (sender, args) => { textField.Text = string.Empty; };
		}

		public void Include(UITextView uiTextView)
		{
			uiTextView.Text = uiTextView.Text + string.Empty;
			uiTextView.Changed += (sender, args) => { uiTextView.Text = string.Empty; };
		}

		public void Include(UILabel uiLabel)
		{
			uiLabel.Text = string.Format("{0}", uiLabel.Text);
		}

		public void Include(UIImageView uiImageView)
		{
			uiImageView.Image = new UIImage(uiImageView.Image.CIImage);
		}

		public void Include(UIDatePicker uiDatePicker)
		{
			uiDatePicker.Date = uiDatePicker.Date.AddSeconds(1);
			uiDatePicker.ValueChanged += (sender, args) => { uiDatePicker.Date = NSDate.Now; };
		}

		public void Include(UISlider uiSlider)
		{
			uiSlider.Value = uiSlider.Value + 1;
			uiSlider.ValueChanged += (sender, args) => { uiSlider.Value = 1; };
		}

		public void Include(UISwitch uiSwitch)
		{
			uiSwitch.On = !uiSwitch.On;
			uiSwitch.ValueChanged += (sender, args) => { uiSwitch.On = false; };
		}

		public void Include(INotifyCollectionChanged changed)
		{
			changed.CollectionChanged += (s, e) => { string test = string.Format("{0}{1}{2}{3}{4}", e.Action, e.NewItems, e.NewStartingIndex, e.OldItems, e.OldStartingIndex); };
		}

		public void Include(ICommand command)
		{
			command.CanExecuteChanged += (s, e) => { if (command.CanExecute(null)) command.Execute(null); };
		}
	}
}
