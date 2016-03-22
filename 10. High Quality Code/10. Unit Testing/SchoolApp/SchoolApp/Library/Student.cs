namespace SchoolApp.Library
{
    using System;

    public class Student
    {
        public const int MinID = 10000;

        public const int MaxID = 99999;

        private int id;

        private string name;

        public Student(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public int ID
        {
            get
            {
                return this.id;
            }

            set
            {
                if ((value < Student.MinID) || (Student.MaxID < value))
                {
                    string message = string.Format("ID was out of range {0} - {1}", Student.MaxID, Student.MaxID);
                    throw new ArgumentOutOfRangeException(message);
                }

                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be empty or null.");
                }

                this.name = value;
            }
        }
    }
}