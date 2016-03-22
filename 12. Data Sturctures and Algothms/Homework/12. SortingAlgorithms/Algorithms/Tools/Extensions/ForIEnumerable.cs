namespace SortingHomework.Tools.Extensions
{
	using System.Linq;
	using System.Collections.Generic;

	using Tools;

	public static class ForIEnumerable
	{
		public static bool LinearSearch<T>(this IEnumerable<T> items, T toFind)
		{
			foreach (var item in items)
			{
				if (item.Equals(toFind))
				{
					return true;
				}
			}

			return false;
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items)
		{
			T[] result = items.ToArray();

			for (int i = 0; i < result.Length - 1; i++)
			{
				int randomIndex = Helper.Random.Next(i + 1, result.Length);
				Helper.Swap(ref result[i], ref result[randomIndex]);
			}

			return result;
		}
	}
}