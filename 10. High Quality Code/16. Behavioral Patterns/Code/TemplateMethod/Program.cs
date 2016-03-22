namespace TemplateMethod
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            //Speaker speaker = new SpearkerOne();
            Speaker speaker = new SpeakerTwo();

            speaker.Speak();
        }
    }
}