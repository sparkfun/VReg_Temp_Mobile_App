using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

namespace VoltageRegulatorTemperature.Converters
{
	public class CelsiusToFahrenheitConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (double)value * 1.8 + 32;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double number;
			if (Double.TryParse((string)value, out number))
			{
				return (number - 32) * 5.0 / 9.0;
			}
			else
			{
				return -1.0;
			}
		}
	}
}