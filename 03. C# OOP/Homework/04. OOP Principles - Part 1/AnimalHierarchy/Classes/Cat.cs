namespace AnimalHierarchy
{
    using System;

    public abstract class Cat : Animal, ISound
    {
        public Cat(string name, int age, Genders gender) : base(name, age, gender)
        {
            ;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }
}