using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survival_Game
{
    public class Zombie : Obstacle
    {
        public Zombie() : base("Zombie", 3, 4, 10, 3)
        {
        }
    }
}
