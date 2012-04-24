using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLibrary.Native;

namespace Cards
{
    public class Poker
    {
        public enum Hands { HighCard, Pair, TwoPair, ThreeKind, Straight, Flush, FullHouse, FourKind, StraightFlush, RoyalFlush }

        public static Hands GetHand(IEnumerable<Card> cards, out int points)
        {
            List<Card> bestCards = new List<Card>();
            Hands hand = Hands.HighCard;

            //flushes (flush, straight, royal)
            foreach (string suit in Card.Suits.AllSuits)
            {
                if (cards.ContainsPropertyCount(c => c.Suit == suit) > 4)
                {
                    if (CheckStraight(cards.Where(c => c.Suit == suit), bestCards))
                    {
                        if (CheckAceHighStraight(cards))
                        {
                            hand = Hands.RoyalFlush;
                        }
                        else
                        {
                            hand = Hands.StraightFlush;
                        }
                    }
                    else
                    {
                        hand = Hands.Flush;

                        bestCards.AddRange(cards.Where(c =>
                            c.Suit == suit).OrderByDescending(c =>
                                c.Points).Take(5));
                    }
                }
            }

            //straight
            if (hand == Hands.HighCard && CheckStraight(cards, bestCards))
            {
                hand = Hands.Straight;
            }

            //pairs (4, 3, fullhouse, 2 pair, pair)
            if (hand == Hands.HighCard)
            {
                var list = cards.OrderByDescending(c => c.Points).ToList();
                for (int i = 0; i < list.Count; )
                {
                    int count = cards.ContainsPropertyCount(c => c.Number == list[i].Number);

                    switch (count)
                    {
                        case 4:
                            hand = Hands.FourKind;
                            bestCards.AddRange(cards.Where(c => c.Number == list[i].Number));
                            break;
                        case 3:
                            hand = hand == Hands.Pair || hand == Hands.TwoPair ? hand = Hands.FullHouse : Hands.ThreeKind;
                            bestCards.AddRange(cards.Where(c => c.Number == list[i].Number));
                            i += 3;
                            break;
                        case 2:
                            hand = hand == Hands.ThreeKind ? Hands.FullHouse : hand == Hands.TwoPair ? hand = Hands.TwoPair : hand == Hands.Pair ? Hands.TwoPair : Hands.Pair;
                            if (bestCards.Count < 4)
                            {
                                bestCards.AddRange(cards.Where(c => c.Number == list[i].Number));
                            }
                            i += 2;
                            break;
                        default:
                            i++;
                            break;
                    }

                    if (hand == Hands.FullHouse || hand == Hands.FourKind)
                    {
                        break;
                    }

                    while (bestCards.Count > 5)
                    {
                        bestCards.RemoveAt(bestCards.Count - 1);
                    }
                }
            }

            int p = 0;

            bestCards.ForEach(c => p += (c.Points * 1000));

            while (bestCards.Count < 5)
            {
                bestCards.Add(cards.OrderByDescending(c => c.Points).First(c => !bestCards.Contains(c)));
            }

            bestCards.ForEach(c => p += c.Points);
            points = p;

            return hand;
        }

        public static Hands GetHand(IEnumerable<Card> cards)
        {
            int points;

            return GetHand(cards, out points);
        }

        private static bool CheckAceHighStraight(IEnumerable<Card> cards)
        {
            return cards.ContainsProperty(c => c.Number == "A")
                                    && cards.ContainsProperty(c => c.Number == "K")
                                    && cards.ContainsProperty(c => c.Number == "Q")
                                    && cards.ContainsProperty(c => c.Number == "J")
                                    && cards.ContainsProperty(c => c.Number == "10");
        }

        private static bool CheckStraight(IEnumerable<Card> cards, List<Card> bestCards)
        {
            bool isStraight = CheckAceHighStraight(cards);

            if (!isStraight)
            {
                int count = 1; //set to 1 to include the first card

                var list = cards.OrderByDescending(c => c.NumberValue).DistinctBy(c => c.NumberValue).ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    if (i + 1 >= list.Count)
                    {
                        break;
                    }

                    if (list[i].NumberValue - list[i + 1].NumberValue == 1)
                    {
                        count++;
                    }
                    else
                    {
                        count = 1;
                    }

                    if (count >= 5)
                    {
                        isStraight = true;

                        i++;

                        while (bestCards.Count < 5)
                        {
                            bestCards.Add(list[i]);
                            i--;
                        }

                        break;
                    }
                }

                if (isStraight && cards.ContainsProperty(c => c.Number == "A"))
                {
                    cards.Where(c => c.Number == "A").ToList().ForEach(c => c.Points = 1);
                }
            }
            else
            {
                bestCards.AddRange(cards.TakeWhile(c =>
                    c.Number == "A" || c.Number == "K" || c.Number == "Q" || c.Number == "J" ||
                    c.Number == "10"));
                bestCards = bestCards.DistinctBy(c => c.Number).ToList();
            }

            return isStraight;
        }
    }
}
