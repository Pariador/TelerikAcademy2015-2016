namespace LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    using NumbersInList;

    public static class LongestSubsequence
    {
        public static int[] FindLongestSubsequence(int[] numbers)
        {

            int longestSequence = 1;
            int longestSequenceNumber = numbers[0];
            int currentCount = 1;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i - 1] == numbers[i])
                {
                    currentCount++;
                }
                else
                {
                    currentCount = 1;
                }

                if (currentCount > longestSequence)
                {
                    longestSequence = currentCount;
                    longestSequenceNumber = numbers[i];
                }
            }

            int[] result = new int[longestSequence];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = longestSequenceNumber;
            }

            return result;
        }

        public static void Main()
        {
            List<int> numbers = NumbersInList.GetNumbersList();

            int[] sequence = LongestSubsequence.FindLongestSubsequence(numbers.ToArray());

            string sequenceStr = string.Join(", ", sequence);
            Console.WriteLine("\nLongest Subsequence:");
            Console.WriteLine(sequenceStr);
        }
    }
}