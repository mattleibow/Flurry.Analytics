using System;

namespace Flurry.Analytics {

	/// <summary>
	/// Enum for setting up log output level.
	/// </summary>
	public enum FlurryLogLevel : uint {
		None = 0,
		CriticalOnly,
		Debug,
		All
	}

	public enum Gender {
		Unknown = -1,
		Male = 1,
		Female = 0,
	}

	public enum FlurryEventRecordStatus : uint {
		Failed = 0,
		Recorded,
		UniqueCountExceeded,
		ParamsCountExceeded,
		LogCountExceeded,
		LoggingDelayed,
		AnalyticsDisabled
	}

	/// <summary>
	/// Enum for logging events that occur within a syndicated app.
	/// </summary>
	public enum FlurrySyndicationEvent : uint {
		Reblog      = 0,
		FastReblog  = 1,
		SourceClick = 2,
		Like        = 3,
		ShareClick  = 4,
		PostSend    = 5
	}
}

