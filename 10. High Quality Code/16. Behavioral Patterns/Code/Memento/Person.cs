namespace Memento
{
    using System;

    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public void Introduce()
        {
            Console.WriteLine("Hi I'm {0}.", this.Name);
        }

        public PersonMemento Save()
        {
            return new PersonMemento(this.Name, this.Age);
        }

        public void Restore(PersonMemento memento)
        {
            this.Name = memento.Name;
            this.Age = memento.Age;
        }
    }
}