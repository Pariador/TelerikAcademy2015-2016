namespace BitArray64
{
    using System;

    public static class BitArray64Test
    {
        public static void Satrt()
        {
            var bitArr = new BitArray64();

            bitArr[0] = true;
            Console.WriteLine("0: {0}", bitArr[0]);
            bitArr[0] = false;
            Console.WriteLine("0: {0}", bitArr[0]);
            bitArr[0] = true;

            bitArr[63] = true;
            Console.WriteLine("63: {0}", bitArr[63]);
            bitArr[63] = false;
            Console.WriteLine("63: {0}", bitArr[63]);
            bitArr[63] = true;

            Console.WriteLine(bitArr.GetHashCode());

            Console.WriteLine("-------------");
            foreach (var bit in bitArr)
            {
                Console.WriteLine(bit);
            }

        }
    }
}