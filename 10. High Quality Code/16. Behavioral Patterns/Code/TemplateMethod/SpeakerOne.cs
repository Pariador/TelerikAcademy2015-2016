namespace TemplateMethod
{
    public class SpeakerOne : Speaker
    {
        protected override string GetMessage()
        {
            return "I like cookies.";
        }

        protected override string GetFarewell()
        {
            return "Bye, bye.";
        }
    }
}