namespace ConsoleClient
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public static class RandomGenerator
    {
        private static readonly Random Random = new Random();

        public static int GetInt(int min, int max)
        {
            return RandomGenerator.Random.Next(min, max + 1);
        }

        public static string GetString(int length)
        {
            const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int index = RandomGenerator.Random.Next(0, Alphabet.Length);
                builder.Append(Alphabet[index]);
            }

            return builder.ToString();
        }

        public static string GetString(int minLength, int maxLength)
        {
            int length = RandomGenerator.GetInt(minLength, maxLength);

            return RandomGenerator.GetString(length);
        }

        public static DateTime GetDateTime(DateTime min, DateTime max)
        {
            int year = RandomGenerator.GetInt(min.Year, max.Year);
            int month = RandomGenerator.GetInt(min.Month, max.Month);
            int day = RandomGenerator.GetInt(min.Day, max.Day);

            if (day > 28)
            {
                day = 28;
            }

            int hour = RandomGenerator.GetInt(min.Hour, max.Hour);
            int minute = RandomGenerator.GetInt(min.Minute, max.Minute);
            int second = RandomGenerator.GetInt(min.Second, max.Second);


            return new DateTime(year, month, day, hour, minute, second);
        }

        public static DateTime GetDateTime() 
        {
            return RandomGenerator.GetDateTime(new DateTime(1960, 1, 1), new DateTime(2050, 12, 15));
        }

        public static T GetFromList<T>(IList<T> list)
        {
            int index = RandomGenerator.Random.Next(0, list.Count);

            return list[index];
        }
    }
}