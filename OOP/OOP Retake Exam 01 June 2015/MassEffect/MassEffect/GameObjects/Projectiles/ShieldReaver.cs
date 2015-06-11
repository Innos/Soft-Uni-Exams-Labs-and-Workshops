using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Projectiles
{
    using MassEffect.Interfaces;

    class ShieldReaver : Projectile
    {
        public ShieldReaver(int damage) : base(damage)
        {
        }

        public override void Hit(IStarship targetShip)
        {
            targetShip.Health -= this.Damage;
            targetShip.Shields -= (this.Damage * 2);
        }
    }
}
