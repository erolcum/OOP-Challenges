using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Turtle : Runner
    {
        public Turtle(int currPosition, int lane, string name) 
        { 
            CurrentPosition = currPosition;
            Lane = lane;
            Name = name;
            RunnerSymbol = "T";
            MoveDescription = Name + " is ready!";
            Runners.Add(this);
        }
        public override void CalculateMove()
        {
            int move = GetRandom();

            if (move >= 1 && move <= 50)
            {
                MakeMove(MoveType.FastPlod);
                MoveDescription = Name + " moved Fast Plod (3)";
            }
            else if (move >= 51 && move <= 70)
            {
                MakeMove(MoveType.Slip);
                MoveDescription = Name + " Slipped (-6)";
            } 
            else
            { 
                MakeMove(MoveType.SlowPlod);
                MoveDescription = Name + " moved Slow Plod (1)";
            } 
        }
    }
}
