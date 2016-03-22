# Singleton Pattern
## Description:
A Singleton is an object of wich only one instance can be created in the program. Any code wanting to use the object would have to use the same instance.
This is useful when no more than one instance of an object is required, or in the case that having more instances would cause incorrect behaviour.
A Singleton should be initialized only when it is called the first time, not at the start of the program. A Singleton object differs from a static object in that
it has a state, just like any other instance object. The fact that it is still an instance object is probably the best thing about the Singleton pattern
as all the princibles of OOP and OOD still apply, like polymorphism, inheritance, etc. Thanks to this a Singleton object can easily be replaced if needed.
A notable problem with this pattern is that it's may be tricky to make it thread safe as you need to make sure that no more than one thread
is initializing the object at the same time.
## Code:
```
namespace Singleton
{
    using System;

    public class Singleton
    {
        private static readonly Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());

        private Singleton()
        {
            ;
        }

        public static Singleton Instance
        {
            get
            {
                return instance.Value;
            }
        }
    }
}

```
# Builder Pattern
## Description:
The Builder pattern is one object handling the complicated construction logic for another object. It is useful when the
creation of an object becomes too complecated to be contained within the object constructors. This pattern splits up
the representation of the object from its construction process. The object that handles construction in this pattern is called a Director.
When the object is extended the Director may be reused or extended as well.
## Code:
```
namespace Builder
{
    using System;

    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void ComplicatedWorkWithLotsOfParams(int param, string param2, DateTime date, object param4, dynamic magic)
        {
            //Complicated Work.
            ;
        }
    }

    public class Director
    {
        public Person Create()
        {
            var person = new Person("John");

            person.ComplicatedWorkWithLotsOfParams(5, "wut", (new DateTime()), 72, "O_O");

            return person;
        }
    }
}
```
# Prototype Pattern
## Description:
The Prototypal pattern consists of not creating a new instance by using the "new" keyword but instead copying the object from another "prototype" object.
This can be useful for when initializing a new object is too slow and expensive or when the new object needs to have the same state as another.
Inheritance may be done with prototypes by making a copy, keeping a reference to the original object, extending it and using it as a prototype.
The OOD of an entire project my be done using prototype inheritance just like in JavaScript.
## Code:
```
namespace Prototypes
{
    using System;

    public class Person : ICloneable
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public static class Program
    {
        public static void Main()
        {
            var personProto = new Person("");

            var person = (Person)personProto.Clone();
            person.Name = "John";
        }
    }
}
```