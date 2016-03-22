namespace AnimalHierarchy
{
    using System;

    public class Frog : Animal, ISound
    {
        public Frog(string name, int age, Genders gender) : base(name, age, gender)
        {
            ;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Ribet!");
        }
    }
}