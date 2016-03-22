namespace Calculator
{
	public static class DecimalExtensions
	{
		public static decimal Pow(this decimal number, int exponent)
		{
			decimal result = 1;

			for (int i = 0; i < exponent; i++)
			{
				result *= number;
			}

			return result;
		}
	}
}