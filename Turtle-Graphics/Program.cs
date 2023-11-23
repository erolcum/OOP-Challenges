using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turtle_Graphics
{
    public enum TurtleDirections
    {
        UP = 3, RIGHT = 4, DOWN = 5, LEFT = 6
    }

    public enum PenActions
    {
        UP = 1, DOWN = 2
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.gameLoop();
            Console.ReadLine();
        }
    }
}
