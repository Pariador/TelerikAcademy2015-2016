namespace NumbersInList
{
    using System;
    using System.Collections.Generic;

    public static class NumbersInList
    {
        public static List<int> GetNumbersList()
        {
            const string EndCommand = "stop";

            List<int> numbers = new List<int>();

            Console.WriteLine("Input numbers, type \"{0}\" when ready:", EndCommand);
            while (true)
            {
                Console.Write("Input: ");
                string input = Console.ReadLine().ToLower();

                if (input == EndCommand)
                {
                    break;
                }

                int number;
                bool parsed = int.TryParse(input, out number);
                if (!parsed)
                {
                    Console.WriteLine("Invalid number.");
                    continue;
                }

                numbers.Add(number);
            }

            return numbers;
        }

        public static void Main()
        {
            List<int> numbers = NumbersInList.GetNumbersList();

            string numbersStr = string.Join(", ", numbers);
            Console.WriteLine("\nNumbers:");
            Console.WriteLine(numbersStr);
        }
    }
}