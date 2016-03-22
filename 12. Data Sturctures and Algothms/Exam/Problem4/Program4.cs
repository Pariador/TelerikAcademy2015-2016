namespace Problem4
{
	using System;
	using System.Text;
	using System.Linq;
	using System.Collections.Generic;

	public static class Program4
	{
		public const string Keys = "1234567890";

		public static StringBuilder CurrentPassword;

		public static int Counter = 0;

		public static int PassLength;

		public static int PassWordToFind;

		public static bool Found = false;

		public static void Main()
		{
			PassLength = int.Parse(Console.ReadLine());
			string sequence = Console.ReadLine();
			PassWordToFind = int.Parse(Console.ReadLine());

			CurrentPassword = new StringBuilder(new string('*', PassLength));
			Solve(0, ref sequence);
			//Console.WriteLine(PasswordsSoFar.ElementAt(PassWordToFind));

			//Console.WriteLine("pases");
			//foreach (var item in PasswordsSoFar)
			//{
			//	Console.WriteLine(item);
			//}
		}

		public static void Solve(int index, ref string sequence)
		{
			if (Found)
			{
				return;
			}

			if (index == PassLength)
			{
				//PasswordsSoFar.Add(CurrentPassword.ToString());
				Counter++;
				if (Counter == PassWordToFind)
				{
					Found = true;
					Console.WriteLine(CurrentPassword);
				}
				return;
			}

			int nextIndex = index + 1;
			if (index == 0)
			{
				CurrentPassword[index] = Keys[Keys.Length - 1];
				Solve(nextIndex, ref sequence);

				for (int k = 0; k < Keys.Length - 1; k++)
				{
					CurrentPassword[index] = Keys[k];
					Solve(nextIndex, ref sequence);
				}
			}
			else
			{
				char direction = sequence[index - 1];

				if (direction == '<')
				{
					for (int k = 0; k < GetKeyIndex(CurrentPassword[index - 1]); k++)
					{
						CurrentPassword[index] = Keys[k];
						Solve(nextIndex, ref sequence);
					}
				}
				else if (direction == '>')
				{
					int startKey = GetKeyIndex(CurrentPassword[index - 1]) + 1;
					if (startKey < Keys.Length)
					{
						CurrentPassword[index] = Keys[Keys.Length - 1];
						Solve(nextIndex, ref sequence);
					}

					for (int k = startKey; k < Keys.Length - 1; k++)
					{
						CurrentPassword[index] = Keys[k];
						Solve(nextIndex, ref sequence);
					}
				}
				else
				{
					CurrentPassword[index] = CurrentPassword[index - 1];
					Solve(nextIndex, ref sequence);
				}
			}
		}

		public static int GetKeyIndex(char key)
		{
			if (key == '0')
			{
				return Keys.Length - 1;
			}

			return key - '1';
		}
	}
}