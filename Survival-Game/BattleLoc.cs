using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survival_Game
{
    public abstract class BattleLoc : Location
    {
        protected Obstacle obstacle;
        protected string award;
        public BattleLoc(Player player, string name, Obstacle obstacle, string award)
        {
            Player = player;
            Name = name;
            this.obstacle = obstacle;
            this.award = award;
        }

        public override bool getLocation()
        {
            int obsCount = obstacle.count();
            Console.WriteLine();
            Console.WriteLine("You are in the " + this.Name + " !!");
            Console.WriteLine("Be careful ! There are " + obsCount + " " + obstacle.Name + "<s> in the " + this.Name);
            Console.Write("<C>ombat or <F>lee ? : ");
            string selCase = Console.ReadLine();
            if (selCase.ToUpper() == "C")
            {
                if (combat(obsCount))
                {
                    Console.WriteLine("\nYou killed all the enemies in the " + this.Name);
                    if (this.award == "Food" && Player.Inv.Food == false) 
                    {
                        Player.Inv.Food = true;
                        Console.WriteLine("You win " + this.award + " item :)");
                    } else
                         if (this.award == "Water" && Player.Inv.Water == false)
                    {
                        Player.Inv.Water = true;
                        Console.WriteLine("You win " + this.award + " item :)");
                    }else
                         if (this.award == "Firewood" && Player.Inv.Firewood == false)
                    {
                        Player.Inv.Firewood = true;
                        Console.WriteLine("You win " + this.award + " item :)");
                    }
                    return true;
                }
                if (Player.Health <= 0)
                {
                    Console.WriteLine("\nYou loosed, you are a dead in the " + this.Name);
                    return false;
                }
                
            }
            return true;
        }

        public bool combat(int obsCount) 
        {
            for (int i = 0; i < obsCount; i++) 
            {
                playerStats();
                enemystats();
                int defObsHealth = obstacle.Health;
                while (Player.Health > 0 && obstacle.Health > 0)
                {
                    Console.Write("<H>it or <F>lee ? : ");
                    string selCase = Console.ReadLine();
                    if (selCase.ToUpper() == "H")
                    {
                        Console.WriteLine("\nYou hit the enemy !");
                        obstacle.Health -= Player.getTotalDamage();
                        Console.WriteLine("Player Health : " + Player.Health);
                        Console.WriteLine(obstacle.Name + " Health : " + obstacle.Health);
                        Console.WriteLine();
                        if (obstacle.Health > 0) 
                        {
                            Console.WriteLine("Enemy hits you !");
                            Player.Health -= obstacle.Damage - Player.Inv.Armor;
                            Console.WriteLine("Player Health : " + Player.Health);
                            Console.WriteLine(obstacle.Name + " Health : " + obstacle.Health);
                            Console.WriteLine();
                        }
                        
                    }
                    else return false;
                } if (obstacle.Health <= 0 && Player.Health > 0)
                {
                    Console.WriteLine("You killed the enemy !");
                    Player.Money += obstacle.Award;
                    Console.WriteLine("Your current money : " + Player.Money);
                    obstacle.Health = defObsHealth;
                }
                else
                    return false;
            }
            return true;
        }

        private void enemystats()
        {
            Console.WriteLine("\n" + obstacle.Name + " Stats\n------------");
            Console.WriteLine("Health : " + obstacle.Health);
            Console.WriteLine("Damage : " + obstacle.Damage);
            Console.WriteLine("Award  : " + obstacle.Award);
        }

        private void playerStats()
        {
            Console.WriteLine("\nPlayer Stats\n------------");
            Console.WriteLine("Health : " + Player.Health);
            Console.WriteLine("Damage : " + Player.getTotalDamage());
            Console.WriteLine("Money  : " + Player.Money);
            if (Player.Inv.Damage > 0) 
            {
                Console.WriteLine("Weapon  : " + Player.Inv.WName);
            }
            if (Player.Inv.Armor > 0)
            {
                Console.WriteLine("Armor   : " + Player.Inv.AName);
            }
        }
    }
}
