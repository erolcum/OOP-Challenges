using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spades
{
    public abstract class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public Hand Hand { get; set; }

        public int Tricks { get; set; } // set of 4 cards
        public int Bid { get; set; }


        public Player(string name)
        {
            Name = name;
            Points = 0;
        }

        public abstract Card playCard(bool firstPlayer, bool suitBroken, Suit followedSuit);

        // number of tricks that can be achieved
        public abstract int makeBid();

        // how many tricks player took and his/her bid are compared
        public void calculatePoints() 
        {
            int currentPoints = 0;
            if (Bid == 0)
            {
                if (Tricks == 0) currentPoints = 50;
                else currentPoints = -50;
            }
            else 
            {
                if (Tricks >= Bid)
                {
                    if (Tricks - Bid > 2) currentPoints = -10 * Bid;
                    else currentPoints = Bid * 10 + Tricks - Bid;
                }
                else if (Tricks < Bid)
                {
                    currentPoints = -10 * Bid;
                }
            }
            Console.WriteLine(Name + " has "+ currentPoints+ " points");
            Points += currentPoints;
        }

        public void initializeHand() 
        {
            Hand = new Hand();
            Tricks = 0;
        }

        public void addCard(Card card) 
        { 
            Hand.addCard(card); 
        }

       

        public string displayHand() 
        {
            return Name + " -> " + Hand.ToString();
        }

        protected bool checkCard(Card card, bool firstPlayer, bool suitBroken, Suit followedSuit) 
        {
            if (firstPlayer)
            {
                if (suitBroken) return true;
                else
                {
                    if (card.isTrump())
                    {
                        return false;
                    }
                    else return true;
                }
            }
            else 
            {
                if (card.Suit == followedSuit) return true;
                else 
                {
                    if (Hand.containsSuit(followedSuit))
                    {
                        return false;
                    }
                    else 
                    {
                        if (card.isTrump()) { return true; }
                        else
                            if (!Hand.containsSuit(Suit.SPADES)) return true;
                            else return false;
                        //if (Hand.containsSuit(Suit.SPADES))
                        //{
                        //    if (Hand.containsOnlySpades()) return true;
                        //    else return false;
                        //}
                        //else return true;
                    }
                }
            }
        }
    }
}
