namespace StudentApp
{
    using System;

    public static class Validator
    {
        public static void NameLength(string value)
        {
            if (value != null && value.Length > 50)
            {
                throw new ArgumentException("Names mustn't be over 50 chars.");
            }
        }
        public static string EmptyStr(string value, string name)
        {
            if (value != null)
            {
                value = value.Trim();
            }

            if (value == string.Empty)
            {
                throw new ArgumentException(string.Format("{0} mustn't be empty or whitespace.", name));
            }

            return value;
        }
        public static string EmptyNullStr(string value, string name)
        {
            if (value != null)
            {
                value = value.Trim();
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(string.Format("{0} mustn't be empty, null, whitespace.", name));
            }

            return value;
        }
    }
}