using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Path
    {
        public const int PathLength = 40;
        public const int NumOfRunners = 2;
        public string[,] Paths { get; set; }

        public Path() 
        { 
            Paths = new string[PathLength+1, NumOfRunners];
        }

        public void DisplayRacePath() 
        {
            Console.WriteLine();
            for (int i = 0; i < PathLength; i++) 
            {
                string rowNo = i.ToString().PadLeft(2, '0');
                Console.Write(rowNo + "  | ");
                for (int j = 0; j < NumOfRunners; j++) 
                { 
                    if (Paths[i, j] == null) 
                        Console.Write("  | ");
                    else 
                        Console.Write(Paths[i ,j] + " | ");
                }
                Console.WriteLine();
            }
        }

        public void RunnerPosition(Runner runner) 
        {
            Paths[runner.OrigPosition, runner.Lane] = null;
            Paths[runner.CurrentPosition, runner.Lane] = runner.RunnerSymbol;
        }

    }
}
