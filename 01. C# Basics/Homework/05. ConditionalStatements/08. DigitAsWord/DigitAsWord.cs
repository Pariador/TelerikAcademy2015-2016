using System;

class DigitAsWord
{
    static void Main()
    {
        Console.Write("Input first real numver: ");
        
        char digit;

        if (char.TryParse(Console.ReadLine(), out digit))
        {
            switch (digit)
            {
                case '0':
                    Console.WriteLine("\nZero.\n");
                    break;
                case '1':
                    Console.WriteLine("\nOne.\n");
                    break;
                case '2':
                    Console.WriteLine("\nTwo.\n");
                    break;
                case '3':
                    Console.WriteLine("\nThree.\n");
                    break;
                case '4':
                    Console.WriteLine("\nFour.\n");
                    break;
                case '5':
                    Console.WriteLine("\nFive.\n");
                    break;
                case '6':
                    Console.WriteLine("\nSix.\n");
                    break;
                case '7':
                    Console.WriteLine("\nSeven.\n");
                    break;
                case '8':
                    Console.WriteLine("\nEight.\n");
                    break;
                case '9':
                    Console.WriteLine("\nNine.\n");
                    break;
                default:
                    Console.WriteLine("\nNot a digit.\n");
                    break;
            }
        }
        else 
        {
            Console.WriteLine("\nNot a digit.\n");
        }
    }
}