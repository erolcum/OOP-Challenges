using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(7, 7, 10);
            game.initialize();
            game.start();
            Console.ReadLine();
        }
    }
}
