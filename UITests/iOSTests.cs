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
		app.Repl();
		app.SetSliderValue(x => x.Class("UISlider"), 12);
		app.SetSliderValue(x => x.Class("UISlider").Index(1), 5);
		// Sure looks like this crashes if the third UISlider isn't on screen
		app.ScrollDownTo(x => x.Class("UISlider").Index(2));
		app.Screenshot("Scrolled down to current slider");
		//app.ScrollDown();
		//app.WaitForElement(x => x.Class("UISlider").Index(2));
		app.SetSliderValue(x => x.Class("UISlider").Index(2), 0.5);
		//app.SetSliderValue(x => x.Marked("CurrentDrawSlider"), 0.5);
		app.Screenshot("Sliders set for 5V from 12V at 5A");
		app.SetOrientationLandscape();
		app.Screenshot("Setup in landscape");
		app.SetOrientationPortrait();
		app.Tap(x => x.Id("hamburger.png"));
		app.Screenshot("Tapped on view with class: UIImageView");
		app.Tap(x => x.Marked("Fahrenheit (°F)"));
		app.Screenshot("Tapped on view with class: UILabel marked: Fahrenheit (°F)");
		app.SwipeRightToLeft();
		app.Screenshot("Swiped left");
		app.WaitForElement(x => x.Id("JunctionTemperatureLabel"));
		var temperatureF = app.Query(x => x.Id("JunctionTemperatureLabel"));
		Assert.IsTrue(temperatureF[0].Label.Equals("JUNCTION TEMP: 221.9 ˚F"));
	}

}
