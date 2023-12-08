using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game game = Game.getInstance();
            game.getBoard().initialize();
            game.getBoard().printBoard();
            Automator automator = Automator.getInstance();
            while (!automator.isOver() && automator.playRandom())
            {
            }
            automator.printScores();
            Console.ReadLine();
        }
    }
}
