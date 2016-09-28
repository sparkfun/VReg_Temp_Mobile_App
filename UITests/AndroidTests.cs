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
	public void SetRealisticValues()
	{
 		app.SetSliderValue(x => x.Class("FormsSeekBar").Index(0), 250);
		app.Screenshot("Set slider value on view with class: FormsSeekBar");
		app.SetSliderValue(x => x.Class("FormsSeekBar").Index(1), 210);
		app.Screenshot("Set slider value on view with class: FormsSeekBar");
		app.SetSliderValue(x => x.Class("FormsSeekBar").Index(2), 50);
		app.Screenshot("Set slider value on view with class: FormsSeekBar");
	}

	[Test]
	public void SetRealisticValuesInFahrenheit()
	{
		app.SetSliderValue(x => x.Class("FormsSeekBar").Index(0), 250);
		app.Screenshot("Set slider value on view with class: FormsSeekBar");
		app.SetSliderValue(x => x.Class("FormsSeekBar").Index(1), 210);
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