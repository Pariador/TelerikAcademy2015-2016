//Problem 7. Reverse number
//Write a method that reverses the digits of given decimal number.

namespace Reverse
{
    using System;
    using System.Text;

    public class ReverseDigits
    {
        public static string Reverse(dynamic number)
        {
            bool isNegative = false;

            if (number.GetType().ToString() != "System.String")
            {
                isNegative = number < 0;
            }

            if (isNegative)
            {
                number = -(number);
            }

            string strNumber = number.ToString();

            StringBuilder result = new StringBuilder();

            for (int i = strNumber.Length - 1; i >= 0; i--)
            {
                result.Append(strNumber[i]);
            }

            if (isNegative)
            {
                result.Insert(0, '-');
            }

            return result.ToString();
        }

        static void Main()
        {
            //input
            Console.Write("Input an integer number: ");
            int integer = int.Parse(Console.ReadLine());

            Console.Write("\nInput a floating point number: ");
            double floatNum = double.Parse(Console.ReadLine());

            Console.Write("\nInput some string: ");
            string str = Console.ReadLine();


            //output
            Console.WriteLine("\nThe integer after ReverseDigits: {0}\n", Reverse(integer));

            Console.WriteLine("The float after ReverseDigits: {0}\n", Reverse(floatNum));

            Console.WriteLine("The string after ReverseDigits: {0}\n", Reverse(str));

        }
    }
}