using System;
namespace VoltageRegulatorTemperature.ViewModels
{
	public class CalculatorViewModel : Xamarin.FormsBook.Toolkit.ViewModelBase
	{
		public enum Units { Fahrenheit, Celsius };

		bool firstRun;

		double voltageIn, voltageOut, powerDissipated, tempC, tempF, currentDraw, thermalResistance, ambientTemp,
			maxJunctionTemp, minVoltageIn, maxVoltageIn, minVoltageOut, maxVoltageOut, minCurrent, maxCurrent;

		Units displayedUnits;

		public bool FirstRun
		{
			get { return firstRun; }
			set { SetProperty(ref firstRun, value); }
		}

		public double VoltageIn
		{
			get { return voltageIn; }
			set { SetProperty(ref voltageIn, value); }
		}

		public double VoltageOut
		{
			get { return voltageOut; }
			set { SetProperty(ref voltageOut, value); }
		}

		public double PowerDissipated
		{
			get { return powerDissipated; }
			set { SetProperty(ref powerDissipated, value); }
		}

		public double TempC
		{
			get { return tempC; }
			set { SetProperty(ref tempC, value); }
		}

		public double TempF
		{
			get { return tempF; }
			set { SetProperty(ref tempF, value); }
		}

		public double CurrentDraw
		{
			get { return currentDraw; }
			set { SetProperty(ref currentDraw, value); }
		}

		public double ThermalResistance
		{
			get { return thermalResistance; }
			set { SetProperty(ref thermalResistance, value); }
		}

		public double AmbientTemp
		{
			get { return ambientTemp; }
			set { SetProperty(ref ambientTemp, value); }
		}

		public double MaxJunctionTemp
		{
			get { return maxJunctionTemp; }
			set { SetProperty(ref maxJunctionTemp, value); }
		}

		public double MinVoltageIn
		{
			get { return minVoltageIn; }
			set { SetProperty(ref minVoltageIn, value); }
		}

		public double MaxVoltageIn
		{
			get { return maxVoltageOut; }
			set { SetProperty(ref maxVoltageOut, value); }
		}

		public double MinVoltageOut
		{
			get { return minVoltageOut; }
			set { SetProperty(ref minVoltageOut, value); }
		}

		public double MaxVoltageOut
		{
			get { return maxVoltageOut; }
			set { SetProperty(ref maxVoltageOut, value); }
		}

		public double MinCurrent
		{
			get { return minCurrent; }
			set { SetProperty(ref minCurrent, value); }
		}

		public double MaxCurrent
		{
			get { return maxCurrent; }
			set { SetProperty(ref maxCurrent, value); }
		}

		public Units DisplayedUnits
		{
			get { return displayedUnits; }
			set { SetProperty(ref displayedUnits, value); }
		}
	}
}

