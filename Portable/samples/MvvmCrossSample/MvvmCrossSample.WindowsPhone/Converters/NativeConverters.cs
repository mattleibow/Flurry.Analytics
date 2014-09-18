using Cirrious.CrossCore.WindowsPhone.Converters;
using MvvmCrossSample.Core.Converters;

namespace MvvmCrossSample.WindowsPhone.Converters
{
	public class NativeIntConverter
		: MvxNativeValueConverter<IntConverter>
	{
	}

	public class NativeEnumToEnumerableConverter
		: MvxNativeValueConverter<EnumToEnumerableConverter>
	{
	}
}