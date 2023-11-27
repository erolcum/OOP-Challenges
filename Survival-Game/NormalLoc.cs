using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survival_Game
{
    public abstract class NormalLoc : Location
    {
        public NormalLoc(Player player, string name) 
        {
            Player = player;
            Name = name;    
        }
    }
}
