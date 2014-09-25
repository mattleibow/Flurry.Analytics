using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Reflection;

namespace Flurry.Analytics.WindowsPhone7.Sample
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			// just to keep all the app the same
            VersionLabel.Text = "Flurry_WP7_" + typeof(FlurryWP8SDK.Api).Assembly.GetName().Version;

			LogEventButton.Click += delegate
			{
				if (string.IsNullOrEmpty(EventParameterText.Text))
					FlurryWP8SDK.Api.LogEvent("Button Click");
				else
					FlurryWP8SDK.Api.LogEvent("Button Click", new List<FlurryWP8SDK.Models.Parameter> { 
						new FlurryWP8SDK.Models.Parameter("Log Parameter", EventParameterText.Text)
					});

				MessageBox.Show("Your event was logged along with the specified parameter.");
			};
		}
	}
}