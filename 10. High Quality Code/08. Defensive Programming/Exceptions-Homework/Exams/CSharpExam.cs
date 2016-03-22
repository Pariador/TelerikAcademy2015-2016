namespace ExceptionsHomework.Exams
{
    using System;

    public class CSharpExam : IExam
    {
        public const int MaxScore = 100;

        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if ((value < 0) || (CSharpExam.MaxScore < value))
                {
                    throw new ArgumentOutOfRangeException(string.Format("Score has to be in the range [0 - {0}]", CSharpExam.MaxScore));
                }

                this.score = value;
            }
        }

        public ExamResult Check()
        {
            string comment = null;

            if (this.Score < 40)
            {
                comment = "Fail.";
            }
            else if (this.Score < 80)
            {
                comment = "Pass";
            }
            else
            {
                comment = "Pass with excellents.";
            }

            return new ExamResult(0, CSharpExam.MaxScore, this.Score, comment);
        }
    }
}