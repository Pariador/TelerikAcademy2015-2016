namespace AnimalHierarchy
{
    using System;

    public class Tomcat : Cat, ISound
    {
        public Tomcat(string name, int age) : base(name, age, Genders.Male)
        {
            ;
        }
    }
}