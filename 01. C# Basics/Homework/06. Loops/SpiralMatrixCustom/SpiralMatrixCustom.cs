using System;

class SpiralMatrixCustom
{
    static void Main()
    {
        byte n;

        do
        {
            Console.Write("Input n (0 <= n <= 20): ");
        }
        while (!byte.TryParse(Console.ReadLine(), out n) || n < 0 || n > 20);

        int size = n * n;

        int[] array = new int[size];

        for (int i = 0, value = 1; i < size; i++, value++)
        {
            array[i] = value;
        }

        int hold;
        for (int i = 0; i < size; i++)
        {
            for (int q = 0, increment = 1; q < size; q += increment)
            {
                hold = array[i];
                array[i] = array[q];
                array[q] = hold;
            }
        }
    }
}