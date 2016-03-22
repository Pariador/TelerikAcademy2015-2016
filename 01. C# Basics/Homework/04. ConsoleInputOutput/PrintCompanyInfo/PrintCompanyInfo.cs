using System;

class PrintCompanyInfo
{
    static void Main()
    {
        Console.Write("Enter company name: ");
        string companyName = Console.ReadLine();

        Console.Write("Enter company address: ");
        string companyAddress = Console.ReadLine();

        Console.Write("Enter company phone: ");
        string companyPhone = Console.ReadLine();

        Console.Write("Enter company fax number: ");
        string faxNumber = Console.ReadLine();

        Console.Write("Enter company website: ");
        string website = Console.ReadLine();

        Console.Write("Enter manager first name: ");
        string managerFirstName = Console.ReadLine();

        Console.Write("Enter manager last name: ");
        string managerLastName = Console.ReadLine();

        Console.Write("Enter manager age: ");
        byte managerAge = byte.Parse(Console.ReadLine());

        Console.Write("Enter manager phone: ");
        string managerPhone = Console.ReadLine();

        Console.WriteLine("\n{0}", companyName);
        Console.WriteLine("Adress: {0}", companyAddress);
        Console.WriteLine("Tel. {0}", companyPhone);
        Console.WriteLine("Fax: {0}", faxNumber);
        Console.WriteLine("Web Site: {0}", website);
        Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})\n", managerFirstName, managerLastName, managerAge, managerPhone);
    }
}