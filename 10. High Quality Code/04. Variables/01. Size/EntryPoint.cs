namespace Size
{
    using System;

    internal static class EntryPoint
    {
        internal static void Main()
        {
            const double Angle = 106.4;

            Size beforeRotation = new Size(12.5, 14.2);
            Size afterRotation = beforeRotation.GetRotatedSize(Angle);

            Console.WriteLine("Before rotation: {0}", beforeRotation);
            Console.WriteLine("After rotation: {0}", afterRotation);
        }
    }
}