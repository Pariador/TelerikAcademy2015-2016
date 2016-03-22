using System;
using System.Linq;

namespace Poker
{
    public static class PokerHandsChecker
    {
        public static bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if ((hand.Cards[i].Face == hand.Cards[j].Face) && (hand.Cards[i].Suit == hand.Cards[j].Suit))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool IsRoyalFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public static bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public static bool IsFourOfAKind(IHand hand)
        {
            if (!PokerHandsChecker.IsValidHand(hand))
            {
                return false;
            }

            CardFace firstFace = hand.Cards[0].Face;
            CardFace secondFace = hand.Cards[1].Face;

            int firstFaceCount = 1;
            int secondFaceCount = 1;

            if (firstFace == secondFace)
            {
                firstFaceCount++;
            }

            for (int i = 2; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Face == firstFace)
                {
                    firstFaceCount++;
                }
                else if (hand.Cards[i].Face == secondFace)
                {
                    secondFaceCount++;
                }
            }

            bool isFourOfAKind = (firstFaceCount == 4) || (secondFaceCount == 4);
            return isFourOfAKind;
        }

        public static bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public static bool IsFlush(IHand hand)
        {
            if (!PokerHandsChecker.IsValidHand(hand))
            {
                return false;
            } 
            
            CardSuit firstCardSuit = hand.Cards[0].Suit;
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Suit != firstCardSuit)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public static bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public static bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public static bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public static bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public static int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
