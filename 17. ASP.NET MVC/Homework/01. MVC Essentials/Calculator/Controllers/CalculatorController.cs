namespace Calculator.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Web.Mvc;

	using ViewModels;

	public class CalculatorController : Controller
	{
		[HttpGet]
		public ActionResult Calculate(Calculation model)
		{
			decimal inputBits = model.InputValue.ToBits();

			MetricPrefix[] prefixes = Enum.GetValues(typeof(MetricPrefix)) as MetricPrefix[];

			Unit[] units = Enum.GetValues(typeof(Unit)) as Unit[];

			var results = new List<MetricUnit>(prefixes.Length * units.Length);

			foreach (var prefix in prefixes)
			{
				foreach (var unit in units)
				{
					MetricUnit metricUnit = new MetricUnit
					{
						Prefix = prefix,
						KiloValue = model.InputValue.KiloValue,
						Unit = unit,
					};

					metricUnit.SetValueFromBits(inputBits);

					results.Add(metricUnit);
				}
			}

			model.Results = results;

			return this.View(model);
		}
	}
}