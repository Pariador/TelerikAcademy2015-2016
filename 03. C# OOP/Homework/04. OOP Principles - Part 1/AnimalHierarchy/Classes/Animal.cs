namespace AnimalHierarchy
{
    using System;

    public abstract class Animal : ISound
    {
        private string name;
        private int age;

        protected Animal(string name, int age, Genders gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                value = value.Trim();

                if (String.IsNullOrEmpty(value) || value.Length > 30)
                {
                    throw new NameException();
                }

                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0 || value > 30)
                {
                    throw new ArgumentException("Animal age must be between 0 and 30.");
                }

                this.age = value;
            }
        }
        public Genders Gender { get; set; }

        public abstract void MakeSound();
        public override string ToString()
        {
            return this.name;
        }
    }
}