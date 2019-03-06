using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;
using RogueSharp;
using TEXTGAMEAPI;
using TEXTGAMEAPI.Enemies;
using Entities;


namespace TextGame.Interfaces {
    public interface IActor {
        string Name {
            get; set;
        }

        int Awareness {
            get; set;
        }

    }
}
