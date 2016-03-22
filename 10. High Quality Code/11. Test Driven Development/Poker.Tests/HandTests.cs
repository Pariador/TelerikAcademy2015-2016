namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void TheToStringShouldContainTheToStringOfEachCard()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            string[] cardsAsStrings = new string[cards.Count];
            for (int i = 0; i < cardsAsStrings.Length; i++)
            {
                cardsAsStrings[i] = hand.Cards[i].ToString();
            }

            string handAsString = hand.ToString();

            for (int i = 0; i < cardsAsStrings.Length; i++)
            {
                Assert.IsTrue(handAsString.Contains(cardsAsStrings[i]), "Hand as string doesn't contain the string of each card in the hand.");
            }
        }
    }
}