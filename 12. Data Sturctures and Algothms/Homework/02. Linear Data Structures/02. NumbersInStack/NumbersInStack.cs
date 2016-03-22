namespace NumbersInStack
{
    using System;
    using System.Collections.Generic;

    public static class NumbersInStack
    {
        public static void Main()
        {
            Console.Write("Numbers count: ");
            int numbersCount = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < numbersCount; i++)
            {
                Console.Write("Input number[{0}]: ", i);
                int number = int.Parse(Console.ReadLine());
                numbers.Push(number);
            }

            string numbersStr = string.Join(", ", numbers);
            Console.WriteLine("\nNumbers in stack:");
            Console.WriteLine(numbersStr);
        }
    }
}