using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
[TestFixture]
public class AndroidTests {
	public AndroidApp app;
	[SetUp]
	public void Setup() {
		app = ConfigureApp
			.Android
			//.ApkFile("/Users/brent/Projects/Xamarin/VoltageRegulatorTemperature/Droid/bin/Release/com.sparkfun.voltageregulatortemperature.apk")
		    .StartApp();
	}

	[Test]
	public void BasicFahrenheitSetup()
	{
		// Let something load before proceeding
		app.WaitForElement(x => x.Marked("JunctionTemperatureLabel"));
		app.Screenshot("Initial launch");

		app.SetSliderValue(x => x.Class("FormsSeekBar").Index(0), 250);
		app.SetSliderValue(x => x.Class("FormsSeekBar").Index(1), 208);
		app.ScrollDown();	// Might be necessary on small screens
		app.SetSliderValue(x => x.Class("FormsSeekBar").Index(2), 50);
		app.Screenshot("Sliders set for 5V from 12V at 0.5A");

		app.ScrollUp();
		app.SetOrientationLandscape();
		app.Screenshot("Setup in landscape");

		app.SetOrientationPortrait();
		app.Tap(x => x.Marked("OK"));
		app.Screenshot("Opened settings");

		app.Tap(x => x.Text("Fahrenheit (°F)"));
		app.Screenshot("Tapped on view with class: FormsTextView");

		app.SwipeRightToLeft();
		app.Screenshot("Swiped left");

		app.WaitForElement(x => x.Marked("JunctionTemperatureLabel"));
		var temperatureF = app.Query(x => x.Marked("JunctionTemperatureLabel"));
		Assert.IsTrue(temperatureF[0].Text.Equals("JUNCTION TEMP: 222.1 ˚F"));
	}


}