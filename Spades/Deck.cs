using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spades
{
    public class Deck
    {
        private List<Card> deck;
        public Deck() 
        { 
            deck = new List<Card>();
            Suit suit = Suit.SPADES;
            for (int i = 0; i < 4; i++) 
            { 
                switch (i) 
                {
                    case 0:
                        suit = Suit.SPADES;
                        break;
                    case 1:
                        suit = Suit.HEARTS;
                        break;
                    case 2:
                        suit = Suit.CLUBS;
                        break;
                    case 3:
                        suit = Suit.DIAMONDS;
                        break;
                }
                for (int j = 1; j <= 13; j++) 
                { 
                    Card card = new Card(suit, j);
                    deck.Add(card);
                }
            }
        
        }

        public void shuffle() 
        { 
            Random rnd = new Random();
            Card card = null;
            for (int i = 0; i < deck.Count ; i++) 
            { 
                int idx = rnd.Next(i, deck.Count);
                card = deck[idx];
                deck[idx] = deck[i];
                deck[i] = card;
            }
        }

        public void dealAllCards(Player[] players) 
        {
            int idx = 0;
            for (int i = 0; i < deck.Count; i++)
            {
                players[idx].addCard(deck[i]);
                idx = (idx + 1) % 4;
            }
        }
    }
}
