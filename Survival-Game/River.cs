using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survival_Game
{
    public class River : BattleLoc
    {
        public River(Player player) : base(player, "River", new Bear(), "Water")
        {
        }
    }
}
