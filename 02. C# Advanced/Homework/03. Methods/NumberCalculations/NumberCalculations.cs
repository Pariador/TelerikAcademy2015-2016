//Problem 15.* Number calculations
//Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.)
//Use generic method (read in Internet about generic methods in C#).

namespace NumberCalculas
{
    using System;

    public class NumberCalculations
    {
        public static T NumMax<T>(params T[] numbers) where T : System.IComparable<T>
        {
            T maxNumber = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i].CompareTo(maxNumber) > 0)
                {
                    maxNumber = numbers[i];
                }
            }

            return maxNumber;
        }

        public static T NumMin<T>(params T[] numbers) where T : System.IComparable<T>
        {
            T minNumber = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i].CompareTo(minNumber) < 0)
                {
                    minNumber = numbers[i];
                }
            }

            return minNumber;
        }

        public static dynamic NumSum(params dynamic[] numbers)
        {

            dynamic total = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].GetType().ToString() == "System.String")
                {
                    return 0;
                }

                total += numbers[i];
            }

            return total;
        }

        public static decimal NumAVG(params dynamic[] numbers)
        {
            return (decimal)NumSum(numbers) / numbers.Length;
        }

        public static dynamic NumProduct(params dynamic[] numbers)
        {
            dynamic product = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].GetType().ToString() == "System.String")
                {
                    return 0;
                }

                product *= numbers[i];
            }

            return product;
        }

        static void Main()
        {
            byte intByte = 13;
            short intShort = 1337;
            dynamic[] arr = { 1, 2, 3 };
            Console.WriteLine("Max: {0}", NumMax(intByte, intShort, 123456, 19L, -3.14M));
            Console.WriteLine("Min: {0}", NumMin(intByte, intShort, 123456, 19L, -3.14M));
            Console.WriteLine("Sum: {0}", NumSum(intByte, intShort, 123456, 19L, -3.14M));
            Console.WriteLine("AVG: {0}", NumAVG(intByte, intShort, 123456, 19L, -3.14M));
            Console.WriteLine("Product: {0}\n", NumProduct(intByte, intShort, 123456, 19L, -3.14M));

        }
    }
}