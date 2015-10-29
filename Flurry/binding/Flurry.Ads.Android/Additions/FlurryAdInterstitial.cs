using System;
using Java.Interop;

namespace Flurry.Ads
{
	public partial class FlurryAdInterstitial
	{
		private WeakReference listener;

		public event EventHandler AppExit {
			add {
				EventHelper.AddEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					() => new FlurryAdInterstitialListener (),
					SetListener,
					h => h.OnAppExitHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					FlurryAdInterstitialListener.IsEmpty,
					v => SetListener (null),
					h => h.OnAppExitHandler -= value);
			}
		}

		public event EventHandler Clicked {
			add {
				EventHelper.AddEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					() => new FlurryAdInterstitialListener (),
					SetListener,
					h => h.OnClickedHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					FlurryAdInterstitialListener.IsEmpty,
					v => SetListener (null),
					h => h.OnClickedHandler -= value);
			}
		}

		public event EventHandler Close {
			add {
				EventHelper.AddEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					() => new FlurryAdInterstitialListener (),
					SetListener,
					h => h.OnCloseHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					FlurryAdInterstitialListener.IsEmpty,
					v => SetListener (null),
					h => h.OnCloseHandler -= value);
			}
		}

		public event EventHandler<ErrorEventArgs> Error {
			add {
				EventHelper.AddEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					() => new FlurryAdInterstitialListener (),
					SetListener,
					h => h.OnErrorHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					FlurryAdInterstitialListener.IsEmpty,
					v => SetListener (null),
					h => h.OnErrorHandler -= value);
			}
		}

		public event EventHandler Fetched {
			add {
				EventHelper.AddEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					() => new FlurryAdInterstitialListener (),
					SetListener,
					h => h.OnFetchedHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					FlurryAdInterstitialListener.IsEmpty,
					v => SetListener (null),
					h => h.OnFetchedHandler -= value);
			}
		}

		public event EventHandler Rendered {
			add {
				EventHelper.AddEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					() => new FlurryAdInterstitialListener (),
					SetListener,
					h => h.OnRenderedHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					FlurryAdInterstitialListener.IsEmpty,
					v => SetListener (null),
					h => h.OnRenderedHandler -= value);
			}
		}

		public event EventHandler Display {
			add {
				EventHelper.AddEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					() => new FlurryAdInterstitialListener (),
					SetListener,
					h => h.OnDisplayHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					FlurryAdInterstitialListener.IsEmpty,
					v => SetListener (null),
					h => h.OnDisplayHandler -= value);
			}
		}

		public event EventHandler VideoCompleted {
			add {
				EventHelper.AddEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					() => new FlurryAdInterstitialListener (),
					SetListener,
					h => h.OnVideoCompletedHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdInterstitialListener, FlurryAdInterstitialListener> (
					ref listener,
					FlurryAdInterstitialListener.IsEmpty,
					v => SetListener (null),
					h => h.OnVideoCompletedHandler -= value);
			}
		}
	}

	internal class FlurryAdInterstitialListener : Java.Lang.Object, IFlurryAdInterstitialListener
	{
		public EventHandler OnAppExitHandler;
		public EventHandler OnClickedHandler;
		public EventHandler OnCloseHandler;
		public EventHandler<ErrorEventArgs> OnErrorHandler;
		public EventHandler OnFetchedHandler;
		public EventHandler OnRenderedHandler;
		public EventHandler OnDisplayHandler;
		public EventHandler OnVideoCompletedHandler;

		public void OnAppExit (FlurryAdInterstitial adInterstitial)
		{
			var handler = OnAppExitHandler;
			if (handler != null)
				handler (adInterstitial, EventArgs.Empty);
		}

		public void OnClicked (FlurryAdInterstitial adInterstitial)
		{
			var handler = OnClickedHandler;
			if (handler != null)
				handler (adInterstitial, EventArgs.Empty);
		}

		public void OnClose (FlurryAdInterstitial adInterstitial)
		{
			var handler = OnCloseHandler;
			if (handler != null)
				handler (adInterstitial, EventArgs.Empty);
		}

		public void OnError (FlurryAdInterstitial adInterstitial, FlurryAdErrorType bannerErrorType, int bannerError)
		{
			var handler = OnErrorHandler;
			if (handler != null)
				handler (adInterstitial, new ErrorEventArgs (bannerErrorType, bannerError));
		}

		public void OnFetched (FlurryAdInterstitial adInterstitial)
		{
			var handler = OnFetchedHandler;
			if (handler != null)
				handler (adInterstitial, EventArgs.Empty);
		}

		public void OnRendered (FlurryAdInterstitial adInterstitial)
		{
			var handler = OnRenderedHandler;
			if (handler != null)
				handler (adInterstitial, EventArgs.Empty);
		}

		public void OnDisplay (FlurryAdInterstitial adInterstitial)
		{
			var handler = OnDisplayHandler;
			if (handler != null)
				handler (adInterstitial, EventArgs.Empty);
		}

		public void OnVideoCompleted (FlurryAdInterstitial adInterstitial)
		{
			var handler = OnVideoCompletedHandler;
			if (handler != null)
				handler (adInterstitial, EventArgs.Empty);
		}

		public static bool IsEmpty (FlurryAdInterstitialListener value)
		{
			return 
				value.OnAppExitHandler == null &&
				value.OnClickedHandler == null &&
				value.OnCloseHandler == null &&
				value.OnErrorHandler == null &&
				value.OnFetchedHandler == null &&
				value.OnRenderedHandler == null &&
				value.OnDisplayHandler == null &&
				value.OnVideoCompletedHandler == null;
		}
	}
}
