namespace OperatorSequence
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class OperatorSequence
    {
        public static bool IsDivisionValid(int number, int boundry)
        {
            return (number % 2 == 0) && (number / 2 >= boundry) && (number > 2);
        }

        public static Stack<int> GeSequence(int start, int target)
        {
            if (start > target)
            {
                throw new ArgumentException("Start needs to be greater than target.");
            }

            Stack<int> sequence = new Stack<int>();
            sequence.Push(target);

            int current = target;
            while (current != start)
            {
                if (OperatorSequence.IsDivisionValid(current, start))
                {
                    current /= 2;
                }
                else
                {
                    int minusOne = current - 1;

                    if ((minusOne == start) || (OperatorSequence.IsDivisionValid(minusOne, start)))
                    {
                        current = minusOne;
                    }
                    else
                    {
                        current -= 2;
                    }
                }

                sequence.Push(current);
            }

            return sequence;
        }

        public static void Main()
        {
            Console.Write("Enter start: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Enter target: ");
            int target = int.Parse(Console.ReadLine());

            var sequence = OperatorSequence.GeSequence(start, target);

            string sequenceStr = string.Join(" => ", sequence);

            Console.WriteLine("\nSequence:");
            Console.WriteLine(sequenceStr);
        }
    }
}