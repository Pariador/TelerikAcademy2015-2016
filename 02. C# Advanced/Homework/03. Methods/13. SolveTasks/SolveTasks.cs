using System;
using Reverse; //07. ReverseNumber - > Reverse.ReverseDigits.Reverse();
using NumberCalculas; // 15. NumberCalculation - > Numbercalculas.NumberCalculations.NumAVG();

//Problem 13. Solve tasks
//Write a program that can solve these tasks:
//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0
//Create appropriate methods.
//Provide a simple text-based menu for the user to choose which task to solve.
//Validate the input data:
//The decimal number should be non-negative
//The sequence should not be empty
//a should not be equal to 0

class SolveTasksTest
{
    static double LinearEq(int a, int b)
    {
        return -(b) / (double) a;
    }
    static void Main()
    {
        string menu = "1. Reverse positive integer.\n2. Average of sequence of integers.\n3. Solve a linear equation a * x + b = 0.\n4. Exit.\n";
        
        int answer = 0;

        while (true)
        {
            Console.WriteLine(menu);
            
            //loop until valid input is given 
            do
            {
                Console.Write("Answer: ");
            } while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 4);

            if (answer == 1)
            {
                int number = 0;

                //loop until valid input is given
                do
                {
                    Console.Write("\nPositive integer: ");
                } while (!int.TryParse(Console.ReadLine(), out number) || number < 0);

                Console.WriteLine("\nThe number in reverse: {0}\n", ReverseDigits.Reverse(number));
            }
            else if (answer == 2)
            {
                Console.Write("\nInput integers seperated by space: ");
                string strNumbers = Console.ReadLine();

                string[] strArr = strNumbers.Split(' ');
                int length = strArr.Length;
                dynamic[] numbers = new dynamic[length]; //the array needs to be dynamic because of NumAVG()

                bool fail = false;
                int hold = 0;
                for (int i = 0; i < length; i++)
                {
                    if (!int.TryParse(strArr[i], out hold))
                    {
                        fail = true;
                        break;
                    }

                    numbers[i] = hold;
                }

                //If input is wrong do nothing.
                if (!fail)
                {
                    Console.WriteLine("\nAverage: {0}", NumberCalculations.NumAVG(numbers));
                }
                Console.WriteLine();
            }
            else if (answer == 3)
            {
                //loop until valid input is given
                int a = 0;
                do
                {
                    Console.Write("\nInput a: ");
                } while (!int.TryParse(Console.ReadLine(), out a) || a == 0);

                int b = 0;
                do
                {
                    Console.Write("\nInput b: ");
                } while (!int.TryParse(Console.ReadLine(), out b));

                Console.WriteLine("\nX is: {0}\n", LinearEq(a, b));
            }
            else
            {
                Console.WriteLine();
                break;
            }          
        }
    }
}