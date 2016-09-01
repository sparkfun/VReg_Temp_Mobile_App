using VoltageRegulatorTemperature.ViewModels;
using Xamarin.Forms;

namespace VoltageRegulatorTemperature
{
	public partial class App : Application
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
		const string minCurrentKey = "minCurrent";
		const string maxCurrentKey = "maxCurrent";
		const string displayedUnitsKey = "displayedUnits";

		public App()
		{
			// Instantiate CalculatorViewModel for sharing between pages
			CalculatorViewModel = new ViewModels.CalculatorViewModel();

			#region PersistantProperties
			if (Properties.ContainsKey(firstRunKey))
			{
				CalculatorViewModel.FirstRun = (bool)Properties[firstRunKey];
			}
			else
			{
				// TODO: Do first run stuff!
				Properties[thermalResistanceKey] = 23.0;
				Properties[firstRunKey] = false;
				SavePropertiesAsync();
			}

			if (Properties.ContainsKey(voltageInKey))
			{
				CalculatorViewModel.VoltageIn = (double)Properties[voltageInKey];
			}

			if (Properties.ContainsKey(voltageOutKey))
			{
				CalculatorViewModel.VoltageOut = (double)Properties[voltageOutKey];
			}

			if (Properties.ContainsKey(currentDrawKey))
			{
				CalculatorViewModel.CurrentDraw = (double)Properties[currentDrawKey];
			}

			if (Properties.ContainsKey(thermalResistanceKey))
			{
				CalculatorViewModel.ThermalResistance = (double)Properties[thermalResistanceKey];
			}

			// Test of removing 'complex' datatypes
			//if (Properties.ContainsKey(displayedUnitsKey))
			//{
			//	CalculatorViewModel.DisplayedUnits = (CalculatorViewModel.Units)Properties[displayedUnitsKey];
			//}
			#endregion


			MainPage = new VoltageRegulatorTemperature.Views.MainPage();
		}

		public ViewModels.CalculatorViewModel CalculatorViewModel { private set; get; }

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		//protected override void OnSleep()
		protected override async void OnSleep()
		{
			// Save properties on sleep
			// TODO: Storing way more significant figures than the UI shows. Might be 'wrong'.
			Properties[voltageInKey] = CalculatorViewModel.VoltageIn;
			Properties[voltageOutKey] = CalculatorViewModel.VoltageOut;
			Properties[currentDrawKey] = CalculatorViewModel.CurrentDraw;
			Properties[thermalResistanceKey] = CalculatorViewModel.ThermalResistance;
			// Test of removing 'complex' datatypes Properties[displayedUnitsKey] = CalculatorViewModel.DisplayedUnits;
			await SavePropertiesAsync();
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

