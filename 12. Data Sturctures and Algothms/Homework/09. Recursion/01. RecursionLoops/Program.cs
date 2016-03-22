namespace RecursionLoops
{
	using System;

	public static class Program
	{
		public static void Main()
		{
			int from = 0;
			int to = 100;
			int loopCount = 3;
			int count = 0;

			Looper.ForLoops(ref from, ref to, loopCount, () => count++);

			Console.WriteLine("Expected Count: {0}", Math.Pow((to - from), loopCount));
			Console.WriteLine("Count: {0}", count);
		}
	}
}