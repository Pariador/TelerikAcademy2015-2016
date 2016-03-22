
namespace Sequence
{
    using System;
    using System.Collections.Generic;

    public class Sequence
    {
        public static int[] WithArray(int seed, int length)
        {
            int[] sequence = new int[length];
            sequence[0] = seed;
            int baseIndex = 0;
            for (int i = 1; i < sequence.Length; i += 3)
            {
                sequence[i] = sequence[baseIndex] + 1;

                if (i + 1 < sequence.Length)
                {
                    sequence[i + 1] = (sequence[baseIndex] * 2) + 1;
                }

                if (i + 2 < sequence.Length)
                {
                    sequence[i + 2] = sequence[baseIndex] + 2;
                }

                baseIndex++;
            }


            return sequence;
        }

        public static int[] WithQueue(int seed, int length)
        {
            Queue<int> baseValues = new Queue<int>();
            baseValues.Enqueue(seed);

            int[] sequence = new int[length];
            sequence[0] = seed;
            for (int i = 1; i < sequence.Length; i += 3)
            {
                int baseValue = baseValues.Dequeue();

                sequence[i] = baseValue + 1;
                baseValues.Enqueue(sequence[i]);

                if (i + 1 < sequence.Length)
                {
                    sequence[i + 1] = (baseValue * 2) + 1;
                    baseValues.Enqueue(sequence[i + 1]);
                }

                if (i + 2 < sequence.Length)
                {
                    sequence[i + 2] = baseValue + 2;
                    baseValues.Enqueue(sequence[i + 2]);
                }
            }

            return sequence;
        }

        public static void Main()
        {
            Console.Write("Input sequence seed: ");
            int seed = int.Parse(Console.ReadLine());

            Console.Write("Input sequence length: ");
            int length = int.Parse(Console.ReadLine());

            //int[] sequence = Sequence.WithArray(seed, length);
            int[] sequence = Sequence.WithQueue(seed, length);

            string sequenceStr = string.Join(", ", sequence);
            Console.WriteLine("\nSequence:");
            Console.WriteLine(sequenceStr);
        }
    }
}