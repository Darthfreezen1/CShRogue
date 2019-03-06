using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities {
    public class IronDagger : Weapons {

        public IronDagger() {
            damage = 10;
            toHit = 10;
            name = "Iron Dagger";
            weight = 5;
            value = 10;
            rarity = Rarity.Junk;
        }

    }
}
