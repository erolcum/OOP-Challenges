using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survival_Game
{
    public class Forest : BattleLoc
    {
        public Forest(Player player) : base(player, "Forest", new Vampire(), "Firewood")
        {
        }
    }
}
