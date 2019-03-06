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

namespace TextGame.Core {
    public class PlayerActor : Actor{

        public PlayerActor() {
            Player player = new Player(10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, ClassTypes.Archer, RLColor.Green, new IronLongSword(), new TestArmour(), "bill buttlicker");
            Awareness = player.Awareness;
            Name = player.GetName();
            Color = Colors.Player;
            //Color = player.GetColor();
            Symbol = player.GetSymbol();
            X = 10;
            Y = 10;
        }

    }
}
