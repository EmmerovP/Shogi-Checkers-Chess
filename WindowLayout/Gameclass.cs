using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowLayout
{
    class Gameclass
    {
        public static class CurrentGame
        {
            public static GameType gameType;
            public static PlayerType playerType;
        }

        public enum GameType
        {
            chess,
            checkers,
            shogi,
            custom
        }

        public enum PlayerType
        {
            single,
            localmulti,
            webmulti
        }
    }
}
