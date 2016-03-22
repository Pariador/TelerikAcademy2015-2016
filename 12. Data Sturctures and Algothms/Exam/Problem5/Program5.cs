namespace Problem5
{
	using System;
	using System.Linq;
	using System.Text;
	using System.Collections.Generic;

	public static class Program5
	{
		public const string Symbols = "0123456789";

		public static StringBuilder CurrentSeq;

		public static string InitialStr;

		public static bool Found = false;

		public static void Main()
		{
			InitialStr = Console.ReadLine();
			CurrentSeq = new StringBuilder(InitialStr);

			Console.WriteLine(Solve(0));
		}

		public static string Solve(int index, int lastDigitIndex = 0)
		{
			if (index == CurrentSeq.Length)
			{
				return CurrentSeq.ToString();
			}

			if (InitialStr[index] == '?')
			{
				if (index != InitialStr.Length - 1 && index != 0 && char.IsDigit(CurrentSeq[index - 1]))
				{
					CurrentSeq[index] = ',';
				}
				else
				{
					int start = (lastDigitIndex + 1) % Symbols.Length;

					if (start == 0 && (index == 0 || CurrentSeq[index - 1] == ','))
					{
						start++;
					}

					for (int i = start; i < Symbols.Length; i++)
					{
						CurrentSeq[index] = Symbols[i];
						return Solve(index + 1, i);
					}
				}
			}

			return Solve(index + 1);
		}

		public static bool IsVlideSeq(StringBuilder str)
		{
			if (str[0] == '0' || str[0] == ',' || str[str.Length - 1] == ',')
			{
				return false;
			}

			for (int i = 1; i < str.Length; i++)
			{
				if ((str[i] == '0' || str[i] == ',') && str[i - 1] == ',')
				{
					return false;
				}
			}

			int[] numbers = str.ToString().Split(',')
				.Select(int.Parse)
				.ToArray();

			for (int i = 1; i < numbers.Length; i++)
			{
				if (numbers[i - 1] >= numbers[i])
				{
					return false;
				}
			}


			return true;
		}
	}
}