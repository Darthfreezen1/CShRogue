using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;
using RogueSharp;

namespace Entities {
    /// <summary>
    /// Derived from Items meant to hold weapons
    /// </summary>
    public abstract class Weapons : Items {
        Random r = new Random();
        protected int damage, toHit;
        protected bool equipped;

        public Weapons() {
            itemType = ItemType.Weapon;
            color = RLColor.Red;
        }

        /// <summary>
        /// Gets equipped status
        /// </summary>
        /// <returns></returns>
        public bool GetEquipped() {return equipped;}

        /// <summary>
        /// Sets equipped status
        /// </summary>
        /// <param name="value"></param>
        public void SetEquipped(bool value) { equipped = value;}

        /// <summary>
        /// Damage roll????
        /// </summary>
        /// <returns></returns>
        public int DamageRoll() { return r.Next(10, 20); }
        public int GetDamage() { return damage; }
        public int GetToHit() { return toHit; }
        public void UpgradeWeapon() { toHit++; }

    }
}
