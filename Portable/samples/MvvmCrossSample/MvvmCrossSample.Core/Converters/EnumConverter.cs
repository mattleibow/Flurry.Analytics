using System;

using Cirrious.CrossCore.Converters;

namespace MvvmCrossSample.Core.Converters
{
	public class EnumToEnumerableConverter : IMvxValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Type type = null;
			if (value != null)
				type = value.GetType();
			if (type != null)
			{
				var names = Enum.GetValues(type);
				return names;
			}
			return new object[0];
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
