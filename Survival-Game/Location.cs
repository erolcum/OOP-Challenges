using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survival_Game
{
    public abstract class Location
    {
        private Player player;
        private string name;

        protected Player Player { get => player; set => player = value; }
        public string Name { get => name; set => name = value; }

        //Location(Player player) 
        //{ 
        //    this.Player = player;
        //}

        public abstract bool getLocation();
    }
}
