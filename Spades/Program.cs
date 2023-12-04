using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spades
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.playHand();
            Console.ReadLine();
        }
    }
}
