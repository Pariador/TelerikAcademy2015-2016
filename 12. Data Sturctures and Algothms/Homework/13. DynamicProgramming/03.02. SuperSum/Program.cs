namespace SuperSum
{
	using System;
	using System.Linq;

	public static class Program
	{
		public static int SuperSum(int depth, int setLength)
		{
			if (depth == 1)
			{
				return Program.SumNumbersFromOneTo(setLength);
			}

			int sum = 0;
			for (int i = 1; i <= setLength; i++)
			{
				sum += Program.SuperSum(depth - 1, i);
			}

			return sum;
		}

		public static int SumNumbersFromOneTo(int max)
		{
			int firstPlusLast = 1 + max;
			int occurrences = max / 2;

			int result = firstPlusLast * occurrences;

			return max % 2 == 0 ? result : result + (firstPlusLast / 2);
		}

		public static void Main()
		{
			int[] data = Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToArray();


			Console.WriteLine(Program.SuperSum(data[0], data[1]));
		}
	}
}