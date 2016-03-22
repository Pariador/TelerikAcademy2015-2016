namespace Tasks
{
	using System;

	public class CalculationException : ApplicationException
	{
		public CalculationException()
			: base()
		{
			;
		}

		public CalculationException(string message)
			: base(message)
		{
			;
		}
	}
}