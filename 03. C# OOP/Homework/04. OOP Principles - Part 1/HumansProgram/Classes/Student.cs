namespace HumansProgram
{
    using System;

    public class Student : Human
    {
        private double grade;

        public Student(string firstName, string lastName) : base(firstName, lastName)
        {
            ;
        }
        public Student(string firstName, string lastName, double grade) : this(firstName, lastName)
        {
            this.Grade = grade;
        }

        public double Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (value < 2.00 || value > 6.00)
                {
                    throw new GradeException();
                }

                this.grade = value;
            }
        }
    }
}