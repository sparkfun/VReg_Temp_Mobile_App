using Xamarin.Forms;

namespace VoltageRegulatorTemperature
{
	public partial class App : Application
	{
		public App()
		{
			// Ensure link to Toolkit library
			new Xamarin.FormsBook.Toolkit.ObjectToIndexConverter<object>();

			// Instantiate CalculatorViewModel for sharing between pages
			CalculatorViewModel = new ViewModels.CalculatorViewModel();

			//InitializeComponent();

			MainPage = new VoltageRegulatorTemperature.Views.MainPage();
		}

		public ViewModels.CalculatorViewModel CalculatorViewModel { private set; get; }

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

