using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;

namespace Entities {
    /// <summary>
    /// Class that hold items an entity might hold
    /// </summary>
    public class Inventory {
        private Items item;
        private int index;
        InventoryList inventoryList = new InventoryList();

        public Inventory() {
            item = null;
            index = 0;
        }

        /// <summary>
        /// Add Item to inventory
        /// </summary>
        /// <param name="item">Item to send to inventory</param>
        public void AddItem(Items item) {
            inventoryList.Add(item);
        }

        /// <summary>
        /// Remove item from inventory
        /// </summary>
        /// <param name="search">Search by item name to remove item from inventory</param>
        public void RemoveItem(string search) {
            index = inventoryList.GetIndexAtName(search, inventoryList.Size());
            
            if (inventoryList.Remove(index)) {
                Console.WriteLine("removed successfully");
            }else {
                Console.WriteLine("not found at index "+index);
            }
        }

        /// <summary>
        /// View an item by name *DONT USE*
        /// </summary>
        /// <param name="search">gay shit</param>
        public void ViewItem(string search) {
            index = inventoryList.GetIndexAtName(search, inventoryList.Size());
            Console.WriteLine(inventoryList.GetElementByName(index));
        }

        /// <summary>
        /// Gets Item by name
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public Items GetItem(string search) {
            index = inventoryList.GetIndexAtName(search, inventoryList.Size());
            return inventoryList.GetElementByName(index);
        }

        /// <summary>
        /// Get whole inventory in an array format from the inventory linked list
        /// </summary>
        /// <returns>Items array</returns>
        public Items[] GetItemsArray() {
            return inventoryList.GetAllItemsFuckingCunt();
        }

        public RLColor GetColour(int index) { return inventoryList.GetColor(index); }

        /// <summary>
        /// Gets item by index
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>Element</returns>
        public Items GetThing(int index) {
            return inventoryList.GetElementByName(index);
        }

        /// <summary>
        /// Gets inventory size
        /// </summary>
        /// <returns></returns>
        public int GetInventorySize() {
            return inventoryList.Size();
        }

        /// <summary>
        /// Inventory ToString
        /// </summary>
        /// <returns></returns>
        public string GetInventoryNames() {
            return inventoryList.ToString();
        }

        /// <summary>
        /// Get Inventory size???????????
        /// </summary>
        /// <returns></returns>
        public int GetAmountOfHeldItems() {
            return inventoryList.Size();
        }

    }
}
