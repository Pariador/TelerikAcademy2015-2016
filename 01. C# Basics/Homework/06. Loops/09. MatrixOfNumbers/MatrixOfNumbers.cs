using System;

class MatrixOfNumbers
{
    static void Main()
    {
        byte n;

        do
        {
            Console.Write("Input n (0 <= n <= 20): ");
        }
        while (!byte.TryParse(Console.ReadLine(), out n) || n < 0 || n > 20);

        Console.WriteLine();

        for (int row = 1; row <= n; row++)
        {
            for (int column = row; column <= n + row - 1; column++)
            {
                Console.Write("{0, 2} ", column);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}