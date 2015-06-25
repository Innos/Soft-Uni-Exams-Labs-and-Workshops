using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Extended
{
    using ArmyOfCreatures.Extended.Creatures;
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Creatures;

    public class ExtendedCreatureFactory : CreaturesFactory
    {
        public override Creature CreateCreature(string name)
        {
            switch (name)
            {
                case "AncientBehemoth":
                    return new AncientBehemoth();
                case "Goblin":
                    return new Goblin();
                case "WolfRaider":
                    return new WolfRaider();
                case "Griffin":
                    return new Griffin();
                case "CyclopsKing":
                    return new CyclopsKing();
                default:
                    return base.CreateCreature(name);
            }  
        }
    }
}
