using System;
using Java.Interop;

namespace Flurry.Ads
{
	public partial class FlurryAdBanner
	{
		private WeakReference listener;

		public event EventHandler AppExit {
			add {
				EventHelper.AddEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					() => new FlurryAdBannerListener (),
					SetListener,
					h => h.OnAppExitHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					FlurryAdBannerListener.IsEmpty,
					v => SetListener (null),
					h => h.OnAppExitHandler -= value);
			}
		}

		public event EventHandler Clicked {
			add {
				EventHelper.AddEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					() => new FlurryAdBannerListener (),
					SetListener,
					h => h.OnClickedHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					FlurryAdBannerListener.IsEmpty,
					v => SetListener (null),
					h => h.OnClickedHandler -= value);
			}
		}

		public event EventHandler CloseFullscreen {
			add {
				EventHelper.AddEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					() => new FlurryAdBannerListener (),
					SetListener,
					h => h.OnCloseFullscreenHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					FlurryAdBannerListener.IsEmpty,
					v => SetListener (null),
					h => h.OnCloseFullscreenHandler -= value);
			}
		}

		public event EventHandler<ErrorEventArgs> Error {
			add {
				EventHelper.AddEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					() => new FlurryAdBannerListener (),
					SetListener,
					h => h.OnErrorHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					FlurryAdBannerListener.IsEmpty,
					v => SetListener (null),
					h => h.OnErrorHandler -= value);
			}
		}

		public event EventHandler Fetched {
			add {
				EventHelper.AddEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					() => new FlurryAdBannerListener (),
					SetListener,
					h => h.OnFetchedHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					FlurryAdBannerListener.IsEmpty,
					v => SetListener (null),
					h => h.OnFetchedHandler -= value);
			}
		}

		public event EventHandler Rendered {
			add {
				EventHelper.AddEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					() => new FlurryAdBannerListener (),
					SetListener,
					h => h.OnRenderedHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					FlurryAdBannerListener.IsEmpty,
					v => SetListener (null),
					h => h.OnRenderedHandler -= value);
			}
		}

		public event EventHandler ShowFullscreen {
			add {
				EventHelper.AddEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					() => new FlurryAdBannerListener (),
					SetListener,
					h => h.OnShowFullscreenHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					FlurryAdBannerListener.IsEmpty,
					v => SetListener (null),
					h => h.OnShowFullscreenHandler -= value);
			}
		}

		public event EventHandler VideoCompleted {
			add {
				EventHelper.AddEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					() => new FlurryAdBannerListener (),
					SetListener,
					h => h.OnVideoCompletedHandler += value);
			}
			remove {
				EventHelper.RemoveEventHandler<IFlurryAdBannerListener, FlurryAdBannerListener> (
					ref listener,
					FlurryAdBannerListener.IsEmpty,
					v => SetListener (null),
					h => h.OnVideoCompletedHandler -= value);
			}
		}
	}

	internal class FlurryAdBannerListener : Java.Lang.Object, IFlurryAdBannerListener
	{
		public EventHandler OnAppExitHandler;
		public EventHandler OnClickedHandler;
		public EventHandler OnCloseFullscreenHandler;
		public EventHandler<ErrorEventArgs> OnErrorHandler;
		public EventHandler OnFetchedHandler;
		public EventHandler OnRenderedHandler;
		public EventHandler OnShowFullscreenHandler;
		public EventHandler OnVideoCompletedHandler;

		public void OnAppExit (FlurryAdBanner adBanner)
		{
			var handler = OnAppExitHandler;
			if (handler != null)
				handler (adBanner, EventArgs.Empty);
		}

		public void OnClicked (FlurryAdBanner adBanner)
		{
			var handler = OnClickedHandler;
			if (handler != null)
				handler (adBanner, EventArgs.Empty);
		}

		public void OnCloseFullscreen (FlurryAdBanner adBanner)
		{
			var handler = OnCloseFullscreenHandler;
			if (handler != null)
				handler (adBanner, EventArgs.Empty);
		}

		public void OnError (FlurryAdBanner adBanner, FlurryAdErrorType bannerErrorType, int bannerError)
		{
			var handler = OnErrorHandler;
			if (handler != null)
				handler (adBanner, new ErrorEventArgs (bannerErrorType, bannerError));
		}

		public void OnFetched (FlurryAdBanner adBanner)
		{
			var handler = OnFetchedHandler;
			if (handler != null)
				handler (adBanner, EventArgs.Empty);
		}

		public void OnRendered (FlurryAdBanner adBanner)
		{
			var handler = OnRenderedHandler;
			if (handler != null)
				handler (adBanner, EventArgs.Empty);
		}

		public void OnShowFullscreen (FlurryAdBanner adBanner)
		{
			var handler = OnShowFullscreenHandler;
			if (handler != null)
				handler (adBanner, EventArgs.Empty);
		}

		public void OnVideoCompleted (FlurryAdBanner adBanner)
		{
			var handler = OnVideoCompletedHandler;
			if (handler != null)
				handler (adBanner, EventArgs.Empty);
		}

		public static bool IsEmpty (FlurryAdBannerListener value)
		{
			return 
				value.OnAppExitHandler == null &&
				value.OnClickedHandler == null &&
				value.OnCloseFullscreenHandler == null &&
				value.OnErrorHandler == null &&
				value.OnFetchedHandler == null &&
				value.OnRenderedHandler == null &&
				value.OnShowFullscreenHandler == null &&
				value.OnVideoCompletedHandler == null;
		}
	}
}
