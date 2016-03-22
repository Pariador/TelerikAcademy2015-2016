using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int search = int.Parse(Console.ReadLine());
        int numCount = int.Parse(Console.ReadLine());

        int result = 0;
        for (int i = 0; i < numCount; i++)
        {
            int number = int.Parse(Console.ReadLine());

            int find = search & 15;
            int mask = 15;
            for (int j = 0; j < 27; j++)
            {
                int compare = number & mask;

                if (compare == find)
                {
                    result++;
                }
                mask = mask << 1;
                find = find << 1;
            }
            
        }
        Console.WriteLine(result);
    }
}