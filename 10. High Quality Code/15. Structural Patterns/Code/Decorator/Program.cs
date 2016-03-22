namespace Decorator
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var plain = new Cookie();
            Console.WriteLine("Plain cookie taste: {0}", plain.GetTasteRating()); // 1

            var caramel = new CaramelDecorator(plain);
            Console.WriteLine("Caramel cookie taste: {0}", caramel.GetTasteRating()); // 5

            var choco = new ChocolateDecorator(plain);
            Console.WriteLine("Choco cookie taste: {0}", choco.GetTasteRating()); // 6

            var chocoCaramel = new CaramelDecorator(choco);
            Console.WriteLine("ChocoCaramel cookie taste: {0}", chocoCaramel.GetTasteRating()); // 10
        }
    }
}