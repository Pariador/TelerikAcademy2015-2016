namespace Extensions
{
    using System;
    using System.Text;
    using System.Globalization;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static StringBuilder SubString(this StringBuilder strBuilder, int index, int length)
        {
            strBuilder.Remove(0, index);
            strBuilder.Remove(length, strBuilder.Length - length);

            return strBuilder;
        }

        public static T Sum<T>(this IEnumerable<T> collection)
        {
            dynamic sum = default(T);
            bool isFirst = true;
            foreach (var item in collection)
            {
                if (isFirst)
                {
                    sum = item;
                    isFirst = false;
                }
                else
                {
                    checked 
                    {
                        sum += item;
                    }
                }
            }
            return sum;
        }
        public static T Product<T>(this IEnumerable<T> collection)
        {
            dynamic product = default(T);
            bool isFirst = true;
            foreach (var item in collection)
            {
                if (isFirst)
                {
                    product = item;
                    isFirst = false;
                }
                else
                {
                    checked
                    {
                        product *= item;
                    }
                }
            }
            return product;
        }
        public static long Count<T>(this IEnumerable<T> collection)
        {
            int count = 0;
            foreach (var item in collection)
            {
                count++;
            }
            return count;
        }
        public static double Average<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            double sum = collection.Sum<T>().ToDouble(CultureInfo.InvariantCulture);
            return sum / collection.Count<T>();
        }
        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable
        {
            T min = default(T);
            bool isFirst = true;
            foreach (var item in collection)
            {
                if (isFirst)
                {
                    min = item;
                    isFirst = false;
                }
                else
                {
                    if (item.CompareTo(min) == -1)
                    {
                        min = item;
                    }
                }
            }
            return min;
        }
        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
        {
            T max = default(T);
            bool isFirst = true;
            foreach (var item in collection)
            {
                if (isFirst)
                {
                    max = item;
                    isFirst = false;
                }
                else
                {
                    if (item.CompareTo(max) == 1)
                    {
                        max = item;
                    }
                }
            }
            return max;
        }
    }
}