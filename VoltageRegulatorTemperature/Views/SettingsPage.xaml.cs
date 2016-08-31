using System.Diagnostics;
using Xamarin.Forms;

namespace VoltageRegulatorTemperature.Views
{
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			InitializeComponent();
		}

		// TODO: Debug method next
		void Entry_TextChanged(object sender, TextChangedEventArgs e)
		{			
			Debug.WriteLine($"TextChanged: {sender.ToString()}");
		}
	}
}

