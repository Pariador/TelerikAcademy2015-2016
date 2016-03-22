namespace CustomTimers
{
    using System;
    using System.Threading;

    public delegate bool StringQuestion(string str);

    public class QuestionTimer
    {
        public QuestionTimer(string str, StringQuestion question, int sec)
        {
            this.Str = str;
            this.Question = question;
            this.Secs = sec;
            this.WorkThread = new Thread(this.Work);
        }

        public bool Answered { get; private set; }
        public bool Answer { get; private set; }
        private string Str { get; set; } 
        private StringQuestion Question { get; set; }
        private int Secs { get; set; }
        private Thread WorkThread { get; set; }

        public void Start()
        {
            this.WorkThread.Start();
        }
        private void Work()
        {
            Thread.Sleep(this.Secs * 1000);
            this.Answer = Question(this.Str);
            this.Answered = true;
        }
    }
}