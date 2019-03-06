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
using TextGame.Interfaces;

namespace TextGame.Core {
    public class Actor : IActor, IDrawable{
        public string Name {
            get; set;
        }

        public int Awareness {
            get; set;
        }

        public RLColor Color {
            get; set;
        }

        public char Symbol {
            get; set;
        }

        public int X {
            get; set;
        }

        public int Y {
            get; set;
        }

        public void Draw(RLConsole console, IMap map) {
            //dont draw actors in cells that havent been explored
            if(!map.GetCell(X, Y).IsExplored) {
                return;
            }

            //only draw the avtor with the color and symbol when they are in fov
            if(map.IsInFov(X, Y)) {
                console.Set(X, Y, Color, Colors.FloorBackgroundFOV, Symbol);
            }else {
                //when not in fov just draw normal floor
                console.Set(X, Y, Colors.Floor, Colors.FloorBackground, '.');
            }
        }
    }
}
