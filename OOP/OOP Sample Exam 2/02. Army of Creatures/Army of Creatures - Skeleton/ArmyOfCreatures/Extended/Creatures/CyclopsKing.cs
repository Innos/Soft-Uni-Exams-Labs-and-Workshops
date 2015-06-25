using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Extended.Specialties;
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    public class CyclopsKing : Creature
    {
        private const int DefaultCyclopsKingAttack = 17;
        private const int DefaultCyclopsKingDefense = 13;
        private const int DefaultCyclopsKingHealth = 70;
        private const decimal DefaultCyclopsKingDamage = 18m;
        private const int DefaultCyclopsKingDamageWhenSkip = 3;
        private const int DefaultCyclopsKingDoubleAttackRounds = 4;
        private const int DefaultCyclopsKingDoubleDamageRounds = 1;

        public CyclopsKing()
            : base(DefaultCyclopsKingAttack, DefaultCyclopsKingDefense, DefaultCyclopsKingHealth, DefaultCyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(DefaultCyclopsKingDamageWhenSkip));
            this.AddSpecialty(new DoubleAttackWhenAttacking(DefaultCyclopsKingDoubleAttackRounds));
            this.AddSpecialty(new DoubleDamage(DefaultCyclopsKingDoubleDamageRounds));
        }
    }
}
