using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;

namespace Entities {
    /// <summary>
    /// Abstract object for all items
    /// </summary>
    public abstract class Items {
        protected string name;
        protected double value, weight, dropChance;
        protected RLColor color;
        protected ItemType itemType;
        protected ArmourType armourType;
        protected Rarity rarity;
        protected RLColor rarityColor;
        protected char glyph;

        /// <summary>
        /// Gets item drop chance
        /// </summary>
        /// <returns></returns>
        public double GetDropChance() {
            return this.dropChance;
        }

        /// <summary>
        /// Sets item drop chance
        /// </summary>
        /// <param name="dropChance"></param>
        /// <exception cref="ArgumentOutOfRangeException">Throws when drop chance is less than or equal to 0
        ///                                               Throws when drop chance is greater than 1.</exception>
        public void SetDropChance(double dropChance) {
            if(dropChance <= 0) {
                throw new System.ArgumentOutOfRangeException("dropChance", "Drop chance cannot be less than or equal to 0");
            }
            if(dropChance > 1) {
                throw new System.ArgumentOutOfRangeException("dropChance", "Drop chance cannot be greater than 1");
            }
            this.dropChance = dropChance;
        }
        
        /// <summary>
        /// Get the rarity color of an item.
        /// THIS WILL SOMETIMES OVERRIDE THE CURRENT ITEMS COLOR IN SOME TEXT OUTPUT
        /// </summary>
        /// <returns></returns>
        public RLColor GetRarityColor() {
            switch (rarity) {
                case Rarity.Junk: rarityColor = RLColor.Gray; break;
                case Rarity.Common: rarityColor = RLColor.White;break;
                case Rarity.Rare: rarityColor = RLColor.Yellow; break;
                case Rarity.Legendary: rarityColor = RLColor.LightCyan; break;
                case Rarity.Epic: rarityColor = RLColor.Magenta; break;
            }
            return this.rarityColor;
        }

        /// <summary>
        /// Sets rarity color of an item.
        /// </summary>
        /// <param name="rarityColor"></param>
        public void SetRarityColor(RLColor rarityColor) {
            this.rarityColor = rarityColor;
        }
        /// <summary>
        /// Gets item rarity
        /// </summary>
        /// <returns></returns>
        public Rarity GetRarity() {
            return rarity;
        }

        /// <summary>
        /// Sets item rarity
        /// </summary>
        /// <param name="rarity"></param>
        public void SetRarity(Rarity rarity) {
            this.rarity = rarity;
        }

        /// <summary>
        /// Gets the item name
        /// </summary>
        /// <returns></returns>
        public string GetName() { return name; }

        /// <summary>
        /// Gets item monetary value
        /// </summary>
        /// <returns></returns>
        public double GetValue() { return value; }

        /// <summary>
        /// Gets item weight
        /// </summary>
        /// <returns></returns>
        public double GetWeight() { return weight; }

        /// <summary>
        /// Gets item console colour
        /// </summary>
        /// <returns></returns>
        public RLColor GetConsoleColor() { return color; }

        /// <summary>
        /// Gets items ItemType
        /// </summary>
        /// <returns>Type of item</returns>
        public ItemType GetItemType() { return itemType; }

        /// <summary>
        /// Gets item Armour Type (FOR ARMOURS ONLY)
        /// </summary>
        /// <returns></returns>
        public ArmourType GetArmourType() { return armourType; }

        /// <summary>
        /// Gets items char value (not implemented)
        /// </summary>
        /// <returns></returns>
        public char GetGlyph() { return glyph; }

    }
}
