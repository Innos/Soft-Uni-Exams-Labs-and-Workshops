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

    public class WolfRaider : Creature
    {
        private const int DefaultWolfRaiderAttack = 8;
        private const int DefaultWolfRaiderDefense = 5;
        private const int DefaultWolfRaiderHealth = 10;
        private const decimal DefaultWolfRaiderDamage = 3.5m;
        private const int DefaultWolfRaiderDoubleDamageRounds = 7;

        public WolfRaider()
            : base(DefaultWolfRaiderAttack, DefaultWolfRaiderDefense, DefaultWolfRaiderHealth, DefaultWolfRaiderDamage)
        {
            this.AddSpecialty(new DoubleDamage(DefaultWolfRaiderDoubleDamageRounds));
        }
    }
}
