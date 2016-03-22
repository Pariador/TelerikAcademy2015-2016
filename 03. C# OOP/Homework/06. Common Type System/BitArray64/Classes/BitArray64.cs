namespace BitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<bool>, IEnumerable
    {
        private const int ArrayLength = 64;

        private ulong arr;

        public BitArray64()
        {
            this.arr = 0;
        }

        public int Length
        {
            get
            {
                return BitArray64.ArrayLength;
            }
        }

        public bool this[int index]
        {
            get
            {
                Validator.ValidateIndex(index);

                ulong mask  = (ulong)1 << index;
                ulong result = (this.arr & mask) >> index;
                return result == 1;
            }
            set
            {
                Validator.ValidateIndex(index);

                ulong mask = (ulong)1 << index;

                if (value)
                {
                    this.arr = this.arr | mask;
                }
                else
                {
                    this.arr = this.arr & ~mask;
                }
            }
        }

        public override bool Equals(object obj)
        {
            BitArray64 other = obj as BitArray64;

            if (other != null)
            {
                return this.Equals(other);
            }

            return false;
        }
        public bool Equals(BitArray64 other)
        {
            return this.arr == other.arr;
        }
        public override int GetHashCode()
        {
            ulong mask = 4294967295;

            int firstHalf = (int)(this.arr & mask);
            int secondHalf = (int)((this.arr & (mask << 32)) >> 32);

            return firstHalf ^ secondHalf;
        }
        public override string ToString()
        {
            return Convert.ToString((long)this.arr, 2).PadLeft(64, '0');
        }

        public static bool operator ==(BitArray64 firstArr, BitArray64 secondArr)
        {
            return firstArr.Equals(secondArr);
        }
        public static bool operator !=(BitArray64 firstArr, BitArray64 secondArr)
        {
            return !(firstArr == secondArr);
        }

        public IEnumerator<bool> GetEnumerator()
        {
            for (int i = 0; i < BitArray64.ArrayLength; i++)
            {
                yield return this[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < BitArray64.ArrayLength; i++)
            {
                yield return this[i];
            }
        }
    }
}