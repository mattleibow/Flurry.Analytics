using System;

namespace Flurry.Analytics
{
	public partial class FlurryAgent
	{
		private static WeakReference sessionStartedListener;

		public static void SetGender (Gender gender)
		{
			FlurryAgent.SetGender ((sbyte)gender);
		}

		public static event EventHandler SessionStarted {
			add {
				global::Java.Interop.EventHelper.AddEventHandler<IFlurryAgentListener, IFlurryAgentListenerImplementor> (
					ref sessionStartedListener,
					() => new IFlurryAgentListenerImplementor(null),
					SetFlurryAgentListener,
					h => h.Handler += value);
			}
			remove {
				global::Java.Interop.EventHelper.RemoveEventHandler<IFlurryAgentListener, IFlurryAgentListenerImplementor> (
					ref sessionStartedListener,
					IFlurryAgentListenerImplementor.__IsEmpty,
					v => SetFlurryAgentListener (null),
					h => h.Handler -= value);
			}
		}
	}

	public enum Gender
	{
		Male = 1,
		Female = 0,
		Unknown = -1
	}
	
	[Obsolete ("Use the FlurryAgent.SessionStarted event instead.")]
	public class FlurryAgentEventsListener : Java.Lang.Object, IFlurryAgentListener
	{
		public event EventHandler SessionStarted;

		public void OnSessionStarted ()
		{
			var handler = SessionStarted;
			if (handler != null) {
				handler (this, EventArgs.Empty);
			}
		}
	}
}

