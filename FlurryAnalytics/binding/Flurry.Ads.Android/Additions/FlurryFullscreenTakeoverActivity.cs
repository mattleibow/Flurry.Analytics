using Android.App;
using Android.Runtime;
using Android.Content.PM;

namespace Flurry.Ads
{
	[Preserve]
	[Activity (ConfigurationChanges =
		ConfigChanges.Keyboard | 
		ConfigChanges.KeyboardHidden | 
		ConfigChanges.Orientation | 
		ConfigChanges.ScreenLayout | 
		ConfigChanges.UiMode |
		ConfigChanges.ScreenSize |
		ConfigChanges.SmallestScreenSize)]
	partial class FlurryFullscreenTakeoverActivity
	{
	}
}
