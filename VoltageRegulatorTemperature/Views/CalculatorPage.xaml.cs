using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VoltageRegulatorTemperature.Views
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalculatorPage : ContentPage
	{
		const string firstRunKey = "firstRun";
		const string voltageInKey = "voltageIn";
		const string voltageOutKey = "voltageOut";
		const string currentDrawKey = "currentDraw";
		const string thermalResistanceKey = "thermalResistance";
		const string displayUnitsKey = "displayUnits";
		const string ambientTempKey = "ambientTemp";
		const string maxJunctionTempKey = "maxJunctionTemp";
		const string minVoltageInKey = "minVoltageIn";
		const string maxVoltageInKey = "maxVoltageIn";
		const string minVoltageOutKey = "minVoltageOut";
		const string maxVoltageOutKey = "maxVoltageOut";
		const string minCurrentDrawKey = "minCurrentDraw";
		const string maxCurrentDrawKey = "maxCurrentDraw";
		const string displayedUnitsKey = "displayedUnits";

		public CalculatorPage()
		{
			InitializeComponent();

			#region PersistantProperties
			// TODO: This manual save/restore is tedious, implement auto serialization
			var app = Application.Current as App;
			if (!app.Properties.ContainsKey(firstRunKey))
			{
				// Do first run stuff
				// TODO: This code also found in CalculatorViewModel's ResetToDefaultSettingsCommand
				app.Properties[thermalResistanceKey] = 23.0;
				app.Properties[displayedUnitsKey] = (int)ViewModels.CalculatorViewModel.Units.Celsius;
				app.Properties[firstRunKey] = false;
				app.Properties[ambientTempKey] = 25.0;
				app.Properties[maxJunctionTempKey] = 125.0;
				app.Properties[minVoltageInKey] = 0.0;
				app.Properties[maxVoltageInKey] = 48.0;
				app.Properties[minVoltageOutKey] = 0.0;
				app.Properties[maxVoltageOutKey] = 24.0;
				app.Properties[minCurrentDrawKey] = 0.0;
				app.Properties[maxCurrentDrawKey] = 10.0;
				app.SavePropertiesAsync();
			}

			// Load UI limits so checks on valid values pass when they should
			if (app.Properties.ContainsKey(minVoltageInKey))
			{
				app.CalculatorViewModel.MinVoltageIn = (double)app.Properties[minVoltageInKey];
			}

			if (app.Properties.ContainsKey(maxVoltageInKey))
			{
				app.CalculatorViewModel.MaxVoltageIn = (double)app.Properties[maxVoltageInKey];
			}

			if (app.Properties.ContainsKey(minVoltageOutKey))
			{
				app.CalculatorViewModel.MinVoltageOut = (double)app.Properties[minVoltageOutKey];
			}

			if (app.Properties.ContainsKey(maxVoltageOutKey))
			{
				app.CalculatorViewModel.MaxVoltageOut = (double)app.Properties[maxVoltageOutKey];
			}

			if (app.Properties.ContainsKey(minCurrentDrawKey))
			{
				app.CalculatorViewModel.MinCurrentDraw = (double)app.Properties[minCurrentDrawKey];
			}

			if (app.Properties.ContainsKey(maxCurrentDrawKey))
			{
				app.CalculatorViewModel.MaxCurrentDraw = (double)app.Properties[maxCurrentDrawKey];
			}

			// Load simulation settings
			if (app.Properties.ContainsKey(voltageInKey))
			{
				app.CalculatorViewModel.VoltageIn = (double)app.Properties[voltageInKey];
			}

			if (app.Properties.ContainsKey(voltageOutKey))
			{
				app.CalculatorViewModel.VoltageOut = (double)app.Properties[voltageOutKey];
			}

			if (app.Properties.ContainsKey(currentDrawKey))
			{
				app.CalculatorViewModel.CurrentDraw = (double)app.Properties[currentDrawKey];
			}

			if (app.Properties.ContainsKey(thermalResistanceKey))
			{
				app.CalculatorViewModel.ThermalResistance = (double)app.Properties[thermalResistanceKey];
			}

			if (app.Properties.ContainsKey(displayedUnitsKey))
			{
				app.CalculatorViewModel.DisplayedUnits =
					   (ViewModels.CalculatorViewModel.Units)app.Properties[displayedUnitsKey];
			}

			if (app.Properties.ContainsKey(ambientTempKey))
			{
				app.CalculatorViewModel.AmbientTemp = (double)app.Properties[ambientTempKey];
			}

			if (app.Properties.ContainsKey(maxJunctionTempKey))
			{
				app.CalculatorViewModel.MaxJunctionTemp = (double)app.Properties[maxJunctionTempKey];
			}
			#endregion
		}
	}
}

