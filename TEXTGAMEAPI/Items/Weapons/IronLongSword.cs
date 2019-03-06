using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities {
    public class IronLongSword : Weapons{

        public IronLongSword() {
            damage = 20;
            toHit = 9;
            name = "Iron Long Sword";
            weight = 8;
        }
    }
}
