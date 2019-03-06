using RogueSharp;
using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace TextGame.Core {
    /// <summary>
    /// Creates a dungeon
    /// Extends RogueSharp.Map
    /// </summary>
    public class DungeonMap : Map{
        public List<Rectangle> Rooms;

        public DungeonMap() {
            Rooms = new List<Rectangle>();
        }
        public void Draw(RLConsole mapConsole) {
            mapConsole.Clear();
            foreach(Cell cell in GetAllCells()) {
                SetConsoleSymbolForCell(mapConsole, cell);
            }
        }

        public void AddPlayer(Player player) {
            SetIsWalkable(player.X, player.Y, false);
            UpdatePlayerFieldOfView(player);
        }

        private void SetConsoleSymbolForCell(RLConsole console, Cell cell) {
            //if cell is not explored, dont draw
            if (!cell.IsExplored) {
                return;
            }

            //when a cell is currently in the fov it should be drawn with lighter colors
            if(IsInFov(cell.X, cell.Y)) {
                //choose the symbol to draw based on if the cell is walkable or not
                // '.' for floor and # for walls
                if (cell.IsWalkable) {
                    console.Set(cell.X, cell.Y, Colors.FloorFOV, Colors.FloorBackgroundFOV, '.');
                }else {
                    console.Set(cell.X, cell.Y, Colors.WallFOV, Colors.WallBackgroundFOV, '#');
                }

                //when a cell is outside of the field of view draw it with darker colors
            }else {
                if (cell.IsWalkable) {
                    console.Set(cell.X, cell.Y, Colors.Floor, Colors.FloorBackground, '.');
                }
                else {
                    console.Set(cell.X, cell.Y, Colors.Wall, Colors.WallBackground, '#');
                }
            }

        }

        public bool SetPlayerPosition(Player player, int x, int y) {
            if(GetCell(x, y).IsWalkable) {
                SetIsWalkable(player.X, player.Y, true);
                player.X = x;
                player.Y = y;
                SetIsWalkable(player.X, player.Y, false);
                if(player is Player) {
                    UpdatePlayerFieldOfView(player);
                }
                return true;
            }
            return false;
        }

        public void SetIsWalkable(int x, int y, bool isWalkable) {
            ICell cell = GetCell(x, y);
            SetCellProperties(cell.X, cell.Y, cell.IsTransparent, isWalkable, cell.IsExplored);
        }

        public void UpdatePlayerFieldOfView(Player player) {
            
            ComputeFov(player.X, player.Y, player.Awareness, true);

            foreach(Cell cell in GetAllCells()) {
                if(IsInFov(cell.X, cell.Y)) {
                    SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
                }
            }
        }


    }
}
