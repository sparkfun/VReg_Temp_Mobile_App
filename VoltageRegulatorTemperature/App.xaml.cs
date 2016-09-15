using VoltageRegulatorTemperature.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// Enable xamlc for whole assembly
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
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
		const string minCurrentDrawKey = "minCurrentDraw";
		const string maxCurrentDrawKey = "maxCurrentDraw";
		const string displayedUnitsKey = "displayedUnits";

		public App()
		{
			// Instantiate CalculatorViewModel for sharing between pages
			CalculatorViewModel = new ViewModels.CalculatorViewModel();

			//#region PersistantProperties
			//// TODO: This manual save/restore is tedious, implement auto serialization
			//if (!Properties.ContainsKey(firstRunKey))
			//{
			//	// Do first run stuff
			//	// TODO: This code also found in CalculatorViewModel's ResetToDefaultSettingsCommand
			//	Properties[thermalResistanceKey] =  23.0;
			//	Properties[displayedUnitsKey]      = (int)CalculatorViewModel.Units.Celsius;
			//	Properties[firstRunKey]          = false;
			//	Properties[ambientTempKey]       =  25.0;
			//	Properties[maxJunctionTempKey]   = 125.0;
			//	Properties[minVoltageInKey]      =   0.0;
			//	Properties[maxVoltageInKey]      =  48.0;
			//	Properties[minVoltageOutKey]     =   0.0;
			//	Properties[maxVoltageOutKey]     =  24.0;
			//	Properties[minCurrentDrawKey]    =   0.0;
			//	Properties[maxCurrentDrawKey]    =  10.0;
			//	SavePropertiesAsync();
			//}

			//// Load UI limits so checks on valid values pass when they should
			//if (Properties.ContainsKey(minVoltageInKey))
			//{
			//	CalculatorViewModel.MinVoltageIn = (double)Properties[minVoltageInKey];
			//}

			//if (Properties.ContainsKey(maxVoltageInKey))
			//{
			//	CalculatorViewModel.MaxVoltageIn = (double)Properties[maxVoltageInKey];
			//}

			//if (Properties.ContainsKey(minVoltageOutKey))
			//{
			//	CalculatorViewModel.MinVoltageOut = (double)Properties[minVoltageOutKey];
			//}

			//if (Properties.ContainsKey(maxVoltageOutKey))
			//{
			//	CalculatorViewModel.MaxVoltageOut = (double)Properties[maxVoltageOutKey];
			//}

			//if (Properties.ContainsKey(minCurrentDrawKey))
			//{
			//	CalculatorViewModel.MinCurrentDraw = (double)Properties[minCurrentDrawKey];
			//}

			//if (Properties.ContainsKey(maxCurrentDrawKey))
			//{
			//	CalculatorViewModel.MaxCurrentDraw = (double)Properties[maxCurrentDrawKey];
			//}

			//// Load simulation settings
			//if (Properties.ContainsKey(voltageInKey))
			//{
			//	CalculatorViewModel.VoltageIn = (double)Properties[voltageInKey];
			//}

			//if (Properties.ContainsKey(voltageOutKey))
			//{
			//	CalculatorViewModel.VoltageOut = (double)Properties[voltageOutKey];
			//}

			//if (Properties.ContainsKey(currentDrawKey))
			//{
			//	CalculatorViewModel.CurrentDraw = (double)Properties[currentDrawKey];
			//}

			//if (Properties.ContainsKey(thermalResistanceKey))
			//{
			//	CalculatorViewModel.ThermalResistance = (double)Properties[thermalResistanceKey];
			//}

			//if (Properties.ContainsKey(displayedUnitsKey))
			//{
			//	CalculatorViewModel.DisplayedUnits = (CalculatorViewModel.Units)Properties[displayedUnitsKey];
			//}

			//if (Properties.ContainsKey(ambientTempKey))
			//{
			//	CalculatorViewModel.AmbientTemp = (double)Properties[ambientTempKey];
			//}

			//if (Properties.ContainsKey(maxJunctionTempKey))
			//{
			//	CalculatorViewModel.MaxJunctionTemp = (double)Properties[maxJunctionTempKey];
			//}
			//#endregion


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
			Properties[displayedUnitsKey] = (int)CalculatorViewModel.DisplayedUnits;
			Properties[ambientTempKey] = CalculatorViewModel.AmbientTemp;
			Properties[maxJunctionTempKey] = CalculatorViewModel.MaxJunctionTemp;
			Properties[minVoltageInKey] = CalculatorViewModel.MinVoltageIn;
			Properties[maxVoltageInKey] = CalculatorViewModel.MaxVoltageIn;
			Properties[minVoltageOutKey] = CalculatorViewModel.MinVoltageOut;
			Properties[maxVoltageOutKey] = CalculatorViewModel.MaxVoltageOut;
			Properties[minCurrentDrawKey] = CalculatorViewModel.MinCurrentDraw;
			Properties[maxCurrentDrawKey] = CalculatorViewModel.MaxCurrentDraw;
			await SavePropertiesAsync();
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

