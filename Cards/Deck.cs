using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cards
{
    public class Deck
    {
        public List<Card> Cards
        {
            get;
            set;
        }

        private int Index = 0;

        public Deck()
        {
        }

        public void CreateDefaultDeck(bool includeJokers)
        {
            Cards = new List<Card>();

            foreach (string suit in Card.Suits.AllSuits)
            {
                for (int i = 1; i < 14; i++)
                {
                    Cards.Add(new Card()
                    {
                        NumberValue = i,
                        Suit = suit
                    });
                }
            }
        }

        public Card Draw()
        {
            return Draw(1)[0];
        }

        public Card[] Draw(int count)
        {
            Card[] cards = new Card[count];

            for (int i = 0; i < count; i++)
            {
                cards[i] = Cards[i + Index];
                Index++;
            }

            return cards;
        }

        public void Shuffle()
        {
            Index = 0;
            List<Card> newList = new List<Card>();
            Random random = new Random();

            for (int i = 0; i < Cards.Count; )
            {
                Card card = Cards[random.Next(0, Cards.Count)];
                newList.Add(card);
                Cards.Remove(card);
            }

            Cards = newList;
        }
    }
}
