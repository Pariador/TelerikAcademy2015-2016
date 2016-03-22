using System;

namespace BiDictionary
{
	public static class Program
	{
		public static void Main()
		{
			var biDict = new BiDictionary<int, int, string>();

			biDict.AddWithFirstKey(1, "first");
			biDict.AddWithSecondKey(2, "second");
			biDict.AddWithKeys(1, 2, "third");

			Console.WriteLine(string.Join(", ", biDict.GetByFirstKey(1)));

			Console.WriteLine(string.Join(", ", biDict.GetBySecondKey(2)));

			Console.WriteLine(string.Join(", ", biDict.GetByKeys(1, 2)));
		}
	}
}