using System;

class WeightOnTheMoon
{
    static void Main()
    {
        Console.Write("Input weight in kilograms: ");
        double weight = double.Parse(Console.ReadLine());

        Console.WriteLine("\nYour weight on the moon will be {0} kilograms.\n", weight / 100 * 17);
    }
}