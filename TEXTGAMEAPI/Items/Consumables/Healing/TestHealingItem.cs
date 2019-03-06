using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;

namespace Entities {
    public class TestHealingItem : HealingItems{

        public TestHealingItem() {
            healthRestored = 10;
            name = "Test Healing";
            color = RLColor.Green;
        }

    }
}
