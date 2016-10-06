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

}
