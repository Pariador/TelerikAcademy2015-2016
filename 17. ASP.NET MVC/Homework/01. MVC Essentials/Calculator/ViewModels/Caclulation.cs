using System.Collections.Generic;

namespace Calculator.ViewModels
{
	public class Calculation
	{
		public Calculation()
		{
			this.InputValue = new MetricUnit(MetricPrefix.Mega, KiloValue.Kibi, Unit.Byte, 1, isValueInBits: false);

			this.Results = new MetricUnit[0];
		}

		public MetricUnit InputValue { get; set; }

		public IEnumerable<MetricUnit> Results { get; set; }
	}
}