using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    public class Griffin : Creature
    {
        private const int DefaultGriffinAttack = 8;
        private const int DefaultGriffinDefense = 8;
        private const int DefaultGriffinHealth = 25;
        private const decimal DefaultGriffinDamage = 4.5m;
        private const int DefaultGriffinDoubleDefenseRounds = 5;
        private const int DefaultGriffinDefenseWhenSkip = 3;

        public Griffin()
            : base(DefaultGriffinAttack, DefaultGriffinDefense, DefaultGriffinHealth, DefaultGriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(DefaultGriffinDoubleDefenseRounds));
            this.AddSpecialty(new AddDefenseWhenSkip(DefaultGriffinDefenseWhenSkip));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
