using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;

namespace TextGame.Core {
    public class Colors {
        public static RLColor FloorBackground = RLColor.Black;
        public static RLColor Floor = Swatch.AlternateDarkest;
        public static RLColor FloorBackgroundFOV = Swatch.DbDark;
        public static RLColor FloorFOV = Swatch.Alternate;

        public static RLColor WallBackground = Swatch.SecondaryDarkest;
        public static RLColor Wall = Swatch.Secondary;
        public static RLColor WallBackgroundFOV = Swatch.SecondaryDarker;
        public static RLColor WallFOV = Swatch.SecondaryLighter;

        public static RLColor TextHeading = Swatch.DbLight;

        public static RLColor Player = Swatch.DbLight;
    }
}
