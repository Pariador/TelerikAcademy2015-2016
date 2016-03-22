namespace Problem3
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public static class Program3
	{
		public static void Main()
		{
			int[] takes = Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToArray();

			int[] games = Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToArray();

			int from = games[0];
			int to = games[1];
			//from = to = 5;
			int mikiWins = 0;
			for (int sum = from; sum <= to; sum++)
			{
				if (DoesMikiWins(sum, takes.OrderByDescending(t => t).ToArray()))
				{
					mikiWins++;
				}
			}

			Console.WriteLine(mikiWins);
		}

		public static bool DoesMikiWins(int remainingBalls,  int[] takes, int turn = 0)
		{
			if (remainingBalls == 0)
			{
				return turn % 2 == 1;
			}

			if (remainingBalls < 0)
			{
				return false;
			}

			for (int i = 0; i < takes.Length; i++)
			{
				if (DoesMikiWins(remainingBalls - takes[i], takes, turn + 1))
				{
					return true;
				}
			}

			return false;
		}
	}
}