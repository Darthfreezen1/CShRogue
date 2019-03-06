using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities {
    public class WeaponTest : Weapons {

        public WeaponTest() {
            damage = 20;
            toHit = 10;
            name = "TestWeapon";
            weight = 10;
            rarity = Rarity.Epic;
        }

    }
}
