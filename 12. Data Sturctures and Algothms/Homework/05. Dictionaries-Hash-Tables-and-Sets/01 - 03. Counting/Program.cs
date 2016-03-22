namespace Counting
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Text.RegularExpressions;

    public static class Program
    {
		public static void CountDoubles()
		{
			double[] doubles = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

			var occurrences = Helper.CountOccurrences(doubles);
			foreach (var occurrence in occurrences)
			{
				Console.WriteLine("{0} => {1}", occurrence.Key, occurrence.Value);
			}
        }

		public static void StringsRepeatingOddNumberOfTimes()
		{
			string[] strings = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

			var occurrences = Helper.CountOccurrences(strings);
			foreach (var occurrence in occurrences)
			{
				if (occurrence.Value % 2 == 1)
				{
					Console.WriteLine(occurrence.Key);
				}
			}
		}

		public static void CountWordsFromTextFile()
		{
			string file;
			using (var reader = new StreamReader("words.txt"))
			{
				file = reader.ReadToEnd();
			}

			Regex findWords = new Regex("\\w+");

			var words = findWords.Matches(file)
				.Cast<Match>()
				.Select(m => m.Value.ToLower());

			var wordCounts = Helper.CountOccurrences(words)
				.OrderBy(count => count.Value);

			foreach (var count in wordCounts)
			{
				Console.WriteLine("{0} => {1}", count.Key, count.Value);
			}
		}

		public static void Main()
        {
			var methods = typeof(Program)
				.GetMethods(BindingFlags.Public | BindingFlags.Static)
				.Where(m => m.Name != nameof(Program.Main));

	        foreach (var method in methods)
	        {
				Console.WriteLine("Executing {0}():", method.Name);

				method.Invoke(null, null);

				Console.WriteLine(new string('-', 20));
		        Console.WriteLine();
	        }
        }
    }
}