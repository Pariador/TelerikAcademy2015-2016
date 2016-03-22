namespace HumansProgram
{
    using System;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                value = value.Trim();

                if (String.IsNullOrEmpty(value) || value.Length > 30)
                {
                    throw new NameException();
                }

                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                value = value.Trim();

                if (String.IsNullOrEmpty(value) || value.Length > 30)
                {
                    throw new NameException();
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }
}