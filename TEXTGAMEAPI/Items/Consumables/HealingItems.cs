using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;

namespace Entities {
    public class HealingItems : Items {
        protected double healthRestored;
        
        public HealingItems() {
            itemType = ItemType.Consumable;
            color = RLColor.Red;
        }

        public double GetHealthRestored() {
            return healthRestored;
        }
        

    }
}
