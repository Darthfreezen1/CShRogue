using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using RLNET;

namespace TEXTGAMEAPI.Enemies {
    public class EnemyTest : Entity {

        public EnemyTest() {
            lightningDamage = 10;
            lightningResistace = 10;
            health = 10;
            damage = 10;
            mana = 10;
            armourClass = 10;
            speed = 10;
            xp = 10;
            color = RLColor.Cyan;
            inventory = new Inventory();
            name = "EnemyName";
            weapons = new WeaponTest();
            armours = new TestArmour();
            inventory.AddItem(new WeaponTest());
            inventory.AddItem(new TestArmour());
            inventory.AddItem(new TestHealingItem());
        }
    }
}
