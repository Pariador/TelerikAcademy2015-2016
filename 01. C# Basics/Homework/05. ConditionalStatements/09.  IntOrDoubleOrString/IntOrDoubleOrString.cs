using System;

class IntOrDoubleOrString
{
    static void Main()
    {
        Console.WriteLine("Please Choose a type: int(1), double(2), string(3).");
        char choice = char.Parse(Console.ReadLine());

        switch (choice)
        {
            case '1':
                Console.Write("\nInput an integer: ");
                int integer = int.Parse(Console.ReadLine());

                Console.WriteLine("\n{0} + 1 = {1}\n", integer, integer + 1);
                break;
            case '2':
                Console.Write("\nInput a double: ");
                double doubleVar = double.Parse(Console.ReadLine());

                Console.WriteLine("\n{0} + 1 = {1}\n", doubleVar, doubleVar + 1);
                break;
            case '3':
                Console.Write("\nInput a string: ");
                string str = Console.ReadLine();

                Console.WriteLine("\n{0}*\n", str);
                break;
            default:
                Console.WriteLine("\nMistakes were made!\n");
                break;
        }
    }
}