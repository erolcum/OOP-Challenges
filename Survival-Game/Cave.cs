using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survival_Game
{
    public class Cave : BattleLoc
    {
        public Cave(Player player) : base(player, "Cave", new Zombie(), "Food")
        {
        }
    }
}
