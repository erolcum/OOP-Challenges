using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survival_Game
{
    public class Obstacle
    {
        private string name;
        private int damage, award, health, maxNumber;

        public Obstacle(string name, int damage, int award, int health, int maxNumber) 
        { 
            this.Name = name;   
            this.Damage = damage;
            this.Award = award;
            this.Health = health;   
            this.MaxNumber = maxNumber;
        }

        public string Name { get => name; set => name = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Award { get => award; set => award = value; }
        public int Health { get => health; set => health = value; }
        public int MaxNumber { get => maxNumber; set => maxNumber = value; }

        public int count() 
        { 
            Random r = new Random();
            return r.Next(1,maxNumber +1);
        }
    }
}
