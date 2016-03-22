namespace AnimalHierarchy
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class EntryPoint
    {
        public static Random rand = new Random();

        public static int GetAge()
        {
            return rand.Next(1, 31);
        }
        public static double? AverageAge(IEnumerable<Animal> animals)
        {
            return animals.Average(anml => anml.Age);
        }
        public static void Concert(IEnumerable<ISound> singers)
        {
            foreach (var singer in singers)
            {
                singer.MakeSound();
            }
        }

        internal static void Main()
        {
            Dog[] dogs = new Dog[3];
            dogs[0] = new Dog("Stamat", GetAge(), Genders.Male);
            dogs[1] = new Dog("Sharo", GetAge(), Genders.Male);
            dogs[2] = new Dog("Bonny", GetAge(), Genders.Female);

            Console.WriteLine("Average age for the dogs: {0:0.00}", AverageAge(dogs));

            Cat[] cats = new Cat[3];
            cats[0] = new Tomcat("Tommy", GetAge());
            cats[1] = new Kitten("Kotangens", GetAge());
            cats[2] = new Kitten("Kitty Galore", GetAge());

            Console.WriteLine("\nAverage age for the cats: {0:0.00}", AverageAge(cats));

            Frog[] frogs = new Frog[4];
            frogs[0] = new Frog("Doncho", GetAge(), Genders.Male);
            frogs[1] = new Frog("Niki", GetAge(), Genders.Male);
            frogs[2] = new Frog("Evlogi", GetAge(), Genders.Male);
            frogs[3] = new Frog("Ivaylo", GetAge(), Genders.Male);

            Console.WriteLine("\nAverage age for the frogs: {0:0.00}", AverageAge(frogs));

            Console.WriteLine("\nConcert:");
            Concert(dogs.Cast<Animal>().Concat(cats.Cast<Animal>()).Concat(frogs.Cast<Animal>()));
        }
    }
}