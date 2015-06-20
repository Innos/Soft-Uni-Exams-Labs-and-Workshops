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

    class Dreadnought : Starship
    {
        private const int dreadnoughtHealth = 200;
        private const int dreadnoughtShields = 300;
        private const int dreadnoughtDamage = 150;
        private const double dreadnoughtFuel = 700;

        public Dreadnought(string name, StarSystem location)
            : base(name, dreadnoughtHealth, dreadnoughtShields, dreadnoughtDamage, dreadnoughtFuel, location)
        {

        }

        public override IProjectile ProduceAttack()
        {
            return new Laser(this.Damage + this.Shields/2);
        }

        public override void RespondToAttack(IProjectile projectile)
        {
            this.Shields += 50;
            base.RespondToAttack(projectile);
            this.Shields -= 50;
        }
    }
}
