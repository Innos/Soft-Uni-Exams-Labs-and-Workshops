using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MassEffect.GameObjects.Ships
{
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Enhancements;
    using MassEffect.GameObjects.Projectiles;

    class Frigate : Starship
    {
        private const int frigateHealth = 60;
        private const int frigateShields = 50;
        private const int frigateDamage = 30;
        private const double frigateFuel = 220;

        private int projectilesFired;

        public Frigate(string name, StarSystem location)
            : base(name, frigateHealth, frigateShields, frigateDamage, frigateFuel, location)
        {
        }

        public int ProjectilesFired
        {
            get { return this.projectilesFired; }
            private set { this.projectilesFired = value; }
        }

        public override Interfaces.IProjectile ProduceAttack()
        {
            this.ProjectilesFired += 1;
            return new ShieldReaver(this.Damage);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            if (this.Health > 0)
            {
                output.Append(string.Format("\n-Projectiles fired: {0}", this.ProjectilesFired));
            }
            return output.ToString();
        }
    }
}
