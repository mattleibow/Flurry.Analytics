using System;

namespace Flurry.Analytics
{
	public partial class FlurryAgent
	{
		public static void SetGender(Gender gender)
		{
			FlurryAgent.SetGender ((sbyte)gender);
		}
	}
}

