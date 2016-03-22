namespace FindMajorant
{
    using System;
    using System.Collections.Generic;

    using NumbersInList;
    using RemoveNumbersWithOddCount;

    public static class FindMajorant
    {
        public static void Main()
        {
            List<int> numbers = NumbersInList.GetNumbersList();

            var occurrences = RemoveNumbersWithOddCount.CalcOccurrences(numbers);

            foreach (var occurrence in occurrences)
            {
                if (occurrence.Value >= (numbers.Count / 2) + 1)
                {
                    Console.WriteLine("\nThe majorant in the list is {0}.", occurrence.Key);
                    return;
                }
            }

            Console.WriteLine("\nThere is no majorant in the list.");
        }
    }
}