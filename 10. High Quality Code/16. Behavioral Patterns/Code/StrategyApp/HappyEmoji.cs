namespace StrategyApp
{
    public class HappyEmoji : IEmojiAlgorithm
    {
        public string BuildEmoji()
        {
            return ":)";
        }
    }
}