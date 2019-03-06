using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using TEXTGAMEAPI.Enemies;
using TEXTGAMEAPI;
using RLNET;
using TextGame.Core;
using TextGame.Systems;
using RogueSharp.Random;

namespace TextGame {
    public class Program {

        //Screen width and height are in no. of tiles
        private static readonly int _screenWidth = 100;
        private static readonly int _screenHeight = 70;
        private static RLRootConsole _rootConsole;

        //Map Section
        private static readonly int _mapWidth = 80;
        private static readonly int _mapHeight = 48;
        private static RLConsole _mapConsole;

        //Message Section
        private static readonly int _messageWidth = 80;
        private static readonly int _messageHeight = 11;
        private static RLConsole _messageConsole;

        //Stat Section
        private static readonly int _statWidth = 20;
        private static readonly int _statHeight = 70;
        private static RLConsole _statConsole;

        //Inventory Section
        private static readonly int _invWidth = 80;
        private static readonly int _invHeight = 11;
        private static RLConsole _invConsole;

        public static MessageLog MessageLog {
            get; private set;
        }

        public static InventoryLog InventoryLog {
            get; private set;
        }

        private static bool renderRequired = true;
        public static CommandSystem CommandSystem {
            get; private set;
        }
        
        public static DungeonMap DungeonMap {
            get; private set;
        }

        public static Player player {
            get; private set;
        }

        public static IRandom Random { get; private set; }

        static void Main(string[] args) {
            

            int seed = (int)DateTime.UtcNow.Ticks;
            Random = new DotNetRandom(seed);
            
                     
            string consoleTitle = $"RogueSharp Test - Level 1 - Seed {seed}";

            string fontFileName = "terminal8x8.png";

            player = new Player(10, 10, 10, 10, 10, 10, 10, 10, 10,
                                10, 10, 10, 10, 10, 10, 10, 10, 10,
                                10, 10, 10, 10, 10, ClassTypes.Archer, RLColor.White,
                                new WeaponTest(), new TestArmour(), "dick");

            MapGenerator mapGenerator = new MapGenerator(_mapWidth, _mapHeight, 20, 7, 13);
            DungeonMap = mapGenerator.CreateMap();
            SaveTest save = new SaveTest(seed.ToString(), player.SavePlayer());

            DungeonMap.UpdatePlayerFieldOfView(player);

            CommandSystem = new CommandSystem();

            MessageLog = new MessageLog();
            MessageLog.Add("Message 1");

            InventoryLog = new InventoryLog();
            InventoryLog.Add("Weapon: "+player.GetInventory().GetThing(0).GetName());

            MessageLog.Add($"Level created with seed {seed}");

            //tells rlnet to use the bitmap font and that each tile is 8x8px
            _rootConsole = new RLRootConsole(fontFileName, _screenWidth, _screenHeight, 8, 8, 1f, consoleTitle);

            //setting up other sections
            _mapConsole = new RLConsole(_mapWidth, _mapHeight);
            _messageConsole = new RLConsole(_messageWidth, _messageHeight);
            _statConsole = new RLConsole(_statWidth, _statHeight);
            _invConsole = new RLConsole(_invWidth, _invHeight);

            //event wiring
            _rootConsole.Update += OnRootConsoleUpdate;
            _rootConsole.Render += OnRootConsoleRender;

            //game loop call
            _rootConsole.Run();

        }

        /// <summary>
        /// Event handler for RLNET update event
        /// </summary>
        private static void OnRootConsoleUpdate(object sender, UpdateEventArgs e) {
            _mapConsole.SetBackColor(0, 0, _mapWidth, _mapHeight, Colors.FloorBackground);
            _statConsole.SetBackColor(0, 0, _statWidth, _statHeight, Swatch.DbOldStone);
            _statConsole.Print(1, 1, "Stats", Colors.TextHeading);

            /**
            _invConsole.SetBackColor(0, 0, _invWidth, _invHeight, Swatch.DbWood);
            _invConsole.Print(1, 1, "Inventory", Colors.TextHeading);
            **/

            RLKeyPress keyPress = _rootConsole.Keyboard.GetKeyPress();
            bool playerActed = false;
            if(keyPress != null) {
                if(keyPress.Key == RLKey.Up) {
                    playerActed = CommandSystem.MovePlayer(Direction.Up, player, DungeonMap);
                }else if(keyPress.Key == RLKey.Down) {
                    playerActed = CommandSystem.MovePlayer(Direction.Down, player, DungeonMap);
                }else if(keyPress.Key == RLKey.Left) {
                    playerActed = CommandSystem.MovePlayer(Direction.Left, player, DungeonMap);
                }else if(keyPress.Key == RLKey.Right) {
                    playerActed = CommandSystem.MovePlayer(Direction.Right, player, DungeonMap);
                }
            }
            if (playerActed) {
                renderRequired = true;
            }
            

        }


        /// <summary>
        /// Event handler for RLNET Render event
        /// </summary>
        private static void OnRootConsoleRender(object sender, UpdateEventArgs e) {
            //Blit other console sections to the root console
            //Blit: Bit BLock Transfer
            RLConsole.Blit(_mapConsole, 0, 0, _mapWidth, _mapHeight, _rootConsole, 0, _invHeight);
            RLConsole.Blit(_statConsole, 0, 0, _statWidth, _statHeight, _rootConsole, _mapWidth, 0);
            RLConsole.Blit(_messageConsole, 0, 0, _messageWidth, _messageHeight, _rootConsole, 0, _screenHeight - _messageHeight);
            RLConsole.Blit(_invConsole, 0, 0, _invWidth, _invHeight, _rootConsole, 0, 0);

            DungeonMap.Draw(_mapConsole);
            MessageLog.Draw(_messageConsole);
            InventoryLog.Draw(_invConsole);
            player.Draw(_mapConsole, DungeonMap);
            _rootConsole.Draw();
        }
        
    }
}