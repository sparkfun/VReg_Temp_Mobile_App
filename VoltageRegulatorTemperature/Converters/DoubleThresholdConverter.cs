using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace VoltageRegulatorTemperature.Converters
{
	public class DoubleThresholdConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// HACK until Xamarin.Forms supports multibinding
			var app = Application.Current as App;
			return (double)value > app.CalculatorViewModel.MaxJunctionTemp;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// Never convert back in this code
			throw new NotSupportedException();
		}
	}
}

