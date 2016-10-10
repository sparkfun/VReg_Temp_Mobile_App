using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
[TestFixture]
public class iOSTests {
	public iOSApp app;
	[SetUp]
	public void Setup() {
		app = ConfigureApp
			.iOS
			//.AppBundle("/Users/brent/Projects/Xamarin/VoltageRegulatorTemperature/iOS/bin/iPhoneSimulator/Debug/xtr-VoltageRegulatorTemperature.iOS.app")
			.StartApp();
	}

	[Test]
	public void BasicFahrenheitSetup() {
		// Let something load before proceeding
		app.WaitForElement(x => x.Id("JunctionTemperatureLabel"));
		app.Screenshot("Initial launch");

		app.SetSliderValue(x => x.Class("UISlider"), 12);
		app.SetSliderValue(x => x.Class("UISlider").Index(1), 5);
		// Have to scroll down on small screens to make lower views accessible
		app.ScrollDown(withinMarked: "CalcScrollView");
		app.SetSliderValue(x => x.Class("UISlider").Index(2), 0.5);
		app.Screenshot("Sliders set for 5V from 12V at 0.5A");

		app.ScrollUp(withinMarked: "CalcScrollView");
		app.SetOrientationLandscape();
		app.Screenshot("Setup in landscape");

		app.SetOrientationPortrait();
		app.Tap(x => x.Id("hamburger.png"));
		app.Screenshot("Opened settings");

		app.Tap(x => x.Marked("Fahrenheit (°F)"));
		app.Screenshot("Tapped on view with class: UILabel marked: Fahrenheit (°F)");

		app.SwipeRightToLeft();
		app.Screenshot("Swiped left"); 

		app.WaitForElement(x => x.Id("JunctionTemperatureLabel"));
		var temperatureF = app.Query(x => x.Id("JunctionTemperatureLabel"));
		Assert.IsTrue(temperatureF[0].Label.Equals("JUNCTION TEMP: 221.9 ˚F"));
	}

	[Test]
	public void DefaultSettingsLeaveLabelBlack()
	{
		// Let something load before proceeding
		app.WaitForElement(x => x.Id("JunctionTemperatureLabel"));
		app.Screenshot("Initial launch");

		app.SetSliderValue(x => x.Class("UISlider"), 11.0);
		app.SetSliderValue(x => x.Class("UISlider").Index(1), 5);
		// Have to scroll down on small screens to make lower views accessible
		app.ScrollDown(withinMarked: "CalcScrollView");
		app.SetSliderValue(x => x.Class("UISlider").Index(2), 0.5);
		app.Screenshot("Sliders set for 5V from 12V at 0.5A");

		app.ScrollUp(withinMarked: "CalcScrollView");
		app.WaitForElement(x => x.Id("JunctionTemperatureLabel"));
		var isRed = Convert.ToBoolean(app.Query(x => x.Id("JunctionTemperatureLabel").
		                                        Invoke("textColor").Invoke("red"))[0]);
		Assert.IsFalse(isRed);	// Defaults shouldn't be too hot
	}

	[Test]
	public void LoweringMaxTempTurnsLabelRed()
	{
		// Let something load before proceeding
		app.WaitForElement(x => x.Id("JunctionTemperatureLabel"));
		app.Screenshot("Initial launch");

		app.SetSliderValue(x => x.Class("UISlider"), 12);
		app.SetSliderValue(x => x.Class("UISlider").Index(1), 5);
		// Have to scroll down on small screens to make lower views accessible
		app.ScrollDown(withinMarked: "CalcScrollView");
		app.SetSliderValue(x => x.Class("UISlider").Index(2), 0.5);
		app.Screenshot("Sliders set for 5V from 12V at 0.5A");

		app.ScrollUp(withinMarked: "CalcScrollView");
		app.Tap(x => x.Id("hamburger.png"));
		app.Screenshot("Opened settings");

		app.Tap(x => x.Marked("Fahrenheit (°F)"));
		app.Screenshot("Tapped on view with class: UILabel marked: Fahrenheit (°F)");

		app.Tap(x => x.Marked("257"));
		app.ClearText(x => x.Class("UITextField").Index(2));
		app.EnterText(x => x.Class("UITextField").Index(2), "215");
		app.Tap(x => x.Marked("Done"));
		app.Screenshot("Lowered max junction temperature below current temperature");

		//app.Tap(x => x.Class("UIView").Index(6));
		app.SwipeRightToLeft();
		//app.Repl();
		app.Screenshot("Closed settings");

		app.WaitForElement(x => x.Id("JunctionTemperatureLabel"));
		var isRed = Convert.ToBoolean(app.Query(x => x.Id("JunctionTemperatureLabel").
												Invoke("textColor").Invoke("red"))[0]);
		Assert.IsTrue(isRed);
	}
}
