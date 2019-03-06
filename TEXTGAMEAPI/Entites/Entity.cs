using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;
using RogueSharp;

namespace Entities {
    /// <summary>
    /// Abstract class for constructing entites such as enemies and player
    /// </summary>
    public abstract class Entity {
        protected int damage, armourClass;
        protected int xp;
        protected double speed, health, mana, fireDamage,
            iceDamage, lightningDamage, holyDamage, deathDamage,
            fireResistance, iceResistance, lightningResistace,
            holyResistance, deathResistance;
        protected RLColor color;
        protected bool player = false;
        protected Weapons weapons;
        protected Armours armours;
        protected Inventory inventory;
        protected string name;
        protected char symbol;




        /// <summary>
        /// Gets entity symbol.
        /// </summary>
        /// <returns>Symbol</returns>
        public char GetSymbol() {
            return this.symbol;
        }

        /// <summary>
        /// Sets entity symbol.
        /// </summary>
        /// <param name="symbol">Symbol</param>
        public void SetSymbol(char symbol) {
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets entity health
        /// </summary>
        /// <returns>health</returns>
        public double GetHealth() { return health; }

        /// <summary>
        /// Sets entity health
        /// </summary>
        /// <param name="setHeatlh">value to set</param>
        public void SetHealth(double setHeatlh) { health = setHeatlh; }

        /// <summary>
        /// Gets entity mana
        /// </summary>
        /// <returns>mana</returns>
        public double GetMana() {
            return mana;
        }

        /// <summary>
        /// Sets entity mana
        /// </summary>
        /// <param name="setMana">Value to set</param>
        public void SetMana(double setMana) {
            mana = setMana;
        }

        /// <summary>
        /// Gets entity speed
        /// </summary>
        /// <returns>speed</returns>
        public double GetSpeed() { return speed; }

        /// <summary>
        /// Sets entity speed
        /// </summary>
        /// <param name="setSpeed">value to set to</param>
        public void SetSpeed(double setSpeed) { speed = setSpeed; }

        /// <summary>
        /// Gets entity colour
        /// </summary>
        /// <returns>console color</returns>
        public RLColor GetColor() { return color; }

        /// <summary>
        /// Sets entity colour
        /// </summary>
        /// <param name="setColor">value of color
        ///                         black, white, red,
        ///                         light red, blue, 
        ///                         light blue, green, 
        ///                         light green, yellow,
        ///                         light yellow, magenta,
        ///                         cyan.</param>
        public void SetColor(RLColor setColor) { color = setColor; }

        /// <summary>
        /// Gets playing character state
        /// </summary>
        /// <returns>bool player state</returns>
        public bool GetPlayer() { return player; }

        /// <summary>
        /// Sets player state
        /// </summary>
        /// <param name="setPlayer">true = player, false = nonplayer</param>
        public void SetPlayer(bool setPlayer) { player = setPlayer; }

        /// <summary>
        /// Gets entity armour class
        /// </summary>
        /// <returns>armour class</returns>
        public int GetArmourClass() { return armourClass; }

        /// <summary>
        /// Sets entity amrour class
        /// </summary>
        /// <param name="setAC">value to set</param>
        public void SetArmoutClass(int setAC) { armourClass = setAC; }

        /// <summary>
        /// Gets entity damage
        /// </summary>
        /// <returns>damage</returns>
        public int GetDamage() { return damage; }

        /// <summary>
        /// Sets entity damage
        /// </summary>
        /// <param name="setDamage">value to set</param>
        public void SetDamage(int setDamage) { damage = setDamage; }

        /// <summary>
        /// Gets entity total xp
        /// </summary>
        /// <returns>xp</returns>
        public int GetXP() { return xp; }

        /// <summary>
        /// Sets entity xp
        /// </summary>
        /// <param name="setXP">value to set</param>
        public void SetXP(int setXP) { xp = setXP; }

        /// <summary>
        /// Increments entity xp
        /// </summary>
        /// <param name="xpToAdd">value to add</param>
        public void AddXp(int xpToAdd) {
            xp += xpToAdd;
        }

        /// <summary>
        /// Constructs an inventory
        /// </summary>
        /// <returns>inventory class</returns>
        public Inventory GetInventory() { return inventory; }

        /// <summary>
        /// Gets an array of items the enemy is holding
        /// </summary>
        /// <returns>items array</returns>
        public Items[] DropInventoryItems() {
            Items[] drop = inventory.GetItemsArray();
            return drop;
        }
        //remove??????
        public Armours GetArmours() { return armours; }
        public Weapons GetWeapons() { return weapons; }

        /// <summary>
        /// Gets entity fire damage
        /// </summary>
        /// <returns>fire damage</returns>
        public double GetFireDamage() { return fireDamage; }

        /// <summary>
        /// Sets entity fire damage
        /// </summary>
        /// <param name="set">value to set</param>
        public void SetFireDamage(double set) {
            fireDamage = set;
        }

        /// <summary>
        /// Increment fire damage
        /// </summary>
        /// <param name="add">value to add</param>
        public void AddFireDamage(double add) {
            fireDamage += add;
        }

        /// <summary>
        /// Gets fire resistance
        /// </summary>
        /// <returns>fire resistance</returns>
        public double GetFireResistance() { return fireResistance; }

        /// <summary>
        /// Sets fire resistance
        /// </summary>
        /// <param name="set"></param>
        public void SetFireResistance(double set) {
            fireResistance = set;
        }

        /// <summary>
        /// Increment fire resistance
        /// </summary>
        /// <param name="add">value to add</param>
        public void AddFireResistance(double add) {
            fireResistance += add;
        }

        /// <summary>
        /// Gets ice damage
        /// </summary>
        /// <returns>ice damage</returns>
        public double GetIceDamage() { return iceDamage; }

        /// <summary>
        /// Sets ice damage
        /// </summary>
        /// <param name="set">value to set</param>
        public void SetIceDamage(double set) {
            iceDamage = set;
        }

        /// <summary>
        /// Increment ice damage
        /// </summary>
        /// <param name="add">value to add</param>
        public void AddIceDamage(double add) {
            iceDamage += add;
        }

        /// <summary>
        /// Gets ice resistance
        /// </summary>
        /// <returns>ice resistance</returns>
        public double GetIceResistance() { return iceResistance; }

        /// <summary>
        /// Sets ice resistance
        /// </summary>
        /// <param name="set">value to set</param>
        public void SetIceResistance(double set) {
            iceResistance = set;
        }

        /// <summary>
        /// Increment fire resistance
        /// </summary>
        /// <param name="add">value to add</param>
        public void AddIceResistance(double add) {
            iceResistance += add;
        }

        /// <summary>
        /// Gets lightning damage
        /// </summary>
        /// <returns>lightning damage</returns>
        public double GetLightningDamage() { return lightningDamage; }

        /// <summary>
        /// Sets lightning damage
        /// </summary>
        /// <param name="set">value to set</param>
        public void SetLightningDamage(double set) {
            lightningDamage = set;
        }

        /// <summary>
        /// Increment fire damage
        /// </summary>
        /// <param name="add">value to add</param>
        public void AddLightningDamage(double add) {
            lightningDamage += add;
        }

        /// <summary>
        /// Gets lightning resistance
        /// </summary>
        /// <returns>lightning resistance</returns>
        public double GetLightningResistance() { return lightningResistace; }

        /// <summary>
        /// Sets lightning resistance
        /// </summary>
        /// <param name="set"></param>
        public void SetLightningReistance(double set) {
            lightningResistace = set;
        }

        /// <summary>
        /// Increment lightning resistance
        /// </summary>
        /// <param name="add">value to add</param>
        public void AddLightningResistance(double add) {
            lightningResistace += add;
        }

        /// <summary>
        /// Gets holy damage
        /// </summary>
        /// <returns>holy damage</returns>
        public double GetHolyDamage() { return holyDamage; }

        /// <summary>
        /// Sets holy damage
        /// </summary>
        /// <param name="set">value to set</param>
        public void SetHolyDamage(double set) {
            holyDamage = set;
        }

        /// <summary>
        /// Increment holy damage
        /// </summary>
        /// <param name="add">value to add</param>
        public void AddHolyDamage(double add) {
            holyDamage += add;
        }

        /// <summary>
        /// Gets holy resistance
        /// </summary>
        /// <returns>holy resitance</returns>
        public double GetHolyResistance() { return holyResistance; }

        /// <summary>
        /// Sets holy resistance
        /// </summary>
        /// <param name="set">value to set</param>
        public void SetHolyResistance(double set) {
            holyResistance = set;
        }

        /// <summary>
        /// Increment holy resistance
        /// </summary>
        /// <param name="add">value to add</param>
        public void AddHolyResistance(double add) {
            holyResistance += add;
        }

        /// <summary>
        /// Gets death damage
        /// </summary>
        /// <returns>death damage</returns>
        public double GetDeathDamage() { return deathDamage; }

        /// <summary>
        /// Sets death damage
        /// </summary>
        /// <param name="set">value to set</param>
        public void SetDeathDamage(double set) {
            deathDamage = set;
        }

        /// <summary>
        /// Increment death damage
        /// </summary>
        /// <param name="add">value to add</param>
        public void AddDeathDamage(double add) {
            deathDamage += add;
        }

        /// <summary>
        /// Gets death resistance
        /// </summary>
        /// <returns></returns>
        public double GetDeathResistance() { return deathResistance; }

        /// <summary>
        /// Sets death resistance
        /// </summary>
        /// <param name="set">value to set</param>
        public void SetDeathResistance(double set) {
            deathResistance = set;
        }

        /// <summary>
        /// Increment death resistance
        /// </summary>
        /// <param name="add">value to add</param>
        public void AddDeathResistance(double add) {
            deathResistance += add;
        }

        /// <summary>
        /// Gets entity name
        /// </summary>
        /// <returns></returns>
        public string GetName() { return name; }

        /// <summary>
        /// Decrements entity health
        /// </summary>
        /// <param name="damageDelt"></param>
        public void DecrementHealth(int damageDelt) {
            this.health -= damageDelt;
        }

        /// <summary>
        /// Decrements entity mana
        /// </summary>
        /// <param name="manaToDecrement"></param>
        public void DecrementMana(int manaToDecrement) {
            this.mana -= manaToDecrement;
        }
    }
}
