using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using RLNET;

namespace TextGame.Systems {
    public class InventoryLog {
        private static readonly int maxLines = 9;
        private readonly Queue<string> lines;

        public InventoryLog() {
            this.lines = new Queue<string>();
        }

        public void Add(string message) {
            this.lines.Enqueue(message);
             
            if(this.lines.Count > maxLines){
                this.lines.Dequeue();
            }
        }

        public void Draw(RLConsole console) {
            console.Clear();
            string[] lines = this.lines.ToArray();
            for(int i = 0; i < lines.Length; i++) {
                console.Print(1, i + 1, lines[i], RLColor.White);
            }
        }

    }
}
