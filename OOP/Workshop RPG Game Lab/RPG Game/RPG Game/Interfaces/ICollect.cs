using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game.Items;

namespace RPG_Game.Interfaces
{
    public interface ICollect
    {
        IEnumerable<Item> Inventory { get; }
        void CollectItem(Item item);
    }
}
