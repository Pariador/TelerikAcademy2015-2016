namespace Guitar
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public static class Program
	{
		public static void Main()
		{
			Console.ReadLine();

			int[] changes = Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToArray();

			int first = int.Parse(Console.ReadLine());
			int limit = int.Parse(Console.ReadLine());

			HashSet<int> currentSums = new HashSet<int>();
			currentSums.Add(first);
			HashSet<int> nextSums = new HashSet<int>();

			foreach (var change in changes)
			{
				foreach (var sum in currentSums)
				{
					int more = sum + change;
					int less = sum - change;

					if (more <= limit)
					{
						nextSums.Add(more);
					}

					if (less >= 0)
					{
						nextSums.Add(less);
					}
				}

				if (nextSums.Count == 0)
				{
					Console.WriteLine(-1);
					return;
				}

				var swap = currentSums;
				currentSums = nextSums;
				nextSums = swap;

				nextSums.Clear();
			}

			Console.WriteLine(currentSums.Max());
		}
	}
}