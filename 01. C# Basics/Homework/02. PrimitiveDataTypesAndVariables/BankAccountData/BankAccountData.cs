using System;

class BankAccountData
{
    static void Main()
    {
        string firstName = "Jane";

        string middleName = "Picklefeet";

        string lastName = "Doe";

        decimal balance = 50.5M;

        string bankName = "Bulgarian National Bank";

        string iban = "GB29 NWBK 6016 1331 9268 19";

        string creditcardOne = "372348006033875";

        string creditcardTwo = "377489112261961";

        string creditcardThree = "373317347628122";

        Console.WriteLine("Holder Data:\n");
        Console.WriteLine("First Name: {0}\n", firstName);
        Console.WriteLine("Middle Name: {0}\n", middleName);
        Console.WriteLine("Last Name: {0}\n", lastName);
        Console.WriteLine("Balance: {0} BGN\n", balance);
        Console.WriteLine("Bank Name: {0}\n", bankName);
        Console.WriteLine("IBAN: {0}\n", iban);
        Console.WriteLine("First Credit Card Number: {0}\n", creditcardOne);
        Console.WriteLine("Second Credit Card Number: {0}\n", creditcardTwo);
        Console.WriteLine("Third Credit Card Number: {0}\n", creditcardThree);

    }
}