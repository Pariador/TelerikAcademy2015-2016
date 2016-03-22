namespace StringsSubset
{
	public static class StringsSubset
	{
		public static void Main()
		{
			var comb = new StringCombinator(2, new[] {"test", "rock", "fun"});
			comb.PrintAllCombinations();
		}
	}
}