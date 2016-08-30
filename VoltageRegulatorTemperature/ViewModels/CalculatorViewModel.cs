namespace VoltageRegulatorTemperature.ViewModels
{
	public class CalculatorViewModel : Xamarin.FormsBook.Toolkit.ViewModelBase
	{
		//public CalculatorViewModel()
		//{
		//	// Load previously stored settings
		//	var app = Application.Current as App;
		//	this.VoltageIn = app.CalculatorViewModel.VoltageIn;
		//	VoltageOut = app.CalculatorViewModel.VoltageOut;
		//	CurrentDraw = app.CalculatorViewModel.CurrentDraw;
		//	DisplayedUnits = app.CalculatorViewModel.DisplayedUnits;
		//	ThermalResistance = app.CalculatorViewModel.ThermalResistance;

		//	CalculatePowerDissipated();
		//}

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

		#region User IO
		public double VoltageIn
		{
			get { return voltageIn; }
			// TODO: Should CalculatePowerDissipated really be called in all of these places?
			set { CalculatePowerDissipated(); SetProperty(ref voltageIn, value); }
		}

		public double VoltageOut
		{
			get { return voltageOut; }
			set { CalculatePowerDissipated(); SetProperty(ref voltageOut, value); }
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
			set { CalculatePowerDissipated(); SetProperty(ref currentDraw, value); }
		}

		public double ThermalResistance
		{
			get { return thermalResistance; }
			set { CalculatePowerDissipated(); SetProperty(ref thermalResistance, value); }
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
		#endregion

		#region UI Settings
		public double MinVoltageIn
		{
			get { return minVoltageIn; }
			set { SetProperty(ref minVoltageIn, value); }
		}

		public double MaxVoltageIn
		{
			get { return maxVoltageIn; }
			set { SetProperty(ref maxVoltageIn, value); }
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
		#endregion

		#region Calculation Methods
		void CalculatePowerDissipated()
		{
			PowerDissipated = (voltageIn - voltageOut) * currentDraw;
			CalculateTemperatureRise(); // This always changes if dissipated power changes
		}

		void CalculateTemperatureRise()
		{
			if (!PowerDissipated.Equals(0))
			{
				TempC = ThermalResistance /* ˚C/W */ * PowerDissipated;
				TempF = TempC * 9 / 5 + 32;
			}
			else
			{
				TempC = TempF = 0.0;
			}
		}
		#endregion
	}
}

