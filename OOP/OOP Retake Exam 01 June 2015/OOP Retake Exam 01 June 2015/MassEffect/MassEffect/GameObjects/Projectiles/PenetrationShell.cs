using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Projectiles
{
    using MassEffect.Interfaces;

    class PenetrationShell : Projectile
    {
        public PenetrationShell(int damage) : base (damage)
        {
        }

        public override void Hit(IStarship targetShip)
        {
            targetShip.Health -= this.Damage;
        }
    }
}
