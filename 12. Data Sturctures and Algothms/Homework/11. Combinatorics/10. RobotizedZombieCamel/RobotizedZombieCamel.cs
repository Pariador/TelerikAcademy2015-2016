namespace RobotizedZombieCamelSolution
{
	using System;
	using System.Linq;
	using System.Numerics;

	public static class RobotizedZombieCamel
	{
		public static void Main()
		{
			int obeliskCount = int.Parse(Console.ReadLine());

			int[] obeliskDistances = new int[obeliskCount];
			for (int i = 0; i < obeliskCount; i++)
			{
				// In the test's input there are a few blank lines before each position.
				// The do-while is used to skip them and find the position input.
				string line;
				do
				{
					line = Console.ReadLine();
				} while (string.IsNullOrEmpty(line));

				string[] input = line
					.Split(' ');

				int x = int.Parse(input[0]);
				int y = int.Parse(input[1]);

				obeliskDistances[i] = Math.Abs(x) + Math.Abs(y);
			}

			ulong result = RobotizedZombieCamel.GetReqiredRopeLength(obeliskDistances);

			Console.WriteLine(result);
		}

		public static ulong GetReqiredRopeLength(int[] obeliskDistances)
		{
			int sum = obeliskDistances.Sum();

			// Is always equal to obeliskDistances.Length
			BigInteger combinationsOfOneCount = GetCombinationsCount(obeliskDistances.Length, 1);
			ulong requiredRopeLength = (ulong)(sum * combinationsOfOneCount);

			if (obeliskDistances.Length <= 2)
			{
				return requiredRopeLength;
			}

			// Is always equal to 1.
			BigInteger combinationsOfAllCount = GetCombinationsCount(obeliskDistances.Length, obeliskDistances.Length);
            requiredRopeLength += (ulong)(sum * combinationsOfAllCount);

			if (obeliskDistances.Length == 3)
			{
				return requiredRopeLength;
			}

			int halfObeliskCount = obeliskDistances.Length / 2;
			for (int combinationSize = 2; combinationSize < halfObeliskCount; combinationSize++)
			{
				BigInteger combinationsCount = GetCombinationsCount(obeliskDistances.Length, combinationSize);

				requiredRopeLength += (ulong)(combinationsCount * sum);
			}

			BigInteger combinationsOfHalfCount = GetCombinationsCount(obeliskDistances.Length, halfObeliskCount);
			BigInteger sumCountInCombinations = combinationsOfHalfCount;

			if (obeliskDistances.Length % 2 == 0)
			{
				sumCountInCombinations /= 2;
			}


			requiredRopeLength += (ulong)(sumCountInCombinations * sum);

			return requiredRopeLength;
        }

		public static BigInteger GetCombinationsCount(int setLength, int combinationSize)
		{
			if (setLength == combinationSize)
			{
				return 1;
			}

			if (combinationSize == 1)
			{
				return setLength;
			}

			Func<int, BigInteger> fac = RobotizedZombieCamel.Factorial;

			// Formula for calculating the count of combinations without repetition.
			// Aka. Binomial Coefficient, a.k.a. m choose n
			return fac(setLength) / (fac(combinationSize) * fac(setLength - combinationSize));
		}

		public static BigInteger Factorial(int number)
		{
			if (number < 0)
			{
				throw new ArgumentException("Can't have factorials of negative numbers.");
			}

			if (number < 2)
			{
				return 1;
			}

			BigInteger result = 1;
			for (int i = number; i >= 2; i--)
			{
				result *= i;
			}

			return result;
		}
	}
}