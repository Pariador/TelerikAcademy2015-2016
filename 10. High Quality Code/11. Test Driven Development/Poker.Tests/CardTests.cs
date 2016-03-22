namespace Poker.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void ToStringShouldContainCardSuitAndFace()
        {
            CardFace face = CardFace.Nine;
            CardSuit suit = CardSuit.Hearts;
            Card card = new Card(face, suit);
            string cardString = card.ToString();

            Assert.IsTrue(cardString.Contains(face.ToString()), "The string returned by ToString doesn't contain the card face.");
            Assert.IsTrue(cardString.Contains(suit.ToString()), "The string returned by ToString doesn't contain the card suit.");
        }
    }
}