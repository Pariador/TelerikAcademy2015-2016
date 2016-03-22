namespace MediumEditDistance
{
	using System;

	public static class Program
	{
		public static void Main()
		{
			string from = "developer";
			string to = "enveloper";

			Console.WriteLine(MediumEditDistance.Calculate(from, to));
        }
	}
}