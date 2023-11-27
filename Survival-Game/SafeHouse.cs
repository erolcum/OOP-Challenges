using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survival_Game
{
    public class SafeHouse : NormalLoc
    {
        public SafeHouse(Player player) : base(player, "SafeHouse")
        {
        }

        public override bool getLocation()
        {
            Player.Health = Player.RHealth;
            Console.WriteLine("You are healed !");
            Console.WriteLine("You are in the SafeHouse now !");
            
            return true;
        }
    }
}
