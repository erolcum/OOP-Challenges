namespace Survival_Game
{
    public class Inventory
    {
        private bool water, food, firewood;
        private string wName, aName;
        private int damage, armor;

        public Inventory()
        {
            Water = false;
            Food = false;
            Firewood = false;
            Damage = 0;
            Armor = 0;
            WName = string.Empty;
            AName = string.Empty;
        }

        public bool Water { get => water; set => water = value; }
        public bool Food { get => food; set => food = value; }
        public bool Firewood { get => firewood; set => firewood = value; }
        public string WName { get => wName; set => wName = value; }
        public string AName { get => aName; set => aName = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Armor { get => armor; set => armor = value; }
    }
}