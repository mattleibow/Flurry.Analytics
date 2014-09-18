using System;
using System.Globalization;

using Cirrious.CrossCore.Converters;

namespace MvvmCrossSample.Core.Converters
{
	public class IntConverter : MvxValueConverter<int, string>
	{
		protected override string Convert(
			int value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			if (value == 0)
				return string.Empty;
			
			return value.ToString(CultureInfo.CurrentUICulture);
		}

		protected override int ConvertBack(
			string value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			if (string.IsNullOrWhiteSpace(value))
				return 0;

			return int.Parse(value, CultureInfo.CurrentUICulture);
		}
	}
}