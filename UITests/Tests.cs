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

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		[Category("category1")]
		public void InitialUITest()
		{
			// Invoke the REPL so that we can explore the user interface
			//app.Repl();
			app.WaitForElement(c => c.Marked("PowerDissipatedLabel"));
			app.Screenshot("App loaded.");
			var voltageIn = app.Query("VoltageInSlider").First().Text;
		}
	}
}

