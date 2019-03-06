using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace TEXTGAMEAPI {
    /// <summary>
    /// Static class for printing out console colours and specific outputs that migh be required
    /// </summary>
    public static class ConsolePrintout {
        /// <summary>
        /// Allows for color change in a line
        /// </summary>
        /// <param name="color">Desired color</param>
        /// <param name="text">Text for display</param>
        public static void PrintInline(ConsoleColor color, string text) {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Allows for colored text display with next line
        /// dunno why???
        /// </summary>
        /// <param name="color">Desired color</param>
        /// <param name="text">Text for display</param>
        public static void PrintNextLine(ConsoleColor color, string text) {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /**
        /// <summary>
        /// Prints out entities inventory
        /// </summary>
        /// <param name="inventory">Entity inventory to display</param>
        public static void PrintInventoryNamesAndData(Inventory inventory) {
            int count = inventory.GetInventorySize();
            Items[] temp = inventory.GetItemsArray();
            for(int i = 0; i < temp.Length; i++) {
                if(temp[i].GetItemType() == ItemType.Armour) {
                    Console.ForegroundColor = temp[i].GetConsoleColor();
                    Console.Write(temp[i].GetName());
                    Console.ResetColor();
                    Console.WriteLine(" " + temp[i].GetItemType() + " " + temp[i].GetValue() + " " + temp[i].GetWeight() + " "+temp[i].GetArmourType());
                }
                else {
                    Console.ForegroundColor = temp[i].GetConsoleColor();
                    Console.Write(temp[i].GetName());
                    Console.ResetColor();
                    Console.WriteLine(" " + temp[i].GetItemType() + " " + temp[i].GetValue() + " " + temp[i].GetWeight() + " ");
                }
            }
        }

        /// <summary>
        /// Prints out inventory from an entitiy as "dropped".
        /// Also asks if you want to put the items into your inventory or discard them.
        /// </summary>
        /// <param name="dropped">Items dropped from an inventory</param>
        /// <param name="enemyName">Name to display</param>
        /// <param name="player">Target to recieve items</param>
        /// <param name="showRarityColor">Option to show the rarity color or the item color</param>
        public static void PrintDroppedItemsFromInventory(Items[] dropped, string enemyName, Entity player, bool showRarityColor) {
            string fug = "";
            int delay = 500;
            if (!showRarityColor) {
                for (int i = 0; i < dropped.Length; i++) {
                    Console.ForegroundColor = dropped[i].GetConsoleColor();
                    Console.WriteLine(dropped[i].GetName());
                    Console.ResetColor();
                }

                Console.WriteLine("Add items to inventory? (y/n)");
                fug = Console.ReadLine();
                if (fug == "y") {
                    for (int j = 0; j < dropped.Length; j++) {
                        player.GetInventory().AddItem(dropped[j]);
                        Console.Write("Added " + dropped[j].GetName() + " to " + player.GetName() + "'s inventory.\n");
                    }
                }
                else {
                    Console.WriteLine("Items not added.");
                    dropped = null;
                }
            }else {
                for (int i = 0; i < dropped.Length; i++) {
                    Console.ForegroundColor = dropped[i].GetRarityColor();
                    Console.WriteLine(dropped[i].GetName());
                    Console.ResetColor();
                }
                
                Console.WriteLine("Add items to inventory? (y/n)");
                fug = Console.ReadLine();
                if (fug == "y") {
                    for (int j = 0; j < dropped.Length; j++) {
                        player.GetInventory().AddItem(dropped[j]);
                        Console.Write("Added " + dropped[j].GetName() + " to " + player.GetName() + "'s inventory.\n");
                    }
                }
                else {
                    Console.WriteLine("Items not added.");
                    dropped = null;
                }
            }
            
        }

        public static void PrintInventoryThievery(Items[] display, Entity target, Entity player, int stealingSkill) {
            Random r = new Random();
            string temp = "";
            double randomChance = Math.Round(r.NextDouble(), 2);
            Console.WriteLine("\n\n"+randomChance);
            if (stealingSkill < 10) {
                Console.WriteLine("Cant even use skill lmoa fag");
            } else if (stealingSkill >= 10 || stealingSkill <= 20) {
                Console.WriteLine("Low skill can only display certain items in a certain rarity");
                for (int i = 0; i < display.Length; i++) {
                    if (display[i].GetRarity() == Rarity.Junk) {
                        Console.WriteLine(display[i].GetName());
                    }
                    else {
                        Console.WriteLine("Nothing to see here...");
                    }
                }
            } else if (stealingSkill >= 21 || stealingSkill <= 40) {
                Console.WriteLine("Med skill can only display certain items in a certain rarity");
                for (int i = 0; i < display.Length; i++) {
                    if (display[i].GetRarity() == Rarity.Junk || display[i].GetRarity() == Rarity.Common) {
                        Console.WriteLine(display[i].GetName());
                    }
                    else {
                        Console.WriteLine("Nothing to see here...");
                    }
                }
            } else if (stealingSkill >= 41 || stealingSkill <= 60) {
                Console.WriteLine("HIgh skill can only display certain items in a certain rarity");
                for (int i = 0; i < display.Length; i++) {
                    if (display[i].GetRarity() == Rarity.Junk || display[i].GetRarity() == Rarity.Common || display[i].GetRarity() == Rarity.Rare) {
                        Console.WriteLine(display[i].GetName());
                    }
                    else {
                        Console.WriteLine("Nothing to see here...");
                    }
                }
            }else if(stealingSkill >=61 || stealingSkill <= 80) {
                Console.WriteLine("Higher skill can only display certain items in a certain rarity");
                for (int i = 0; i < display.Length; i++) {
                    if (display[i].GetRarity() == Rarity.Junk || display[i].GetRarity() == Rarity.Common || display[i].GetRarity() == Rarity.Rare || display[i].GetRarity() == Rarity.Legendary) {
                        Console.WriteLine(display[i].GetName());
                    }
                    else {
                        Console.WriteLine("Nothing to see here...");
                    }
                }
            }else if(stealingSkill >= 81 || stealingSkill <= 100) {
                Console.WriteLine("Highest skill can only display certain items in a certain rarity");
                for (int i = 0; i < display.Length; i++) {
                    if (display[i].GetRarity() == Rarity.Junk || display[i].GetRarity() == Rarity.Common || display[i].GetRarity() == Rarity.Rare || display[i].GetRarity() == Rarity.Legendary || 
                        display[i].GetRarity() == Rarity.Epic) {
                        Console.WriteLine(display[i].GetName());
                    }
                    else {
                        Console.WriteLine("Nothing to see here...");
                    }
                }
            }

        }
    **/


    }
}
