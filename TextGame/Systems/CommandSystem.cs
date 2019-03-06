using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Core;
using Entities;

namespace TextGame.Systems {
    public class CommandSystem {
        //Return this value if the player was able to move
        //false when the player couldn't most, such as trying to move into a wall

        public bool MovePlayer(Direction direction, Player player, DungeonMap map) {
            int x = player.X;
            int y = player.Y;

            switch (direction) {
                case Direction.Up: y = player.Y - 1;break;
                case Direction.Down: y = player.Y + 1; break;
                case Direction.Left: x = player.X - 1; break;
                case Direction.Right: x = player.X + 1; break;
                default: return false;
            }
            if(map.SetPlayerPosition(player, x, y)){
                return true;
            }
            return false;
        }

    }
}
