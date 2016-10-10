using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

namespace VoltageRegulatorTemperature.Converters
{
	public class CelsiusToFahrenheitConverter : IValueConverter
	{
		// Convert from ˚C found in bound property to ˚F for UI
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (double)value * 1.8 + 32;
		}

		// Convert back from ˚F in UI to ˚C stored in property
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double number;

			if (Double.TryParse((string)value, out number))
			{
				return (number - 32) * 5.0 / 9.0;
			}
			else
			{
				return String.Empty;
			}
		}
	}
}