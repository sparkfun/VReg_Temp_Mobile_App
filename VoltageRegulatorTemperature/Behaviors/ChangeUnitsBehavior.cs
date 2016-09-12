using System;
using Xamarin.Forms;

namespace VoltageRegulatorTemperature.Behaviors
{
	public class ChangeUnitsBehavior : Behavior<View>
	{
		TapGestureRecognizer tapRecognizer;

		protected override void OnAttachedTo(View view)
		{
			base.OnAttachedTo(view);

			tapRecognizer = new TapGestureRecognizer();
			tapRecognizer.Tapped += OnTapRecognizerTapped;
			view.GestureRecognizers.Add(tapRecognizer);
		}

		protected override void OnDetachingFrom(View view)
		{
			base.OnDetachingFrom(view);

			view.GestureRecognizers.Remove(tapRecognizer);
			tapRecognizer.Tapped -= OnTapRecognizerTapped;
		}

		void OnTapRecognizerTapped(object sender, EventArgs args)
		{
			// FIXME: This is tied directly the viewmodel, should be generalized
			// TODO: This isn't finished
			var app = Application.Current as App;
			var label = (Label)sender;
			if (label.StyleId.Equals("celsius"))
			{
				app.CalculatorViewModel.DisplayedUnits = VoltageRegulatorTemperature.ViewModels.CalculatorViewModel.Units.Celsius;
			}
			else
			{
				app.CalculatorViewModel.DisplayedUnits = VoltageRegulatorTemperature.ViewModels.CalculatorViewModel.Units.Fahrenheit;
			}
		}
	}
}

