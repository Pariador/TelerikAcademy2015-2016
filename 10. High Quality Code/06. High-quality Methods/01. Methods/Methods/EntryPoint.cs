namespace Methods
{
    using System;
    using System.ComponentModel;

    public enum PrintFormats
    {
        Floating,
        Percentage,
        PaddedLeft
    }

    public static class EntryPoint
    {
        public static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            bool isSideAValid = (sideA > 0) && (sideA < (sideB + sideC));
            if (!isSideAValid)
            {
                throw new ArgumentException("Side a is invalid.");
            }

            bool isSideBValid = (sideB > 0) && (sideB < (sideA + sideC));
            if (!isSideAValid)
            {
                throw new ArgumentException("Side b is invalid.");
            }

            bool isSideCValid = (sideC > 0) && (sideC < (sideA + sideB));
            if (!isSideAValid)
            {
                throw new ArgumentException("Side c is invalid.");
            }

            double halfPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter -sideC));
            return area;
        }

        public static string DigitToWord(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid digit.");
            }
        }

        public static int MaxNumber(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Nubmers has to be an array of with least one number.");
            }

            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        public static void PrintInFormat(double number, PrintFormats format)
        {
            string result;
            switch (format)
            {
                case PrintFormats.Floating:
                    result = string.Format("{0:f2}", number);
                    break;
                case PrintFormats.Percentage:
                    result = string.Format("{0:p0}", number);
                    break;
                case PrintFormats.PaddedLeft:
                    result = string.Format("{0,8}", number);
                    break;
                default:
                    throw new InvalidEnumArgumentException("Unknown Print Format.");
            }

            Console.WriteLine(result);
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        internal static void Main()
        {
            Console.WriteLine(EntryPoint.CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(EntryPoint.DigitToWord(5));

            Console.WriteLine(EntryPoint.MaxNumber(5, -1, 3, 2, 14, 2, 3));
            
            EntryPoint.PrintInFormat(1.3, PrintFormats.Floating);
            EntryPoint.PrintInFormat(0.75, PrintFormats.Percentage);
            EntryPoint.PrintInFormat(2.30, PrintFormats.PaddedLeft);

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 17))
            {
                Info = "From Sofia."
            };
            
            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 3))
            {
                Info = "From Vidin, gamer, high results."
            };

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
