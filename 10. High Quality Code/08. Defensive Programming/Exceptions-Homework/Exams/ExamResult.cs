namespace ExceptionsHomework.Exams
{
    using System;

    public class ExamResult
    {
        private int minGrade;

        private int maxGrade;

        private int grade;

        private string comments;

        public ExamResult(int minGrade, int maxGrade, int grade, string comments)
        {
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Grade = grade;
            this.Comments = comments;
        }

        public int MinGrade
        {
            get
            {
                return this.minGrade;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("MinGrade can't be less than zero.");
                }

                this.minGrade = value;
            }
        }

        public int MaxGrade
        {
            get
            {
                return this.maxGrade;
            }

            private set
            {
                if (value <= this.MinGrade)
                {
                    throw new ArgumentException("MaxGrade has to be greater than MinGrade.");
                }

                this.maxGrade = value;
            }
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                if ((value < this.MinGrade) || (this.MaxGrade < value))
                {
                    throw new ArgumentOutOfRangeException("Grade has to be a number between MinGrade and MaxGrade");
                }

                this.grade = value;
            }
        }

        public string Comments
        {
            get
            {
                return this.comments;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Comments can't be null or empty.");
                }

                this.comments = value;
            }
        }
    }
}