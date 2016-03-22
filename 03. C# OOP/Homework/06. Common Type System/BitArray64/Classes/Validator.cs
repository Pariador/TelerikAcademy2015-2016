namespace BitArray64
{
    using System;

    public static class Validator
    {
        public static void ValidateIndex(int index)
        {
            if (index < 0 || index > 63)
            {
                throw new IndexOutOfRangeException("BitArray64 index must be between 0 and 63.");
            }
        }
    }
}