namespace Skyrim.Units
{
    using System;
    using System.Collections.Generic;

    public delegate void OnDragonDeathEventHandler(Dragon dragon,EventArgs args);

    public class Dragon : Unit
    {
        private int health;

        public Dragon(string name, int attackPoints, int healthPoints)
            : base(name, attackPoints, healthPoints)
        {
            this.Warriors = new List<Warrior>();
        }

        public event OnDragonDeathEventHandler OnDragonDeath;

        public override int HealthPoints
        {
            get
            {
                return this.health;
            }

            set
            {
                if (value <= 0)
                {
                    if (this.OnDragonDeath != null)
                    {
                        this.OnDragonDeath(this, new EventArgs());
                    }
                }
                this.health = value;
            }
        }

        public IList<Warrior> Warriors { get; private set; }

        public void Attach(Warrior warrior)
        {
            this.Warriors.Add(warrior);
        }

        public void Detach(Warrior warrior)
        {
            this.Warriors.Remove(warrior);
        }
    }
}
