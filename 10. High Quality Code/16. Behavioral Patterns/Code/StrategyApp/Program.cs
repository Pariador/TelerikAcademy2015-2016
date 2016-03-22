namespace StrategyApp
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            IEmojiAlgorithm happy = new HappyEmoji();
            IEmojiAlgorithm sad = new SadEmoji();
            IEmojiAlgorithm tableFlip = new TableFlip();
            IEmojiAlgorithm tableAntiFlip = new TableAntiFlip();

            Console.WriteLine(happy.BuildEmoji());
            Console.WriteLine(sad.BuildEmoji());
            Console.WriteLine(tableFlip.BuildEmoji());
            Console.WriteLine(tableAntiFlip.BuildEmoji());
        }
    }
}