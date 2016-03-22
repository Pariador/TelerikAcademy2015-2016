namespace EnugmaCat
{
    using System;
    using System.Text;
    using System.Numerics;

    public class Solve
    {
        public static BigInteger DecodeToDecinal(string word)
        {
            const int catNumeralSystem = 17;

            BigInteger result = 0;
            for (int i = 0; i < word.Length; i++)
            {
                int digit = word[i] - 'a';

                result += digit * BigInteger.Pow(catNumeralSystem, ((word.Length - 1) - i));
            }

            return result;
        }

        public static string DecodeToEnglish(BigInteger number)
        {
            StringBuilder strBuilder = new StringBuilder();

            while (number > 0)
            {
                int digit = (int)number % 26;
                strBuilder.Insert(0, (char)(digit + 'a'));

                number /= 26;
            }

            return strBuilder.ToString();
        }

        internal static void Main()
        {
            string[] words = Console.ReadLine().Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                BigInteger decodedToDecimal = Solve.DecodeToDecinal(words[i]);
                string decodedToEnglish = Solve.DecodeToEnglish(decodedToDecimal);
                words[i] = decodedToEnglish;
            }
            Console.WriteLine(string.Join(" ", words));
        }
    }
}