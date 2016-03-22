namespace Students.ObjectLibrary
{
    using System;
    using System.Collections.Generic;

    public enum Subjects
    {
        Bulgarian,
        English,
        Mathematics,
        Physics,
        Biology,
        Chemistry,
        History,
        Geography
    }

    public class Student
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string tel;
        private string email;
        private string facultyNum;
        private Dictionary<Subjects, double?> marks;

        public Student(string firstName, string lastName, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Marks = Student.InitializeMarks();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                value = value.Trim();

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name can't be empty, null or Whitespace.");
                }
                else if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("First name must start with a capital letter.");
                }

                this.firstName = value;
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
                value = value.Trim();

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name can't be empty, null or Whitespace.");
                }
                else if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("First name must start with a capital letter.");
                }

                this.lastName = value;
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }
            set
            {
                this.dateOfBirth = value;
            }
        }
        public int Age
        {
            get
            {
                var now = DateTime.Now;

                int age = now.Year - this.DateOfBirth.Year;
                if (now.Month < this.DateOfBirth.Month || (now.Month == this.DateOfBirth.Month && now.Day < this.DateOfBirth.Day))
                {
                    return age - 1;
                }

                return age;              
            }
        }
        public string Tel
        {
            get
            {
                return this.tel;
            }
            set
            {
                value = value.Trim();

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Telephone number can't be Empty, null or Whitespace.");
                }

                this.tel = value;
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                value = value.Trim();

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email can't be Empty, null or Whitespace.");
                }

                this.email = value;
            }
        }
        public string FacultyNum
        {
            get
            {
                return this.facultyNum;
            }
            set
            {
                value = value.Trim();

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Faclulty number can't be Empty, null or Whitespace.");
                }

                this.facultyNum = value;
            }
        }
        public Group StudentGroup { get; set; }
        public Dictionary<Subjects, double?> Marks
        {
            get
            {
                return this.marks;
            }
            private set
            {
                this.marks = value;
            }
        }

        private static Dictionary<Subjects, double?> InitializeMarks()
        {
            var result = new Dictionary<Subjects, double?>();
            for (int i = 0; i < 8; i++)
            {
                result.Add((Subjects)i, null);
            }
            return result;
        }
    }
}