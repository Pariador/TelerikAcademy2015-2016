namespace Poker.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PokerHandsCheckerTests
    {
        public readonly static Hand ValidHighCard = new Hand(new Card[]
        {
            new Card(CardFace.Ace, CardSuit.Diamonds),
            new Card(CardFace.Ten, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Hearts),
            new Card(CardFace.Four, CardSuit.Diamonds),
            new Card(CardFace.Three, CardSuit.Clubs)
        });

        [TestMethod]
        public void Test_IsValidHand()
        {
            Hand invalidHand = new Hand(new Card[]
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            });

            Assert.IsTrue(PokerHandsChecker.IsValidHand(PokerHandsCheckerTests.ValidHighCard), "Failed with valid hand.");
            Assert.IsFalse(PokerHandsChecker.IsValidHand(invalidHand), "Failed with invalid hand.");
        }

        [TestMethod]
        public void Test_IsFourOfAKind()
        {
            Hand fourOfAKind = new Hand(new Card[]
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades)
            });

            Assert.IsTrue(PokerHandsChecker.IsFourOfAKind(fourOfAKind), "Failed with valid four of a kind.");
            Assert.IsFalse(PokerHandsChecker.IsFourOfAKind(PokerHandsCheckerTests.ValidHighCard), "Failed with invalid four of a kind.");
        }

        [TestMethod]
        public void Test_IsFlush()
        {
            Hand flush = new Hand(new Card[]
            {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            });

            Assert.IsTrue(PokerHandsChecker.IsFlush(flush), "Failed with valid flush.");
            Assert.IsFalse(PokerHandsChecker.IsFlush(PokerHandsCheckerTests.ValidHighCard), "Failed with invalid flush.");
        }
    }
}