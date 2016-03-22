namespace JediMeditationApp
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            Console.ReadLine();

            string[] jedi = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var result = jedi.OrderBy(j =>
            {
                int rank = 0;
                switch (j[0])
                {
                    case 'k':
                    rank = 1;
                    break;
                    case 'p':
                    rank = 2;
                    break;
                }

                return rank;
            });

            Console.WriteLine(string.Join(" ", result));
        }
    }
}