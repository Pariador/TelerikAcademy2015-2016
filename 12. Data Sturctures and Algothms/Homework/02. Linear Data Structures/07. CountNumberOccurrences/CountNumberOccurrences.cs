namespace CountNumberOccurrences
{
    using System;
    using System.Collections.Generic;

    using NumbersInList;
    using RemoveNumbersWithOddCount;

    public static class CountNumberOccurrences
    {
        public static void Main()
        {
            List<int> numbers = NumbersInList.GetNumbersList();

            var occurrences = RemoveNumbersWithOddCount.CalcOccurrences(numbers);

            Console.WriteLine();
            foreach (var occurrence in occurrences)
            {
                Console.WriteLine("The number {0} occurs {1} times.", occurrence.Key, occurrence.Value);
            }
        }
    }
}