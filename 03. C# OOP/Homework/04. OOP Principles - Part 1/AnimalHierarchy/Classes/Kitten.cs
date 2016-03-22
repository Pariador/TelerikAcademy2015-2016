namespace AnimalHierarchy
{
    using System;

    public class Kitten : Cat, ISound
    {
        public Kitten(string name, int age) : base(name, age, Genders.Female)
        {
            ;
        }
    }
}