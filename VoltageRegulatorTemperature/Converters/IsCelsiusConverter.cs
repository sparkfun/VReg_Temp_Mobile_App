using System;
using System.Globalization;
using Xamarin.Forms;

namespace VoltageRegulatorTemperature.Converters
{
	public class IsCelsiusConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// HACK until Xamarin.Forms supports multibinding
			var app = Application.Current as App;
			var units = app.CalculatorViewModel.DisplayedUnits;
			return units.Equals(ViewModels.CalculatorViewModel.Units.Celsius);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

