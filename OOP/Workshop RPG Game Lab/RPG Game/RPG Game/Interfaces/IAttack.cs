using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game.Characters;

namespace RPG_Game.Interfaces
{
    public interface IAttack
    {
        int Damage { get; }
        void Attack(Character enemy);
    }
}
