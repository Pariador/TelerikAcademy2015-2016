namespace CustomTimers
{
    using System;
    using System.Threading;

    public class EventTimer
    {
        public EventTimer(EventHandler execute, int secs)
        {
            this.Execute = execute;
            this.Secs = secs;
        }

        public event EventHandler Execute;
        protected virtual void OnExecute()
        {
            if (this.Execute != null)
            {
                new Thread(() => 
                {
                    Thread.Sleep(this.Secs * 1000);
                    this.Execute(this, EventArgs.Empty);
                    this.Done = true;
                })
                .Start();
            }
        }

        public int Secs { get; set; }
        public bool Done { get; set; }

        public void Start()
        {
            OnExecute();
        }
    }
}