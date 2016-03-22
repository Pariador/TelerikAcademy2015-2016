namespace ExceptionsHomework.Exams
{
    using System;

    public class SimpleMathExam : IExam
    {
        public const int ProblemsCount = 10;

        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }

            private set
            {
                if ((value < 0) || (SimpleMathExam.ProblemsCount < value))
                {
                    throw new ArgumentOutOfRangeException(string.Format("ProblemsSolved must be in range [0 - {0}].", SimpleMathExam.ProblemsCount));
                }

                this.problemsSolved = value;
            }
        }

        public ExamResult Check()
        {
            const int MinGrade = 2;
            const int MaxGrade = 6;

            int gradeIncrement = MaxGrade - MinGrade;
            int gradePerProblem = SimpleMathExam.ProblemsCount / gradeIncrement;
            int grade = (gradePerProblem * this.ProblemsSolved) + MinGrade;

            string comment = null;
            if (grade < 3)
            {
                comment = "Poor.";
            }
            else if (grade < 3.50)
            {
                comment = "Average.";
            }
            else if (grade < 4.50)
            {
                comment = "Good.";
            }
            else if (grade < 5.50) 
            {
                comment = "Very Good.";
            }
            else
            {
                comment = "Excelent.";
            }

            return new ExamResult(MinGrade, MaxGrade, grade, comment);
        }
    }
}