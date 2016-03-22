namespace PersonApp
{
    using System;

    public static class PersonTest
    {
        private static readonly Random rand = new Random();

        public static void Start()
        {
            Person[] people = new Person[30];

            people[0] = new Person("John MonkeyFace Doe");
            for (int i = 1; i < people.Length; i++)
            {
                people[i] = new Person(string.Format("Person {0}", i)) { Age = PersonTest.rand.Next(0, 101) };
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}