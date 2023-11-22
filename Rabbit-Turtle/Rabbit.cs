using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Rabbit : Runner
    {
        public Rabbit(int currPosition, int lane, string name)
        {
            CurrentPosition = currPosition;
            Lane = lane;
            Name = name;
            RunnerSymbol = "R";
            MoveDescription = Name + " is ready!";
            Runners.Add(this);
        }
        public override void CalculateMove()
        {
            int move = GetRandom();

            if (move >= 1 && move <= 20)
            {
                MakeMove(MoveType.Sleep);
                MoveDescription = Name + " is Sleeping (0)";
            }
            else if (move >= 21 && move <= 40)
            {
                MakeMove(MoveType.BigHop);
                MoveDescription = Name + " made a Big Hop (9)";
            }
            else if (move >= 41 && move <= 50)
            {
                MakeMove(MoveType.BigSlip);
                MoveDescription = Name + " made a Big Slip (-12)";
            }
            else if (move >= 51 && move <= 80)
            {
                MakeMove(MoveType.SmallHop);
                MoveDescription = Name + " made a Small Hop (1)";
            }
            else
            {
                MakeMove(MoveType.SmallSlip);
                MoveDescription = Name + " made a Small Slip (-2)";
            }
        }
    }
}
