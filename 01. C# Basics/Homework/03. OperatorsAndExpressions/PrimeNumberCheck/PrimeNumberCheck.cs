using System;

class PrimeNumberCheck
{
    static void Main()
    {
        Console.Write("Input a number <= 100: "); 
        sbyte number = sbyte.Parse(Console.ReadLine());
            
        if (number > 100)
        { 
            Console.WriteLine("\nNumber is bigger than 100.\n"); 
        }
        else if (number < 2)
        {
            Console.WriteLine("\nNumber is not prime.\n");
        }
        else if (number == 2)
        {
            Console.WriteLine("\nThe number is prime.\n");
        }
        else
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    Console.WriteLine("\nNumber is not prime.\n");
                    break;
                }

                if (i == number - 1)
                {
                    Console.WriteLine("\nThe number is prime.\n");
                }
            }
        }
    }
}