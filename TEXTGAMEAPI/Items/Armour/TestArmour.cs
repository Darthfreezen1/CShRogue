using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities {

    public class TestArmour : Armours{
        
        public TestArmour() {
            armourType = ArmourType.Body;
            name = "Test Armour";
            value = 10;
            armourClass = 10;
            rarity = Rarity.Common;
        }

    }
}
