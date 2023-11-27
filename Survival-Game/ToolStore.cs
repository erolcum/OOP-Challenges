using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survival_Game
{
    public class ToolStore : NormalLoc
    {
        public ToolStore(Player player) : base(player, "ToolStore")
        {
        }

        public override bool getLocation()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to ToolStore !");
            Console.WriteLine("Your money : " + Player.Money);
            Console.WriteLine("What do you want to purchase ?");
            Console.WriteLine("1- Weapon");
            Console.WriteLine("2- Armor");
            Console.WriteLine("3- Cancel");
            Console.Write("Your choice : ");
            int selTool = int.Parse(Console.ReadLine());
            int selItemID;
            switch (selTool)
            {
                case 1:
                    selItemID = weaponMenu();
                    buyWeapon(selItemID);
                    break;
                case 2:
                    selItemID = armorMenu();
                    buyArmor(selItemID);
                    break;
                case 3:
                    
                    break;
                default:
                    
                    break;
            }
            return true;
        }

        private void buyArmor(int selItemID)
        {
            int armor = 0;
            int price = 0;
            string aName = string.Empty;

            switch (selItemID)
            {
                case 1:
                    armor = 1;
                    price = 15; 
                    aName = "Light";
                    break;
                case 2:
                    armor = 3;
                    price = 25;
                    aName = "Medium";
                    break;
                case 3:
                    armor = 5;
                    price = 40;
                    aName = "Heavy";
                    break;
                case 4:
                    break;
                default:
                    break;
            }
            if (price > 0)
            {
                if (Player.Money >= price)
                {
                    Player.Inv.Armor = armor;
                    Player.Inv.AName = aName;
                    Player.Money -= price;
                    Console.WriteLine("Your money left : " + Player.Money);
                    Console.WriteLine("You have successfully bought the item " + Player.Inv.AName + " armor");
                    Console.WriteLine("Enemy damage will be blocked by : " + Player.Inv.Armor);
                    
                }
                else
                    Console.WriteLine("You have not enough money !");
            }
        }

        private int armorMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1- Light   <Price: 15 - Damage: -1>");
            Console.WriteLine("2- Medium  <Price: 25 - Damage: -3>");
            Console.WriteLine("3- Heavy   <Price: 40 - Damage: -5>");
            Console.WriteLine("4- Cancel");
            Console.Write("Your choice : ");
            int selArmorID = int.Parse(Console.ReadLine());
            return selArmorID;
        }

        private void buyWeapon(int selItemID)
        {
            int damage = 0;
            int price = 0;
            string wName = string.Empty; 
       
                switch (selItemID) 
                {
                    case 1:
                        damage = 2;
                        price = 25; 
                        wName = "Pistol";
                        break;
                    case 2:
                        damage = 3;
                        price = 35;
                        wName = "Sword";
                        break;
                    case 3:
                        damage = 7;
                        price = 45;
                        wName = "Pistol";
                        break;
                    case 4:
                        break;
                    default : 
                        break;
                }
            if (price > 0) 
            {
                if (Player.Money >= price)
                {
                    Player.Inv.Damage = damage;
                    Player.Inv.WName = wName;
                    Player.Money -= price;
                    Console.WriteLine("Your money left : " + Player.Money);
                    Console.WriteLine("You have successfully bought the item " + Player.Inv.WName);
                    Console.WriteLine("Old damage : " + Player.Damage);
                    Console.WriteLine("New damage : " + Player.getTotalDamage());
                }
                else
                    Console.WriteLine("You have not enough money !");
            }
        }

        private int weaponMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1- Pistol <Price: 25 - Damage: +2>");
            Console.WriteLine("2- Sword  <Price: 35 - Damage: +3>");
            Console.WriteLine("3- Pistol <Price: 45 - Damage: +7>");
            Console.WriteLine("4- Cancel");
            Console.Write("Your choice : ");
            int selWeaponID = int.Parse(Console.ReadLine());
            return selWeaponID;
        }
    }
}
