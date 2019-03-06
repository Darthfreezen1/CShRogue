using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities {
    public class IronShortSword : Weapons{
        
        public IronShortSword() {
            damage = 15;
            toHit = 12;
            name = "Iron Short Sword";
            weight = 7;
        }
        
    }
}
