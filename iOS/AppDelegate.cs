﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;

namespace VoltageRegulatorTemperature.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			// Added in attempt to make AutomationIDs work
			Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) =>
			{
				// http://developer.xamarin.com/recipes/testcloud/set-accessibilityidentifier-ios/
				if (null != e.View.AutomationId)
				{
					e.NativeView.AccessibilityIdentifier = e.View.AutomationId;
				}
			};

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}

