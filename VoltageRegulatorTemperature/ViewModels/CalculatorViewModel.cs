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

		public enum Units { Fahrenheit, Celsius };

		bool firstRun;

		double voltageIn, voltageOut, powerDissipated, tempC, tempF, currentDraw, thermalResistance, ambientTemp,
			maxJunctionTemp, minVoltageIn, maxVoltageIn, minVoltageOut, maxVoltageOut, minCurrentDraw, maxCurrentDraw;

		Units displayedUnits;

		public bool FirstRun
		{
			get { return firstRun; }
			set { SetProperty(ref firstRun, value); }
		}

		#region User IO
		// TODO: Add validation to all inputs... max > min, etc.
		public double VoltageIn
		{
			get { return voltageIn; }
			set
			{
				if (value < VoltageOut) // Voltage in can't ever be less than voltage out
				{
					VoltageOut = value;
				}
				if (SetProperty(ref voltageIn, value))
				{
					CalculatePowerDissipated();
				}
			}
		}

		public double VoltageOut
		{
			get { return voltageOut; }
			set
			{
				if (value > VoltageIn) // Voltage in can't ever be less than voltage out
				{
					VoltageIn = value;
				}
				if (SetProperty(ref voltageOut, value))
				{
					CalculatePowerDissipated();
				}
			}
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
			set
			{
				if (SetProperty(ref currentDraw, value))
				{
					CalculatePowerDissipated();
				}
			}
		}

		public double ThermalResistance
		{
			get { return thermalResistance; }
			set
			{
				if (SetProperty(ref thermalResistance, value))
				{
					CalculatePowerDissipated();
				}
			}
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
			set
			{
				if (value < MaxVoltageIn)
				{
					SetProperty(ref minVoltageIn, value);
				}
			}
		}

		public double MaxVoltageIn
		{
			get { return maxVoltageIn; }
			set
			{
				if (value > MinVoltageIn)
				{
					SetProperty(ref maxVoltageIn, value);
				}
			}
		}

		public double MinVoltageOut
		{
			get { return minVoltageOut; }
			set
			{
				if (value < MaxVoltageOut)
				{
					SetProperty(ref minVoltageOut, value);
				}
			}
		}

		public double MaxVoltageOut
		{
			get { return maxVoltageOut; }
			set
			{
				if (value > MinVoltageOut)
				{
					SetProperty(ref maxVoltageOut, value);
				}
			}
		}

		public double MinCurrentDraw
		{
			get { return minCurrentDraw; }
			set
			{
				if (value < MaxCurrentDraw)
				{
					SetProperty(ref minCurrentDraw, value);
				}

			}
		}

		public double MaxCurrentDraw
		{
			get { return maxCurrentDraw; }
			set
			{
				if (value > MinCurrentDraw)
				{
					SetProperty(ref maxCurrentDraw, value);
				}
			}
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
				TempC = ThermalResistance /* ˚C/W */ * PowerDissipated + AmbientTemp;
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

