namespace StrategyApp
{
    public class SadEmoji : IEmojiAlgorithm
    {
        public string BuildEmoji()
        {
            return ":(";
        }
    }
}