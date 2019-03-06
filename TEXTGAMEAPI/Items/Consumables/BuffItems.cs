using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;

namespace Entities {
    public class BuffItems : Items{
        public BuffType buffType;
        public double attributeChange;

        public BuffItems() {
            itemType = ItemType.Consumable;
            color = RLColor.Green;
        }

        public BuffType GetBuffType() {
            return buffType;
        }

        public double GetAttributeChange() {
            return attributeChange;
        }


    }

    

}
