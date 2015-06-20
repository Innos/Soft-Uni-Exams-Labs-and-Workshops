using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Ships
{
    using MassEffect.Interfaces;
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Enhancements;
    using MassEffect.Exceptions;

    abstract class Starship : IStarship
    {
        private string name;
        private int health;
        private int shields;
        private int damage;
        private double fuel;
        private StarSystem location;
        private IList<Enhancement> enhancements;

        protected Starship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }
        public int Shields
        {
            get { return this.shields; }
            set { this.shields = value; }
        }
        public int Damage
        {
            get {return this.damage;}
            set {this.damage = value;}
        }
        public double Fuel
        {
            get { return this.fuel; }
            set { this.fuel = value; }
        }
        public StarSystem Location
        {
            get { return this.location; }
            set { this.location = value; }
        }
        public IEnumerable<Enhancement> Enhancements
        {
            get { return this.enhancements; }
        }

        public abstract IProjectile ProduceAttack();
        public virtual void RespondToAttack(IProjectile projectile)
        {
            projectile.Hit(this);
        }
        public void AddEnhancement(Enhancement enhancement)
        {
            if(enhancement == null)
            {
                throw new ArgumentNullException("Enhancement cannot be null");
            }
            this.enhancements.Add(enhancement);
            this.Shields = this.Shields + enhancement.ShieldBonus;
            this.Damage = this.Damage + enhancement.DamageBonus;
            this.Fuel = this.Fuel + enhancement.FuelBonus;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));
            if(this.Health <= 0)
            {
                output.Append("(Destroyed)");
            }
            else
            {
                output.AppendLine(string.Format("-Location: {0}", this.Location.Name));
                output.AppendLine(string.Format("-Health: {0}", this.Health));
                output.AppendLine(string.Format("-Shields: {0}", this.Shields));
                output.AppendLine(string.Format("-Damage: {0}", this.Damage));
                output.AppendLine(string.Format("-Fuel: {0:F1}", this.Fuel));
                output.Append(string.Format("-Enhancements: {0}",
                    (this.Enhancements.Count() > 0 ? string.Join(", ", this.Enhancements) : "N/A")));       
            }
            return output.ToString();
        }
    }
}
