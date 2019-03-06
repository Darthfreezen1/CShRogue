using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;

namespace Entities {
    /// <summary>
    /// God i dont even wanna comment this spaghetti
    /// </summary>
    public class InventoryList {
        private Node head;
        private int listCount;
        private string name;
        private Items items;
        public static int shit = 0;

        public InventoryList() {
            head = new Node(items);
            listCount = 0;
        }

        /// <summary>
        /// Adds to the list.
        /// </summary>
        /// <param name="item">Item</param>
        public void Add(Items item) {
            Node temp = new Node(item);
            Node current = head;
            while(current.GetNext() != null) {
                current = current.GetNext();
            }
            current.SetNext(temp);
            listCount++;
        }

        /// <summary>
        /// Adds item to the list by specific index.
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="index">Index</param>
        public void Add(Items item, int index) {
            Node temp = new Node(item);
            Node current = head;
            for(int i = 1; i < index && current.GetNext() != null; i++) {
                current.GetNext();
            }
            temp.SetNext(current.GetNext());
            current.SetNext(temp);
            listCount++;
        }

        /// <summary>
        /// Returns item at index.
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public Items Get(int index) {
            if(index <= 0) {
                return null;
            }

            Node current = head.GetNext();
            for(int i = 1; i < index; i++) {
                if(current.GetNext() == null) {
                    return null;
                }
                current = current.GetNext();
            }
            return current.GetItems();
        }

        /// <summary>
        /// Gets index by name of the item. (unused)
        /// </summary>
        /// <param name="name">Search</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public int GetIndexAtName(string name, int index) {
            int thing = 0;
            if(index <= 0) {
                return 0;
            }
            Node current = head.GetNext();
            string temp; 
            for(int i = 0; i < index; i++) {
                temp = current.GetName();
                if (temp == name) {
                    //Console.WriteLine("Found");
                    thing = i;
                    break;
                }else {

                }
                current = current.GetNext();
            }
            return thing;
        }

        /// <summary>
        /// Removes node at index.
        /// </summary>
        /// <param name="index">index</param>
        /// <returns></returns>
        public bool Remove(int index) {
            if(index < 1 || index > Size()) {
                return false;
            }

            Node current = head;

            if(index == 0) {
                current.SetNext(current.GetNext().GetNext());
                listCount--;
                return true;
            }
            for(int i = 1; i < index; i++) {
                if(current.GetNext() == null) {
                    return false;
                }
                current = current.GetNext();
            }
            current.SetNext(current.GetNext().GetNext());
            listCount--;
            return true;
        }

        /// <summary>
        /// Returns the length of the list.
        /// </summary>
        /// <returns>List length</returns>
        public int Size() {
            return listCount;
        }

        /// <summary>
        /// Gets Item by item name.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Items GetElementByName(int index) {
            Node current = head.GetNext();
            for(int i = 1; i < index; i++) {
                if(current.GetNext() == null) {
                    return null;
                }
                current = current.GetNext();
                break;
            }
            return current.GetItems();
        }

        /// <summary>
        /// Returns string representation of the list.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            Node current = head.GetNext();
            string output = "Inventory:\n";
            while(current != null) {
                output += $"[{current.GetName()}]";
                current = current.GetNext();
            }
            return output;
        }

        /// <summary>
        /// Returns an array of all items.
        /// </summary>
        /// <returns>Items Array</returns>
        public Items[] GetAllItemsFuckingCunt() {
            Items[] tempItemsArray = new Items[Size()];
            Node current = head.GetNext();
            int count = 0;
            while(current != null) {
                tempItemsArray[count] = current.GetItems();
                current = current.GetNext();
                count++;
            }
            return tempItemsArray;
        }

        /// <summary>
        /// Gets item by index???
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Items GetSingleItem(int index) {
            Node current = head.GetNext();
            for(int i = 1; i < index; i++) {
                if(current.GetNext() == null) {
                    return null;
                }
                current = current.GetNext();
                break;
            }
            return current.GetItems();
        }

        /// <summary>
        /// Returns color of item.
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>ConsoleColor</returns>
        public RLColor GetColor(int index) {
            Node current = head.GetNext();
            for(int i = 1; i < index; i++) {
                if(current.GetNext() == null) {
                    return RLColor.White;
                }
                current = current.GetNext();
                break;
            }
            return current.GetColor();
        }


        /// <summary>
        /// Represents a node for an Item
        /// </summary>
        private class Node {
            Node next;
            Items items;

            /// <summary>
            /// Constructs a new instance of a node.
            /// </summary>
            /// <param name="item">Item</param>
            public Node(Items item) {
                next = null;
                items = item;
            }

            public Node(Items item, Node _next) {
                next = _next;
                items = item;
            }
            
            /// <summary>
            /// Returns Item contained in node.
            /// </summary>
            /// <returns>Items</returns>
            public Items GetItems() { return items; }

            /// <summary>
            /// Returns name of item in node.
            /// </summary>
            /// <returns>Item Name</returns>
            public string GetName() { return items.GetName(); }

            /// <summary>
            /// Returns color of item in node.
            /// </summary>
            /// <returns></returns>
            public RLColor GetColor() { return items.GetConsoleColor(); }
            
            /// <summary>
            /// Gets the next node in the list.
            /// </summary>
            /// <returns>Next Node</returns>
            public Node GetNext() { return next; }

            /// <summary>
            /// Sets the next node in the list.
            /// </summary>
            /// <param name="_next">Node</param>
            public void SetNext(Node _next) { next = _next; }
        }
    }
}


