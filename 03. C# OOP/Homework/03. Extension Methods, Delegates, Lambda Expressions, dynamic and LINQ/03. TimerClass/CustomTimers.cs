namespace CustomTimers
{
    using System;

    internal static class CustomTimers
    {
        static void Main()
        {
            QuestionTimer timer = new QuestionTimer("Duck", (str => str == "Duck"), 5);
            timer.Start();
            Console.WriteLine("Thinking...");
            while (timer.Answered == false)
            {
                ;
            }
            Console.WriteLine("{0}", timer.Answer ? "It's a Duck!" : "That ain't no Duck!");

            EventTimer evTimer = new EventTimer(((object obj, EventArgs arg) => Console.WriteLine("I used events, so awesome.")), 5);
            evTimer.Start();
            Console.WriteLine("Thinking...");
            while (evTimer.Done == false)
            {
                ;
            }
        }
    }
}