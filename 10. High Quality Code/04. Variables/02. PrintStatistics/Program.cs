namespace PrintStatistics
{
    using System;
    using System.Text;

    internal class EntryPoint
    {
        internal static double Max(double[] arr)
        {
            double max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        internal static double Min(double[] arr)
        {
            double min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            return min;
        }

        internal static void PrintStatistics(double[] values)
        {
            double min = Min(values);
            double max = Max(values);
            double average = max / values.Length;

            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("Min: {0}", min));
            result.AppendLine(string.Format("Max: {0}", max));
            result.Append(string.Format("Average: {0}", average));

            Console.WriteLine(result);
        }

        internal static void Main()
        {
            PrintStatistics(new double[]{1.2, 4.2, 5.6, 12313.2, 4});
        }
    }
}
