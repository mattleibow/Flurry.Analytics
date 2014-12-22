using System;

#if __UNIFIED__
using Foundation;
#else
using MonoTouch.Foundation;
#endif

namespace Flurry.Analytics {

	public partial class FlurryAgent {

		public static void EndTimedEvent (string eventName)
		{
			EndTimedEvent (eventName, null);
		}

		public static void SetGender (Gender gender)
		{
			switch (gender) {
			case Gender.Male:
				SetGender ("m");
				break;
			case Gender.Female:
				SetGender ("f");
				break;
			case Gender.Unknown:
			default:
				SetGender ("");
				break;
			}
		}
	}
}

