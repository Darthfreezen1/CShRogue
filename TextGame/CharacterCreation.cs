using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using TEXTGAMEAPI.Enemies;
using TEXTGAMEAPI;

namespace TextGame {
    public class CharacterCreation {
        private string name;
        private string className;
        private ClassTypes classTypes;
        private string[] classShit = new string[3];

        public CharacterCreation() {
            bool fuckyou = false;
            string yn = "";
            Console.WriteLine("Enter your name: "); name = Console.ReadLine();
            Console.Clear();

            do {
                Console.WriteLine("Choose your Class:");
                Console.WriteLine("Paladin | Theif | Warrior\n" +
                                  "Mage | Sorcerer | Archer\n" +
                                  "Merchant | Bard | Mercenary\n" +
                                  "Knight | Enchanter");
                Console.Write("Enter your choice: "); className = Console.ReadLine().ToLower();
                if (className != "paladin" || className != "theif" || className != "warrior"
                    || className != "mage" || className != "sorceror" || className != "archer"
                    || className != "merchant" || className != "bard" || className != "mercenary"
                    || className != "knight" || className != "enchanter") {
                    
                }
                classShit = ReturnClassDescription(className);
                Console.Clear();
                Console.WriteLine(classShit[0]);
                Console.WriteLine(classShit[1]);
                Console.WriteLine(classShit[2]);

                Console.WriteLine("Name is " + this.name + ", class is " + this.className);
                Console.WriteLine("Good? (y/n) "); yn = Console.ReadLine();
                yn.ToLower();
                if(yn == "y" || yn == "yes") {
                    fuckyou = true;
                }
            } while (fuckyou == false);
        
        }

        

        private string[] ReturnClassDescription(string classNames) {
            string[] returnValue = new string[3];
            string desc = "";
            string stats = "";
            string startingItems = "";
            if(classNames == "paladin") {
                desc = "big guy who hits things for the vatican";
                stats = "|base hp: 100 | base mana: 100 | damage: 10 | AC: 10      |\n" +
                        "|speed: 10    | fire dmg: 0    | ice dmg: 0 | ltng dmg: 0 |\n" +
                        "|holy dmg: 20 | death dmg: 0   |fire res: 10| ice res: 0  |\n" +
                        "|ltng res: 0  | holy res: 100  | death res: 100           |\n" +
                        "----------------------------------------------------------\n" +
                        "|swordsmanship: 25 | small weapons: 10 | magic skill: 10  |\n" +
                        "|sneak: 5          | steal: 0          |block: 50 | lck: 5|\n" +
                        "-----------------------------------------------------------";
                startingItems = "Weapon: iron broadsword | armour: base paladin set |\n" +
                                "5 healing potions | 5 mana restoration potions |\n" +
                                "cast holy defense | cast smite";
                returnValue[0] = desc;
                returnValue[1] = stats;
                returnValue[2] = startingItems;

            }

            return returnValue;
        }

    }
}
