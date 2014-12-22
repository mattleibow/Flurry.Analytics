using System;

namespace Flurry.Analytics {

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

	public enum FlurryEventStatus : uint {
		Failed = 0,
		Recorded,
		UniqueCountExceeded,
		ParamsCountExceeded,
		LogCountExceeded,
		LoggingDelayed
	}
}

