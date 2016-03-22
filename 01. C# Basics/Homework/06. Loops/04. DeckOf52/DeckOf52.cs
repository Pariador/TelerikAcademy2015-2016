using System;

class DeckOf52
{
    static void Main()
    {
        string[] faces = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};

        string[] suits = {"clubs", "diamonds", "hearts", "spades"};


        Console.WriteLine("A standard 52 card deck:\n");

        foreach (string face in faces)
        {
            foreach (string suit in suits)
            {
                Console.Write("{0, 2} of {1}, ", face, suit);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}