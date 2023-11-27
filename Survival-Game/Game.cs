using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Survival_Game
{
    public class Game
    {
        Player player;
        Location location;

        public void login() 
        {
            Console.Clear();
            Console.WriteLine("Enter your name : aa");
            string playerName = "aa"; // Console.ReadLine();
            player = new Player(playerName);
            player.selectChar();
            start();
        }

        public void start() 
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please select a location you want to go !");
                Console.WriteLine("1- Safehouse  :  Your village , no enemies !");
                Console.WriteLine("2- Cave       :  There will be zombies !");
                Console.WriteLine("3- Forest     :  There will be vampires !");
                Console.WriteLine("4- River      :  There will be bears !");
                Console.WriteLine("5- Toolstore  :  You can buy stuff !");
                Console.Write("Your choice : ");
                int selLoc = int.Parse(Console.ReadLine());
                switch (selLoc)
                {
                    case 1:
                        location = new SafeHouse(player);
                        break;
                    case 2:
                        location = new Cave(player);
                        break;
                    case 3:
                        location = new Forest(player);
                        break;
                    case 4:
                        location = new River(player);
                        break;
                    case 5:
                        location = new ToolStore(player);
                        break;
                    default:
                        location = new SafeHouse(player);
                        break;
                }
                if (location.Name == "SafeHouse") 
                {
                    if (player.Inv.Firewood && player.Inv.Food && player.Inv.Water) 
                    {
                        Console.WriteLine("Congratulations !! You WIN !");
                        break;
                    }
                }
                if (!location.getLocation())
                {
                    Console.WriteLine("Game is OVER !");
                    break;
                }
            }
        }
    }
}
