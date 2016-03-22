namespace RemoveNumbersWithOddCount
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using NumbersInList;

    public static class RemoveNumbersWithOddCount
    {
        public static Dictionary<T, int> CalcOccurrences<T>(IEnumerable<T> items)
        {
            Dictionary<T, int> result = new Dictionary<T, int>();

            foreach (var item in items)
            {
                if (result.ContainsKey(item))
                {
                    result[item]++;
                }
                else
                {
                    result[item] = 1;
                }
            }

            return result;
        }

        public static void Main()
        {
            List<int> numbers = NumbersInList.GetNumbersList();

            var occurrences = RemoveNumbersWithOddCount.CalcOccurrences(numbers);

            var result = numbers.Where(num => occurrences[num] % 2 == 0);

            string numbersStr = string.Join(", ", result);
            Console.WriteLine("\nNumbers with even occurrences:");
            Console.WriteLine(numbersStr);
        }
    }
}