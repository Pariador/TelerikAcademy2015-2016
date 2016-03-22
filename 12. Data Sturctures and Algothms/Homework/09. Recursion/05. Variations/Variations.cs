namespace Variations
{
	public static class Variations
	{
		public static void Main()
		{
			var comb = new Variator(new[] {"hi","a","b"}, 2);
			comb.PrintAllVariations();
		}
	}
}