using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Spades
{
    public enum Suit
    { 
        SPADES,
        HEARTS,
        CLUBS,
        DIAMONDS
    }
    public class Card : IComparable, IComparer<Card>
    {
        public int CompareTo(object obj)
        {
            Card other = obj as Card;
            if (other.Suit != Suit.SPADES && this.Suit == Suit.SPADES)
            {
                return 1;
            }
            else if (other.Suit == Suit.SPADES && this.Suit != Suit.SPADES)
            {
                return -1;
            }
            else if (this.Suit != other.Suit)
            {
                return 1; 
            }
            return compareOnlyRanks(this, other);
        }

        public Suit Suit { get; set; }
        public int Rank { get; set; }
        public Card(Suit suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public bool isTrump() { return Suit == Suit.SPADES; }

        public override string ToString() 
        {
            string result = "";
            switch(Suit) 
            {
                case Suit.SPADES:
                    result = "\u2660";
                    break;
                case Suit.DIAMONDS:
                    result = "\u2666";
                    break;
                case Suit.CLUBS:
                    result = "\u2663";
                    break;
                case Suit.HEARTS:
                    result = "\u2665";
                    break;

            }
            switch (Rank) 
            {
                case 1: result += "A"; break;
                case 10: result += "T"; break;
                case 11: result += "J"; break;
                case 12: result += "Q"; break;
                case 13: result += "K"; break;
                default: result += Rank.ToString(); break;
            }
            return result;
        }
        public int compareOnlyRanks(Card card1, Card card2) 
        {
            if (card1.Rank == 1) return 1;
            else 
            { 
                if (card2.Rank == 1) return -1;
                else return card1.Rank.CompareTo(card2.Rank);
            
            }
        }
        public int Compare(Card x, Card y)
        {
            Card card1 = x as Card;
            Card card2 = y as Card;
            if (card1.Suit == card2.Suit)
            {
                return compareOnlyRanks(card1, card2);
            }else
                return -card1.Suit.CompareTo(card2.Suit);
        }
    } 
}
