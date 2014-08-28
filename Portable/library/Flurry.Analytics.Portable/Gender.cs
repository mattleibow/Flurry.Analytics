using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flurry.Analytics.Portable
{
	/// <summary>
	/// Represents the gender to be used for grouping collected analytics data.
	/// </summary>
	public enum Gender
	{
		/// <summary>
		/// The gender is unknown or unspecified.
		/// </summary>
		Unknown = -1,

		/// <summary>
		/// The gender is female.
		/// </summary>
		Female = 0,
		/// <summary>
		/// The gender is male.
		/// </summary>
		Male = 1
	}
}
