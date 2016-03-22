namespace CustomException
{
    using System;

    internal static class EntryPoint
    {
        internal static void Main()
        {
            //throw new InvalidRangeException<int>(0, 10);
            throw new InvalidRangeException<DateTime>(new DateTime(1980, 3, 3), new DateTime(2004, 3, 3));
        }
    }
}