using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;
using RogueSharp;

namespace Entities {
    /// <summary>
    /// Represents the player.
    /// </summary>
    public class Player : Entity{
        protected ClassTypes classType;
        protected int swordsmanship;
        protected int smallWeaponsSkills;
        protected int sneakingSkill;
        protected int stealingSkill;
        protected int blockingSkill;
        protected int magicSkill;
        protected double luck;

        public int Awareness {
            get; set;
        }

        public int X {
            get; set;
        }
        public int Y {
            get;set;
        }

        public char Symbol {
            get; set;
        }

        /// <summary>
        /// Constructs a new instance of a player.
        /// </summary>
        /// <param name="damage">Base Damage</param>
        /// <param name="ac">Base AC</param>
        /// <param name="xp">Experience Points</param>
        /// <param name="speed">Base Speed</param>
        /// <param name="health">Health</param>
        /// <param name="mana">Mana</param>
        /// <param name="firedmg">Fire Damage</param>
        /// <param name="icedmg">Ice Damage</param>
        /// <param name="ltngdmg">Lightning Damage</param>
        /// <param name="holydmg">Holy Damage</param>
        /// <param name="deathdmg">Death Damage</param>
        /// <param name="fireres">Fire Resistance</param>
        /// <param name="iceres">Ice Resistance</param>
        /// <param name="litres">Lightning Resistance</param>
        /// <param name="holyres">Holy Resistance</param>
        /// <param name="deathres">Death Resistance</param>
        /// <param name="swrdsmanship">Swordsmanship</param>
        /// <param name="magicskill">Magic Skill</param>
        /// <param name="small">Small Weapons Skill</param>
        /// <param name="sneak">Sneak Skill</param>
        /// <param name="steal">Steal Skill</param>
        /// <param name="block">Block Skill</param>
        /// <param name="lck">Luck</param>
        /// <param name="classtype">Class Type</param>
        /// <param name="color">Console Color</param>
        /// <param name="baseWeapon">Starting Weapon</param>
        /// <param name="baseArmour">Starting Armour</param>
        /// <param name="name">Player Name</param>
        public Player(int damage, int ac, int xp, int speed, int health, int mana, int firedmg, int icedmg, int ltngdmg, int holydmg, int deathdmg, 
                        int fireres, int iceres, int litres, int holyres, int deathres, int swrdsmanship, int magicskill, int small, int sneak, int steal, int block, int lck, 
                         ClassTypes classtype,  RLColor color, Weapons baseWeapon, Armours baseArmour, string name) {
            this.damage = damage;
            this.armourClass = ac;
            this.xp = xp;
            this.speed = speed;
            this.health = health;
            this.mana = mana;
            this.fireDamage = firedmg;
            this.iceDamage = icedmg;
            this.lightningDamage = ltngdmg;
            this.holyDamage = holydmg;
            this.deathDamage = deathdmg;
            this.fireResistance = fireres;
            this.iceResistance = iceres;
            this.lightningResistace = litres;
            this.holyResistance = holyres;
            this.deathResistance = deathres;

            this.swordsmanship = swrdsmanship;
            this.smallWeaponsSkills = small;
            this.magicSkill = magicskill;
            this.sneakingSkill = sneak;
            this.stealingSkill = steal;
            this.blockingSkill = block;
            this.luck = lck;

            this.classType = classtype;

            this.color = color;
            this.player = true;
            this.weapons = baseWeapon;
            this.armours = baseArmour;
            inventory = new Inventory();
            inventory.AddItem(weapons);
            inventory.AddItem(armours);
            this.name = name;
            this.symbol = '@';
            Symbol = '@';
            Awareness = 15;
        }

        //used for testing!!!
        public Player() {
            color = RLColor.White;
            Awareness = 15;
            Symbol = '@';
            X = 10;
            Y = 10;
        }

        /// <summary>
        /// Sets Player classification
        /// </summary>
        /// <param name="name">Class Name</param>
        public void SetPlayerClass(string name) {
            switch (name) {
                case "Paladin": classType = ClassTypes.Paladin; break;
                case "Theif": classType = ClassTypes.Thief; break;
                case "Warrior": classType = ClassTypes.Warrior; break;
                case "Mage": classType = ClassTypes.Mage; break;
                case "Sorceror": classType = ClassTypes.Sorceror; break;
                case "Archer": classType = ClassTypes.Archer; break;
                case "Merchant": classType = ClassTypes.Merchant; break;
                case "Knight": classType = ClassTypes.Knight; break;
                case "Enchanter": classType = ClassTypes.Enchanter; break;
                default: Console.WriteLine("not in list"); break;
            }
        }

        /// <summary>
        /// Gets Player Class
        /// </summary>
        /// <returns>Class</returns>
        public ClassTypes GetClassType() {
            return classType;
        }

        public void SetSwordsmanship(int sword) {
            this.swordsmanship = sword;
        }

        public int GetSwordsmanship() {
            return swordsmanship;
        }

        public void SetSmallWeapons(int smallWeapons) {
            this.smallWeaponsSkills = smallWeapons;
        }

        public int GetSmallWeapons() { return this.smallWeaponsSkills; }
        
        public void SetSneakingSkill(int sneak) {
            this.sneakingSkill = sneak;
        }

        public int GetSneakingSkill() { return sneakingSkill; }

        public void SetStealingSkill(int stealing) {
            this.stealingSkill = stealing;
        }

        public int GetStealingSkill() { return stealingSkill; }

        public void SetBlockingSkill(int block) { this.blockingSkill = block; }

        public int GetBlockingSkill() { return blockingSkill; }

        /// <summary>
        /// Sets luck percentage
        /// </summary>
        /// <param name="luck">luck</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Throws when luck is less than 0
        ///                                                      Throws when luck is greater than 1</exception>
        public void SetLuck(double luck) {
            if(luck < 0) {
                throw new System.ArgumentOutOfRangeException("luck", "Cannot be less than 0");
            }
            if(luck > 1) {
                throw new System.ArgumentOutOfRangeException("luck", "Cannot be greater than 1");
            }
            this.luck = luck;
        }

        public double GetLuck() { return luck; }

        public void Draw(RLConsole console, IMap map) {
            //dont draw actors in cells thta havent been explored
            if(!map.GetCell(X, Y).IsExplored) {
                return;
            }

            //only draw the actor with the color and symbil when they are in fov
            if(map.IsInFov(X, Y)) {
                console.Set(X, Y, GetColor(), RLColor.Gray, Symbol);
            }else {
                //when not in fov just draw normal floor
                console.Set(X, Y, RLColor.Green, RLColor.Gray, '.');
            }
        }

        public string[] SavePlayer() {
            string[] playerShit = { this.GetName() , this.GetSymbol().ToString(), this.GetInventory().GetInventoryNames()};
            return playerShit;
        }

    }

}
