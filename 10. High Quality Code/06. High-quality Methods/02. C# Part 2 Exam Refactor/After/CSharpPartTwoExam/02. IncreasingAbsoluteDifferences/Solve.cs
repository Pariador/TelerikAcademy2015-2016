namespace IncreasingAbsoluteDifferences
{
    using System;
    using System.Linq;

    public class Solve
    {
        public static bool IsIncreasingAbsoluteSeq(int[] numbers)
        {
            int previousDiff = Math.Abs(numbers[0] - numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                int absDiff = Math.Abs(numbers[i - 1] - numbers[i]);

                if ((previousDiff != absDiff) && (previousDiff + 1 != absDiff))
                {
                    return false;
                }

                previousDiff = absDiff;
            }

            return true;
        }

        internal static void Main()
        {
            int lineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < lineCount; i++)
            {
                int[] numbers = Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToArray();
                bool answer = Solve.IsIncreasingAbsoluteSeq(numbers);
                Console.WriteLine(answer);
            }
        }
    }
}