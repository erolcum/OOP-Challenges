using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survival_Game
{
    public class Player
    {
        private int damage, health, money, rhealth;
        private string name, cName;
        private Inventory inv;
        public Player(string name) 
        { 
            this.Name = name;
            inv = new Inventory();
        }

        
        public Inventory Inv { get => inv; set => inv = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Health { get => health; set => health = value; }
        public int Money { get => money; set => money = value; }
        public string Name { get => name; set => name = value; }
        public string CName { get => cName; set => cName = value; }
        public int RHealth { get => rhealth; set => rhealth = value; }

        public int getTotalDamage() 
        {
            return Damage + Inv.Damage;
        }

        public void selectChar() 
        {
            switch (charMenu()) 
            {
                case 1:
                    cName = "Samurai";
                    Damage = 5;
                    Health = 21;
                    RHealth = Health;
                    Money = 15;
                    break;
                case 2:
                    cName = "Sniper";
                    Damage = 7;
                    Health = 18;
                    RHealth = Health;
                    Money = 20;
                    break;
                case 3:
                    cName = "Knight";
                    Damage = 8;
                    Health = 24;
                    RHealth = Health;
                    Money = 5;
                    break;
                default:
                    charMenu();
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Warrior created successfully!");
            Console.WriteLine($"Name = {cName}, Damage = {Damage}, Health = {Health}, Money = {Money}");

        }

        private int charMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Select a character for warrior ..");
            Console.WriteLine("1- Samurai :  Damage = 5 , Health = 21 , Money = 15");
            Console.WriteLine("2- Sniper  :  Damage = 7 , Health = 18 , Money = 20");
            Console.WriteLine("3- Knight  :  Damage = 8 , Health = 24 , Money =  5");
            Console.Write("Your choice : ");
            int charID = int.Parse(Console.ReadLine());
            return charID;
        }
    }
}
