using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spades
{
    public class Hand
    {
        private List<Card> hand;
        public Hand() 
        { 
            hand = new List<Card>();
        }

        public void addCard(Card card) 
        { 
            hand.Add(card);
        }
        public void removeCard(Card card) 
        { 
            hand.Remove(card);
        }

        public int size() 
        { 
            return hand.Count;
        }

        public Card GetCard(int index) 
        { 
            return (Card)hand[index];
        }

        public bool containsSuit(Suit suit) 
        { 
            foreach (Card card in hand) 
            { 
                if (card.Suit == suit) return true;
            }
            return false;
        }

        public bool containsOnlySpades() 
        {
            foreach (Card card in hand) 
            { 
                if (card.Suit != Suit.SPADES) return false;
            }
            return true;
        }
        public override string ToString() 
        {
            string result = "";
            foreach (Card card in hand) 
            {
                result += card.ToString() + " ";
            }
            return result;
        }

        public int sumOfRanks() 
        {
            int sum = 0;
            for (int i = 0; i < hand.Count; i++) 
            {
                if (hand[i].Rank == 1) sum += 14;
                else sum += hand[i].Rank;
            }
            return sum;
        }

        public void sortCards() 
        {
            Card cardTemp ;
            for (int i = 0;i < hand.Count - 1 ;i++) 
            {
                
                for (int j = i + 1; j < hand.Count; j++)
                {
                    Card card2 = hand[j];
                    Card card1 = hand[i];
                    if (card1.Compare(card1, card2) < 0) 
                    {
                        cardTemp = hand[i];
                        hand[i] = hand[j];
                        hand[j] = cardTemp;
                    }
                }
            }
        }
    }

    
}
