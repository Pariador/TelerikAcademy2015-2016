using System;

class PrintASCII
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode; //change output incoding

        for (int i = 0; i < 256; i++)
        {
            Console.WriteLine("ASCII {0}: {1}", i, (char)i);
        }
    }
}