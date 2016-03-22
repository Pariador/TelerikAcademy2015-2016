namespace AnimalHierarchy
{
    using System;

    public class Dog : Animal, ISound
    {
        public Dog(string name, int age, Genders gender) : base(name, age, gender)
        {
            ;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Bark!");
        }
    }
}