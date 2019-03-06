using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;

namespace Entities {
    public class MagicItems : Items{
        double manaRestored;

        public MagicItems() {
            itemType = ItemType.Consumable;
            color = RLColor.Blue;
        }

        public double GetManaRestored() {
            return manaRestored;
        }

    }
}
