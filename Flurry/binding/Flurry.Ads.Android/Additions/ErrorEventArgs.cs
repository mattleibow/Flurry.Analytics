using System;

namespace Flurry.Ads
{
	public class ErrorEventArgs : EventArgs
	{
		public ErrorEventArgs (FlurryAdErrorType errorType, int error)
		{
			ErrorType = errorType;
			ErrorCode = error;
		}

		public FlurryAdErrorType ErrorType { get; private set; }

		public int ErrorCode { get; private set; }
	}
}
