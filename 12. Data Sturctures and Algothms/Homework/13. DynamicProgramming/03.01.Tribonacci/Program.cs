namespace Tribonacci
{
	using System;
	using System.Linq;
	using System.Numerics;
	using System.Collections.Generic;

	public static class Program
	{
		public static BigInteger Tribonacci(int index, params BigInteger[] sequence)
		{
			if (sequence.Length != 3)
			{
				throw new ArgumentException("Need 3 initial numbers.");
			}

			if (index <= 2)
			{
				return sequence[index];
			}

			for (int i = 3; i <= index; i++)
			{
				BigInteger next = sequence[0] + sequence[1] + sequence[2];

				sequence[0] = sequence[1];
				sequence[1] = sequence[2];
				sequence[2] = next;
			}

			return sequence[2];
		}

		public static void Main()
		{
			int[] input = Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToArray();

			Console.WriteLine(Tribonacci(input[3] - 1, input[0], input[1], input[2]));
		}
	}
}