using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;

namespace Entities {
    /// <summary>
    /// Abstract class derived from Items meant to hold armours
    /// </summary>
    public abstract class Armours : Items{
        protected double armourClass;
        protected bool equipped;

        /// <summary>
        /// default construcotr
        /// </summary>
        public Armours() {
            itemType = ItemType.Armour;
            color = RLColor.Blue;
            armourType = ArmourType.Body;
        }

        /// <summary>
        /// Gets the AC for the armour
        /// </summary>
        /// <returns></returns>
        public double GetArmourClass() {
            return armourClass;
        }

        /// <summary>
        /// Gets equipped status
        /// </summary>
        /// <returns></returns>
        public bool GetEquipped() {
            return equipped;
        }

        /// <summary>
        /// Sets equipped status
        /// </summary>
        /// <param name="value"></param>
        public void SetEquipped(bool value) {
            equipped = value;
        }

        public void Upgrade() {
            armourClass++;
        }


    }
    
}
