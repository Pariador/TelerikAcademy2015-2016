namespace ExceptionsHomework
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Exams;

    public class Student
    {
        private string firstName;

        private string lastName;

        private IExam[] exams;

        public Student(string firstName, string lastName, IExam[] exams)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("FirstName can't be null or empty.");
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("LastName can't be null or empty.");
                }

                this.lastName = value;
            }
        }

        public IExam[] Exams
        {
            get
            {
                return this.exams;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Exams can't be null.");
                }

                this.exams = value;
            }
        }

        public IEnumerable<ExamResult> CheckExams()
        {
            return this.Exams.Select(exm => exm.Check());
        }

        public double CalcAverageExamResultInPercents()
        {
            return this.CheckExams().Select(exm => 
            {
                int range = exm.MaxGrade - exm.MinGrade;
                int gradeInRange = exm.Grade - exm.MinGrade;
                double valuePercent = range / 100;

                return gradeInRange * valuePercent;
            }).Average();
        }
    }
}