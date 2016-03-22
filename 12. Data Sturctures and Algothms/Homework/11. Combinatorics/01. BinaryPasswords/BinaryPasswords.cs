namespace BinaryPasswordsSolution
{
	using System;
	using System.Linq;
	using System.Numerics;

	public static class BinaryPasswords
	{
		public static void Main()
		{
			string line = Console.ReadLine();

			int count = line.Count(c => c == '*');

			Console.WriteLine(BigInteger.Pow(2, count));
		}
	}
}