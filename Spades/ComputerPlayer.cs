using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spades
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(string name) : base(name)
        {
        }

        public override int makeBid()
        {
            int sum = Hand.sumOfRanks();
            if (sum < 104)
            {
                Bid = 1;  
            }
            else 
            {
                Bid = (sum - 104) / 4;  
            }
            return Bid;
        }

        public override Card playCard(bool firstPlayer, bool suitBroken, Suit followedSuit)
        {
            int cardIndex;
            Random rnd = new Random(); 
            cardIndex = rnd.Next(Hand.size());
            while (!checkCard(Hand.GetCard(cardIndex), firstPlayer, suitBroken, followedSuit)) 
            {
                cardIndex = rnd.Next(Hand.size());
            }
            return Hand.GetCard(cardIndex);
        }
    }
}
