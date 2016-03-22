namespace SortingHomework
{
	using System;
	using System.Collections.Generic;

	using Sorters;
	using Sorters.Abstracts;

	using Tools.Extensions;

    internal static class Program
    {
	    internal static void Print<T>(IEnumerable<T> items)
	    {
			Console.WriteLine(string.Join(", ", items));
			Console.WriteLine();
	    }

        internal static void RunSorting()
        {
			int[] numbers = new[]  { 22, 11, 101, 33, 0, 101 };

		Console.WriteLine("All items before sorting:");
			Program.Print(numbers);

			ISorter<int> sorter = new SelectionSorter<int>();
			Console.WriteLine("SelectionSorter result:");
			IEnumerable<int> sortResult = sorter.Sort(numbers);
			Program.Print(sortResult);

			sorter = new QuickSorter<int>();
			Console.WriteLine("QuickSorter result:");
			sortResult = sorter.Sort(numbers);
			Program.Print(sortResult);

			sorter = new MergeSorter<int>();
			Console.WriteLine("MergeSorter result:");
			sortResult = sorter.Sort(numbers);
			Program.Print(sortResult);

			sorter = new MonkeySorter<int>();
			Console.WriteLine("MonkeySorter result:");
			sortResult = sorter.Sort(numbers);
			Program.Print(sortResult);

			Console.WriteLine("Linear search 101:");
			Console.WriteLine(numbers.LinearSearch(101));
			Console.WriteLine();

			Console.WriteLine("Binary search 101:");
			Console.WriteLine(numbers.CustomBinarySearch(101));
			Console.WriteLine();

			Console.WriteLine("Shuffle:");
			IEnumerable<int> shuffled = numbers.Shuffle();
			Program.Print(shuffled);

			Console.WriteLine("Shuffle again:");
			shuffled = shuffled.Shuffle();
			Program.Print(shuffled);
		}

		internal static void Main()
		{
			Program.RunSorting();
		}
    }
}