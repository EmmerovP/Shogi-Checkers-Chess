using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiCheckersChess
{
    public class PiecesNumbers
    {
        public static Dictionary<int, string> getName = new Dictionary<int, string>()
        {
            { 0, "Bílý král"},
            { 1, "Bílá královna" },
            { 2, "Bílá věž" },
            { 3, "Bílý kůň" },
            { 4, "Bílý střelec" },
            { 5, "Bílý pěšec" },
            { 6, "Bílý kámen" },
            { 7, "Spodní shogi král" },
            { 8, "Spodní shogi věž" },
            { 9, "Povýšená spodní shogi věž" },
            { 10, "Spodní shogi střelec" },
            { 11, "Povýšený spodní shogi střelec" },
            { 12, "Spodní zlatý generál" },
            { 13, "Spodní stříbrný generál" },
            { 14, "Povýšený spodní stříbrný generál" },
            { 15, "Spodní shogi kůň" },
            { 16, "Povýšený spodní shogi kůň" },
            { 17, "Spodní kopiník" },
            { 18, "Povýšený spodní kopiník" },
            { 19, "Spodní shogi pěšák" },
            { 20, "Povýšený spodní shogi pěšák" },
            { 21, "Černý král"},
            { 22, "Černá královna" },
            { 23, "Černá věž" },
            { 24, "Černý kůň" },
            { 25, "Černý střelec" },
            { 26, "Černý pěšec" },
            { 27, "Černý kámen" },
            { 28, "Vrchní shogi král" },
            { 29, "Vrchní shogi věž" },
            { 30, "Povýšená vrchní shogi věž" },
            { 31, "Vrchní shogi střelec" },
            { 32, "Povýšený vrchní shogi střelec" },
            { 33, "Vrchní zlatý generál" },
            { 34, "Vrchní stříbrný generál" },
            { 35, "Povýšený vrchní stříbrný generál" },
            { 36, "Vrchní shogi kůň" },
            { 37, "Povýšený vrchní shogi kůň" },
            { 38, "Vrchní kopiník" },
            { 39, "Povýšený vrchní kopiník" },
            { 40, "Vrchní shogi pěšák" },
            { 41, "Povýšený vrchní shogi pěšák" }
        };

        public static Dictionary<string, int> getNumber = new Dictionary<string, int>()
        {
            { "Bílý král", 0},
            { "Bílá královna", 1 },
            { "Bílá věž", 2 },
            {  "Bílý kůň", 3 },
            { "Bílý střelec", 4 },
            {  "Bílý pěšec", 5 },
            {  "Bílý kámen", 6 },
            { "Spodní shogi král", 7 },
            { "Spodní shogi věž", 8 },
            { "Povýšená spodní shogi věž", 9 },
            { "Spodní shogi střelec", 10 },
            { "Povýšený spodní shogi střelec", 11 },
            { "Spodní zlatý generál", 12 },
            { "Spodní stříbrný generál", 13 },
            { "Povýšený spodní stříbrný generál", 14 },
            { "Spodní shogi kůň", 15 },
            { "Povýšený spodní shogi kůň", 16 },
            { "Spodní kopiník", 17 },
            { "Povýšený spodní kopiník", 18 },
            { "Spodní shogi pěšák", 19 },
            { "Povýšený spodní shogi pěšák", 20 },
            { "Černý král", 21},
            { "Černá královna", 22 },
            { "Černá věž", 23 },
            { "Černý kůň", 24 },
            { "Černý střelec", 25 },
            { "Černý pěšec", 26 },
            { "Černý kámen", 27 },
            { "Vrchní shogi král", 28 },
            { "Vrchní shogi věž", 29 },
            { "Povýšená vrchní shogi věž", 30 },
            { "Vrchní shogi střelec", 31 },
            { "Povýšený vrchní shogi střelec", 32 },
            { "Vrchní zlatý generál", 33 },
            { "Vrchní stříbrný generál", 34 },
            { "Povýšený vrchní stříbrný generál", 35 },
            { "Vrchní shogi kůň", 36 },
            { "Povýšený vrchní shogi kůň", 37 },
            { "Vrchní kopiník", 38 },
            { "Povýšený vrchní kopiník", 39 },
            { "Vrchní shogi pěšák", 40 },
            { "Povýšený vrchní shogi pěšák", 41 }
        };

        public static Dictionary<string, int> getBottomNumber = new Dictionary<string, int>()
        {
            { "Shogi král", 7 },
            { "Shogi věž", 8 },
            { "Povýšená shogi věž", 9 },
            { "Shogi střelec", 10 },
            { "Povýšený shogi střelec", 11 },
            { "Zlatý generál", 12 },
            { "Stříbrný generál", 13 },
            { "Povýšený stříbrný generál", 14 },
            { "Shogi kůň", 15 },
            { "Povýšený shogi kůň", 16 },
            { "Kopiník", 17 },
            { "Povýšený kopiník", 18 },
            { "Shogi pěšák", 19 },
            { "Povýšený shogi pěšák", 20 },
            { "Král", 21},
            { "Královna", 22 },
            { "Věž", 23 },
            { "Kůň", 24 },
            { "Střelec", 25 },
            { "Pěšec", 26 },
            { "Kámen", 27 },          
        };

        public static Dictionary<string, int> getUpperNumber = new Dictionary<string, int>()
        {
            { "Král", 0},
            { "Královna", 1 },
            { "Věž", 2 },
            {  "Kůň", 3 },
            { "Střelec", 4 },
            {  "Pěšec", 5 },
            {  "Kámen", 6 },
            { "Shogi král", 28 },
            { "Shogi věž", 29 },
            { "Povýšená shogi věž", 30 },
            { "Shogi střelec", 31 },
            { "Povýšený shogi střelec", 32 },
            { "Zlatý generál", 33 },
            { "Stříbrný generál", 34 },
            { "Povýšený stříbrný generál", 35 },
            { "Shogi kůň", 36 },
            { "Povýšený shogi kůň", 37 },
            { "Kopiník", 38 },
            { "Povýšený kopiník", 39 },
            { "Shogi pěšák", 40 },
            { "Povýšený shogi pěšák", 41 }
        };

        /*
        public static Dictionary<int, string> getUpperName = new Dictionary<string, int>()
        {
            { 0, "Bílý král"},
            { 1, "Bílá královna" },
            { 2, "Bílá věž" },
            { 3, "Bílý kůň" },
            { 4, "Bílý střelec" },
            { 5, "Bílý pěšec" },
            { 6, "Bílý kámen" },
            { 7, "Spodní shogi král" },
            { 8, "Spodní shogi věž" },
            { 9, "Povýšená spodní shogi věž" },
            { 10, "Spodní shogi střelec" },
            { 11, "Povýšený spodní shogi střelec" },
            { 12, "Spodní zlatý generál" },
            { 13, "Spodní stříbrný generál" },
            { 14, "Povýšený spodní stříbrný generál" },
            { 15, "Spodní shogi kůň" },
            { 16, "Povýšený spodní shogi kůň" },
            { 17, "Spodní kopiník" },
            { 18, "Povýšený spodní kopiník" },
            { 19, "Spodní shogi pěšák" },
            { 20, "Povýšený spodní shogi pěšák" },
            { 21, "Černý král"},
            { 22, "Černá královna" },
            { 23, "Černá věž" },
            { 24, "Černý kůň" },
            { 25, "Černý střelec" },
            { 26, "Černý pěšec" },
            { 27, "Černý kámen" },
            { 28, "Vrchní shogi král" },
            { 29, "Vrchní shogi věž" },
            { 30, "Povýšená vrchní shogi věž" },
            { 31, "Vrchní shogi střelec" },
            { 32, "Povýšený vrchní shogi střelec" },
            { 33, "Vrchní zlatý generál" },
            { 34, "Vrchní stříbrný generál" },
            { 35, "Povýšený vrchní stříbrný generál" },
            { 36, "Vrchní shogi kůň" },
            { 37, "Povýšený vrchní shogi kůň" },
            { 38, "Vrchní kopiník" },
            { 39, "Povýšený vrchní kopiník" },
            { 40, "Vrchní shogi pěšák" },
            { 41, "Povýšený vrchní shogi pěšák" }
        }; */





        public static Dictionary<int, Action<int, int, Pieces[,]>> getMovefromNumber = new Dictionary<int, Action<int, int, Pieces[,]>>()
        {
            { 1, Moves.Forward },
            { 2, Moves.ForwardRight },
            { 3, Moves.Right },
            { 4, Moves.BackRight },
            { 5, Moves.Back },
            { 6, Moves.BackLeft },
            { 7, Moves.Left },
            { 8, Moves.ForwardLeft },
            { 9, Moves.ForwardInfinity },
            { 10, Moves.ForwardRightInfinity },
            { 11, Moves.RightInfinity },
            { 12, Moves.BackRightInfinity },
            { 13, Moves.BackInfinity },
            { 14, Moves.BackLeftInfinity },
            { 15, Moves.LeftInfinity},
            { 16, Moves.ForwardLeftInfinity },
            { 17, Moves.Horse },
            { 18, Moves.HorseForward },
            { 19, Moves.HorseBackward },
            { 20, Moves.TwoForward },
            { 21, Moves.TwoBackward }
        };

        public static int updatePiece(string name)
        {
            int value = getNumber.Count();

            getName.Add(value, name);
            getNumber.Add(name, value);

            getBottomNumber.Add(name, value);
            getUpperNumber.Add(name, value);

            return value;
        }




    }
}
