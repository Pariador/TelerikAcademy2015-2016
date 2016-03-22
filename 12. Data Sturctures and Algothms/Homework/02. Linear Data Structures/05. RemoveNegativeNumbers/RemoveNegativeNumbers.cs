namespace RemoveNegativeNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using NumbersInList;

    public static class RemoveNegativeNumbers
    {
        public static void Main()
        {
            List<int> numbers = NumbersInList.GetNumbersList();

            var onlyPositiveNumbers = numbers.Where(num => num >= 0);

            string numbersStr = string.Join(", ", onlyPositiveNumbers);
            Console.WriteLine("\nOnly pisitive numbers:");
            Console.WriteLine(numbersStr);
        }
    }
}