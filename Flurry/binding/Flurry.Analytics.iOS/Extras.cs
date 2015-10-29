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

	public class FlurryAgentEventsDelegate : NSObject, IFlurryAgentDelegate
	{
		public EventHandler<SessionCreatedEventArgs> SessionCreated;
		
		public virtual void OnSessionCreated (NSDictionary info)
		{
			var handler = SessionCreated;
			if (handler != null)
			{
				handler (this, new SessionCreatedEventArgs (info));
			}
		}
	}

	public class SessionCreatedEventArgs : EventArgs
	{
		public SessionCreatedEventArgs (NSDictionary info)
		{
			Info = info;
		}

		public NSDictionary Info { get; private set; }
	}
}

