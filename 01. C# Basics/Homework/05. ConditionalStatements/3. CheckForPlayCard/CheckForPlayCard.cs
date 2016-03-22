using System;

class CheckForPlayCard
{
    static void Main()
    {
        Console.Write("Input a card face: ");
        string cardSign = Console.ReadLine();

        switch (cardSign)
        {
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "10":
            case "J":
            case "Q":    
            case "K":
            case "A":
                Console.WriteLine("\nYou have entered a valid card sign.\n");
                break;
            default:
                Console.WriteLine("\nYou have entered an invalid card sign.\n");
                break;
        }
    }
}