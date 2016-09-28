using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace VoltageRegulatorTemperature.UITests
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		//public Tests(Platform platform)
		//{
		//	this.platform = platform;
		//}

		//[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		//[Test]
		[Category("category1")]
		public void InitialUITest()
		{
			// Invoke the REPL so that we can explore the user interface
			//app.Repl();
			app.WaitForElement(c => c.Marked("PowerDissipatedLabel"));
			app.Screenshot("App loaded.");
			var voltageIn = app.Query("VoltageInSlider").First().Text;
		}

		//[Test]
		public void SetRealisticValuesInFahrenheitBoth()
		{
			app.SetSliderValue(x => x.Class("FormsSeekBar").Index(0), 250);
			app.Screenshot("Set slider value on view with class: FormsSeekBar");
			app.SetSliderValue(x => x.Class("FormsSeekBar").Index(1), 209);
			app.Screenshot("Set slider value on view with class: FormsSeekBar");
			app.SetSliderValue(x => x.Class("FormsSeekBar").Index(2), 50);
			app.Screenshot("Set slider value on view with class: FormsSeekBar");
			app.Tap(x => x.Marked("OK"));
			app.Screenshot("Tapped on view with class: ImageButton marked: OK");
			app.Tap(x => x.Text("Fahrenheit (°F)"));
			app.Screenshot("Tapped on view with class: FormsTextView");
			app.SwipeRightToLeft();
			app.Screenshot("Swiped left");
		}
	}
}

