namespace Counting
{
	using System.Collections.Generic;

	public static class Helper
	{
		public static Dictionary<T, int> CountOccurrences<T>(IEnumerable<T> items)
		{
			var occurrences = new Dictionary<T, int>();

			foreach (var item in items)
			{
				if (occurrences.ContainsKey(item))
				{
					occurrences[item]++;
				}
				else
				{
					occurrences[item] = 1;
				}
			}

			return occurrences;
		}
	}
}