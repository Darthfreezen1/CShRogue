using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;
using RogueSharp;
using TextGame.Core;
using TextGame;
using Entities;

namespace TextGame.Systems {

    public class MapGenerator {

        private readonly int width;
        private readonly int height;
        private readonly int maxRooms;
        private readonly int maxRoomSize;
        private readonly int minRoomSize;

        private readonly DungeonMap map;

        /// <summary>
        /// Constructs a new MapGenerator
        /// </summary>
        /// <param name="width">width of the map</param>
        /// <param name="height">height of the map</param>
        public MapGenerator(int width, int height, int rooms, int minSize, int maxSize) {
            this.width = width;
            this.height = height;
            this.maxRooms = rooms;
            this.maxRoomSize = maxSize;
            this.minRoomSize = minSize;
            this.map = new DungeonMap();
        }

        private void PlacePlayer(Player player) {
            player.X = this.map.Rooms[0].Center.X;
            player.Y = this.map.Rooms[0].Center.Y;

            this.map.AddPlayer(player);
        }

        private void CreateHorizontalTunnel(int xStart, int xEnd, int yPosition) {
            for(int x = Math.Min(xStart, xEnd); x <= Math.Max(xStart, xEnd); x++) {
                this.map.SetCellProperties(x, yPosition, true, true);
            }
        }

        private void CreateVerticalTunnel(int yStart, int yEnd, int xPosition) {
            for(int y = Math.Min(yStart, yEnd); y <= Math.Max(yStart, yEnd); y++) {
                this.map.SetCellProperties(xPosition, y, true, true);
            }
        }

        /// <summary>
        /// Generate a new map
        /// </summary>
        /// <returns></returns>
        public DungeonMap CreateMap() {
            //Init every cell in the map by setting walkable, transparancy, and explored to true
            this.map.Initialize(this.width, this.height);

            //try to place as many rooms as the specified maxrooms
            for(int i = maxRooms; i > 0; i--) {
                //determine the size and position of thr room randomly
                int roomWidth = Program.Random.Next(this.minRoomSize, this.maxRoomSize);
                int roomHeight = Program.Random.Next(this.minRoomSize, this.maxRoomSize);
                int roomXPosition = Program.Random.Next(0, this.width - roomWidth - 1);
                int roomYPosition = Program.Random.Next(0, this.height - roomHeight - 1);

                var newRoom = new Rectangle(roomXPosition, roomYPosition, roomWidth, roomHeight);

                bool newRoomIntersects = this.map.Rooms.Any(room => newRoom.Intersects(room));

                if (!newRoomIntersects) {
                    this.map.Rooms.Add(newRoom);
                }

                for(int r= 1; r < this.map.Rooms.Count; r++) {
                    int prevRoomCenterX = this.map.Rooms[r - 1].Center.X;
                    int prevRoomCenterY = this.map.Rooms[r - 1].Center.Y;
                    int currRoomCenterX = this.map.Rooms[r].Center.X;
                    int currRoomCenterY = this.map.Rooms[r].Center.Y;

                    if(Program.Random.Next(1, 2) == 1) {
                        CreateHorizontalTunnel(prevRoomCenterX, currRoomCenterX, prevRoomCenterY);
                        CreateVerticalTunnel(prevRoomCenterY, currRoomCenterY, prevRoomCenterX);
                    }else {
                        CreateVerticalTunnel(prevRoomCenterY, currRoomCenterY, prevRoomCenterX);
                        CreateHorizontalTunnel(prevRoomCenterX, currRoomCenterX, currRoomCenterY);
                    }

                }

            }

            foreach (Rectangle room in this.map.Rooms) {
                CreateRoom(room);
            }

            PlacePlayer(Program.player);

            return this.map;
            
        }

        private void CreateRoom(Rectangle room) {
            for(int x = room.Left + 1; x < room.Right; x++) {
                for(int y = room.Top+1; y < room.Bottom; y++) {
                    this.map.SetCellProperties(x, y, true, true, true);
                }
            }
        }

    }
}
