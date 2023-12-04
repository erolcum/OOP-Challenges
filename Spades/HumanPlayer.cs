using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spades
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name) : base(name)
        { 
        }

        public override int makeBid()
        { 
            do
            {
                Console.Write("Enter your bid : ");
                Bid = int.Parse(Console.ReadLine());
            } while (Bid < 0 || Bid > 13);
            return Bid;
        }

        public override Card playCard(bool firstPlayer, bool suitBroken, Suit followedSuit)
        {
            int index = 0;
            do
            {
                Console.Write("\nEnter your card index (0-12) : ");
                index = int.Parse(Console.ReadLine());
            } while (index < 0 || index > Hand.size() - 1     
                || !checkCard(Hand.GetCard(index), firstPlayer, suitBroken, followedSuit));
            
            return Hand.GetCard(index);
        }
    }
}
