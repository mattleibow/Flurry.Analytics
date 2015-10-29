using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FlurryAnalyticsWindowsPhoneSample.Resources;

namespace FlurryAnalyticsWindowsPhoneSample
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			// Sample code to localize the ApplicationBar
			//BuildLocalizedApplicationBar();

			// just to keep all the app the same
			VersionLabel.Text = "Flurry_WP8_" + typeof(FlurryWP8SDK.Api).Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;

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

		// Sample code for building a localized ApplicationBar
		//private void BuildLocalizedApplicationBar()
		//{
		//    // Set the page's ApplicationBar to a new instance of ApplicationBar.
		//    ApplicationBar = new ApplicationBar();

		//    // Create a new button and set the text value to the localized string from AppResources.
		//    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
		//    appBarButton.Text = AppResources.AppBarButtonText;
		//    ApplicationBar.Buttons.Add(appBarButton);

		//    // Create a new menu item with the localized string from AppResources.
		//    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
		//    ApplicationBar.MenuItems.Add(appBarMenuItem);
		//}
	}
}