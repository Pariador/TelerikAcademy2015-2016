namespace PersonApp
{
    using System;
    using StudentApp;

    public class Person
    {
        private string name;
        private int? age;

        public Person(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                value = Validator.EmptyNullStr(value, "Name");
                Validator.NameLength(value);

                this.name = value;
            }
        }
        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("A person's age can't be less than zero.");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            object age;
            if (this.Age != null)
            {
                age = this.Age;
            }
            else
            {
                age = "[UnknownAge]";
            }

            return string.Format("Name: {0} Age: {1}", this.Name, age);
        }
    }
}