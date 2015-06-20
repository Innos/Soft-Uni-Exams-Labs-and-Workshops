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
    using MassEffect.Interfaces;

    class Cruiser : Starship
    {
        private const int cruiserHealth = 100;
        private const int cruiserShields = 100;
        private const int cruiserDamage = 50;
        private const double cruiserFuel = 300;

        public Cruiser(string name, StarSystem location)
            : base(name, cruiserHealth, cruiserShields, cruiserDamage, cruiserFuel, location)
        {

        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}
