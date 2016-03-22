namespace TemplateMethod
{
    using System;

    public abstract class Speaker
    {
        protected virtual string GetGreating()
        {
            return "Hi.";
        }

        protected abstract string GetMessage();

        protected virtual string GetFarewell()
        {
            return "Goodbye";
        }

        public void Speak()
        {
            Console.WriteLine(this.GetGreating());
            Console.WriteLine(this.GetMessage());
            Console.WriteLine(this.GetFarewell());
        }
    }
}