using VoltageRegulatorTemperature.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// Enable xamlc for whole assembly
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VoltageRegulatorTemperature
{
	public partial class App : Application
	{
		// TODO: This is of questionable use when duplicated in multiple files... CalculatorPage.xaml.cs
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

