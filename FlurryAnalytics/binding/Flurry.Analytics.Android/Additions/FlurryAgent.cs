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

	public enum Gender
	{
		Male = 1,
		Female = 0,
		Unknown = -1
	}
}

