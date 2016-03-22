namespace Problem6
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public static class Program6
	{
		public static string Text;

		public static void Main()
		{
			string word = Console.ReadLine();
			Text = Console.ReadLine();

			int result = 0;
			var prefixs = new List<string>();
			var postfixs = new List<string>();

			var strOccurences = new Dictionary<string, int>();

			for (int i = 1; i < word.Length; i++)
			{
				string prefix = word.Substring(0, i);
				prefixs.Add(prefix);

				string postfix = word.Substring(i, word.Length - i);
				postfixs.Add(postfix);
			}

			for (int i = 0; i < prefixs.Count; i++)
			{
				int preMatches = Matches(prefixs[i]);
				int postMatches = Matches(postfixs[i]);

				result += (preMatches == 0 ? 1 : preMatches) * (postMatches == 0 ? 1 : postMatches);
			}

			result += Matches(word);

			Console.WriteLine(result);
		}

		public static int Matches(string word)
		{
			int wordHash = word.GetHashCode();
			int wordHash2 = SecondHash(word);
			int wordHash3 = ThirdHash(word);

			int count = 0;
			for (int i = 0; i < Text.Length - (word.Length - 1); i++)
			{
				string part = Text.Substring(i, word.Length);

				int partHash = part.GetHashCode();
				int partHash2 = SecondHash(part);
				int partHash3 = ThirdHash(part);

				if (partHash == wordHash && partHash2 == wordHash2 && wordHash3 == partHash3)
				{
					count++;
				}
			}
			return count;
		}


		public static int ThirdHash(string str)
		{
			int hash = 0;

			for (int i = 0; i < str.Length; i++)
			{
				hash += str[i];
				hash += (hash << 10);
				hash ^= (hash >> 6);
			}

			hash += (hash << 3);
			hash ^= (hash >> 11);
			hash += (hash << 15);

			return hash;
		}

		public static int SecondHash(string str)
		{
			int hash = 0;

			for (int i = 0; i < str.Length; i++)
			{
				hash = hash ^ str[i];
			}

			hash = hash << 17;

			hash *= 97;

			hash /= str[0] + str[str.Length - 1];

			return hash;
		}
	}
}