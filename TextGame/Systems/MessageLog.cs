using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;

namespace TextGame.Systems {
    /// <summary>
    /// Represents a queue of messages that can be added to
    /// Has a method for drawing to the RLConsole
    /// </summary>
    public class MessageLog {
        private static readonly int maxLines = 9;
                 
        private readonly Queue<string> lines;

        public MessageLog() {
            this.lines = new Queue<string>();
        }

        public void Add(string message) {
            this.lines.Enqueue(message);

            if(this.lines.Count > maxLines) {
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
