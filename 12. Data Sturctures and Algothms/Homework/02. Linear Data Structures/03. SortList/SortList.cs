namespace SortList
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using NumbersInList;

    public static class SortList
    {
        public static void Main()
        {
            List<int> numbers = NumbersInList.GetNumbersList();

            var orderedNumbers = numbers.OrderBy(num => num);

            string numbersStr = string.Join(", ", orderedNumbers);
            Console.WriteLine("\nOrdered numbers:");
            Console.WriteLine(numbersStr);
        }
    }
}