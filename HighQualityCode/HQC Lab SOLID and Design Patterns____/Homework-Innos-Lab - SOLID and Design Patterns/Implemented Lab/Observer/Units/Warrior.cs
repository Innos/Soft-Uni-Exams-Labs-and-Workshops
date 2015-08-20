namespace Skyrim.Units
{
    using System.Collections.Generic;
    using Skyrim.Items;
    using Skyrim.Observer;

    public class Warrior : Unit, IDragonDeathObserver
    {
        public Warrior(string name, int attackPoints, int healthPoints) 
            : base(name, attackPoints, healthPoints)
        {
            this.Inventory = new List<Weapon>();
        }

        public IList<Weapon> Inventory { get; private set; }

        public void Update(Weapon weapon)
        {
            this.Inventory.Add(weapon);
            this.AttackPoints += weapon.AttackBonus;
            this.HealthPoints += weapon.HealthBonus;
        }
    }
}
