using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public abstract class Runner
    {
        private static Random r = new Random();
        public static List<Runner> Runners = new List<Runner>();
        public string Name { get; set; }
        public string RunnerSymbol { get; set; }
        public string MoveDescription { get; set; }
        public int Lane { get; set; }
        public int OrigPosition { get; set; }
        public int CurrentPosition { get; set; }
        public int GetRandom()
        { 
            return r.Next(1,101); //1..100
        }

        public void MakeMove(int spaces) 
        {
            OrigPosition = CurrentPosition;

            if (CurrentPosition + spaces < 0) 
                CurrentPosition = 0;
            else if (CurrentPosition + spaces > Path.PathLength)
                CurrentPosition = Path.PathLength;
            else
                CurrentPosition = CurrentPosition + spaces;
        }

        public bool isWinner(Runner runner) 
        { 
            if (runner.CurrentPosition == Path.PathLength)
                return true;
            return false;
        }

        public abstract void CalculateMove();
    }
}
