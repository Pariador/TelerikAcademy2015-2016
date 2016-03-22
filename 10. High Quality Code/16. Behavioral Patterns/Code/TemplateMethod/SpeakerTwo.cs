namespace TemplateMethod
{
    public class SpeakerTwo : Speaker
    {
        protected override string GetGreating()
        {
            return "Beens!";
        }

        protected override string GetMessage()
        {
            return "Beens, beens, good for you heart, the more you eat the more you fart.";
        }

        protected override string GetFarewell()
        {
            return "Delicious.";
        }
    }
}