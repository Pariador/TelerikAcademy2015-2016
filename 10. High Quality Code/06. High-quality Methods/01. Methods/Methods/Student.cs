namespace Methods
{
    using System;
    using System.Text;

    public class Student
    {
        private string firstName;

        private string lastName;

        private string info;

        public Student(string firstName, string lastName, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                string trimmedValue = value.Trim();
                if (string.IsNullOrEmpty(trimmedValue))
                {
                    throw new ArgumentException("FirstName can't be empty, null or whitespace.");
                }


                this.firstName = trimmedValue;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                string trimmedValue = value.Trim();
                if (string.IsNullOrEmpty(trimmedValue))
                {
                    throw new ArgumentException("FirstName can't be empty, null or whitespace.");
                }


                this.lastName = trimmedValue;
            }
        }

        public DateTime DateOfBirth { get; set; }

        public string Info
        {
            get
            {
                return this.info;
            }

            set
            {
                string trimmedValue = value.Trim();
                if (string.IsNullOrEmpty(trimmedValue))
                {
                    throw new ArgumentException("FirstName can't be empty, null or whitespace.");
                }


                this.info = trimmedValue;
            }
        }

        public bool IsOlderThan(Student other)
        {
            return this.DateOfBirth > other.DateOfBirth;
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine(string.Format("First name: {0}", this.FirstName));
            strBuilder.AppendLine(string.Format("Last name: {0}", this.LastName));
            strBuilder.AppendLine(string.Format("Date of birth: {0}", this.DateOfBirth));
            strBuilder.AppendLine(this.Info);

            return strBuilder.ToString();
        }
    }
}