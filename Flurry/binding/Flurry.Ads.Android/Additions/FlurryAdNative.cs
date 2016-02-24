using System;
using Java.Interop;

namespace Flurry.Ads
{
	public partial class FlurryAdNative
	{
		private WeakReference listener;

		public event EventHandler AppExit {
			add {
				EventHelper.AddEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					() => new FlurryAdNativeListener (),
					SetListener,
					h => h.OnAppExitHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					FlurryAdNativeListener.IsEmpty,
					v => SetListener (null),
					h => h.OnAppExitHandler -= value);
			}
		}

		public event EventHandler Clicked {
			add {
				EventHelper.AddEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					() => new FlurryAdNativeListener (),
					SetListener,
					h => h.OnClickedHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					FlurryAdNativeListener.IsEmpty,
					v => SetListener (null),
					h => h.OnClickedHandler -= value);
			}
		}

		public event EventHandler CloseFullscreen {
			add {
				EventHelper.AddEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					() => new FlurryAdNativeListener (),
					SetListener,
					h => h.OnCloseFullscreenHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					FlurryAdNativeListener.IsEmpty,
					v => SetListener (null),
					h => h.OnCloseFullscreenHandler -= value);
			}
		}

		public event EventHandler<ErrorEventArgs> Error {
			add {
				EventHelper.AddEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					() => new FlurryAdNativeListener (),
					SetListener,
					h => h.OnErrorHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					FlurryAdNativeListener.IsEmpty,
					v => SetListener (null),
					h => h.OnErrorHandler -= value);
			}
		}

		public event EventHandler Fetched {
			add {
				EventHelper.AddEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					() => new FlurryAdNativeListener (),
					SetListener,
					h => h.OnFetchedHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					FlurryAdNativeListener.IsEmpty,
					v => SetListener (null),
					h => h.OnFetchedHandler -= value);
			}
		}

		public event EventHandler ShowFullscreen {
			add {
				EventHelper.AddEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					() => new FlurryAdNativeListener (),
					SetListener,
					h => h.OnShowFullscreenHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					FlurryAdNativeListener.IsEmpty,
					v => SetListener (null),
					h => h.OnShowFullscreenHandler -= value);
			}
		}

		public event EventHandler ImpressionLogged {
			add {
				EventHelper.AddEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					() => new FlurryAdNativeListener (),
					SetListener,
					h => h.OnImpressionLoggedHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					FlurryAdNativeListener.IsEmpty,
					v => SetListener (null),
					h => h.OnImpressionLoggedHandler -= value);
			}
		}

		public event EventHandler Expanded {
			add {
				EventHelper.AddEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					() => new FlurryAdNativeListener (),
					SetListener,
					h => h.OnExpandedHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					FlurryAdNativeListener.IsEmpty,
					v => SetListener (null),
					h => h.OnExpandedHandler -= value);
			}
		}

		public event EventHandler Collapsed {
			add {
				EventHelper.AddEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					() => new FlurryAdNativeListener (),
					SetListener,
					h => h.OnCollapsedHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdNativeListener, FlurryAdNativeListener> (
					ref listener,
					FlurryAdNativeListener.IsEmpty,
					v => SetListener (null),
					h => h.OnCollapsedHandler -= value);
			}
		}
	}

	internal class FlurryAdNativeListener : Java.Lang.Object, IFlurryAdNativeListener
	{
		public EventHandler OnAppExitHandler;
		public EventHandler OnClickedHandler;
		public EventHandler OnCloseFullscreenHandler;
		public EventHandler<ErrorEventArgs> OnErrorHandler;
		public EventHandler OnFetchedHandler;
		public EventHandler OnShowFullscreenHandler;
		public EventHandler OnImpressionLoggedHandler;
		public EventHandler OnExpandedHandler;
		public EventHandler OnCollapsedHandler;

		public void OnAppExit (FlurryAdNative adNative)
		{
			var handler = OnAppExitHandler;
			if (handler != null)
				handler (adNative, EventArgs.Empty);
		}

		public void OnClicked (FlurryAdNative adNative)
		{
			var handler = OnClickedHandler;
			if (handler != null)
				handler (adNative, EventArgs.Empty);
		}

		public void OnCloseFullscreen (FlurryAdNative adNative)
		{
			var handler = OnCloseFullscreenHandler;
			if (handler != null)
				handler (adNative, EventArgs.Empty);
		}

		public void OnError (FlurryAdNative adNative, FlurryAdErrorType NativeErrorType, int NativeError)
		{
			var handler = OnErrorHandler;
			if (handler != null)
				handler (adNative, new ErrorEventArgs (NativeErrorType, NativeError));
		}

		public void OnFetched (FlurryAdNative adNative)
		{
			var handler = OnFetchedHandler;
			if (handler != null)
				handler (adNative, EventArgs.Empty);
		}

		public void OnShowFullscreen (FlurryAdNative adNative)
		{
			var handler = OnShowFullscreenHandler;
			if (handler != null)
				handler (adNative, EventArgs.Empty);
		}

		public void OnImpressionLogged (FlurryAdNative adNative)
		{
			var handler = OnImpressionLoggedHandler;
			if (handler != null)
				handler (adNative, EventArgs.Empty);
		}

		public void OnExpanded (FlurryAdNative adNative)
		{
			var handler = OnExpandedHandler;
			if (handler != null)
				handler (adNative, EventArgs.Empty);
		}

		public void OnCollapsed (FlurryAdNative adNative)
		{
			var handler = OnCollapsedHandler;
			if (handler != null)
				handler (adNative, EventArgs.Empty);
		}

		public static bool IsEmpty (FlurryAdNativeListener value)
		{
			return 
				value.OnAppExitHandler == null &&
				value.OnClickedHandler == null &&
				value.OnCloseFullscreenHandler == null &&
				value.OnErrorHandler == null &&
				value.OnFetchedHandler == null &&
				value.OnShowFullscreenHandler == null &&
				value.OnImpressionLoggedHandler == null &&
				value.OnExpandedHandler == null &&
				value.OnCollapsedHandler == null;
		}
	}
}
