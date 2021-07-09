using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiCheckersChess
{
    public class PiecesNumbers
    {
        /// <summary>
        /// When given number, returns full name of a piece.
        /// </summary>
        public static Dictionary<int, string> getName = new Dictionary<int, string>()
        {
            { 0, "Bílý král"},
            { 1, "Bílá královna" },
            { 2, "Bílá věž" },
            { 3, "Bílý kůň" },
            { 4, "Bílý střelec" },
            { 5, "Bílý pěšec" },
            { 6, "Bílý kámen" },
            { 7, "Bílá dáma" },
            { 8, "Spodní shogi král" },
            { 9, "Spodní shogi věž" },
            { 10, "Povýšená spodní shogi věž" },
            { 11, "Spodní shogi střelec" },
            { 12, "Povýšený spodní shogi střelec" },
            { 13, "Spodní zlatý generál" },
            { 14, "Spodní stříbrný generál" },
            { 15, "Povýšený spodní stříbrný generál" },
            { 16, "Spodní shogi kůň" },
            { 17, "Povýšený spodní shogi kůň" },
            { 18, "Spodní kopiník" },
            { 19, "Povýšený spodní kopiník" },
            { 20, "Spodní shogi pěšák" },
            { 21, "Povýšený spodní shogi pěšák" },
            { 22, "Černý král"},
            { 23, "Černá královna" },
            { 24, "Černá věž" },
            { 25, "Černý kůň" },
            { 26, "Černý střelec" },
            { 27, "Černý pěšec" },
            { 28, "Černý kámen" },
            { 29, "Černá dáma" },
            { 30, "Vrchní shogi král" },
            { 31, "Vrchní shogi věž" },
            { 32, "Povýšená vrchní shogi věž" },
            { 33, "Vrchní shogi střelec" },
            { 34, "Povýšený vrchní shogi střelec" },
            { 35, "Vrchní zlatý generál" },
            { 36, "Vrchní stříbrný generál" },
            { 37, "Povýšený vrchní stříbrný generál" },
            { 38, "Vrchní shogi kůň" },
            { 39, "Povýšený vrchní shogi kůň" },
            { 40, "Vrchní kopiník" },
            { 41, "Povýšený vrchní kopiník" },
            { 42, "Vrchní shogi pěšák" },
            { 43, "Povýšený vrchní shogi pěšák" }
        };

        /// <summary>
        /// When given full name oif a piece, returns a number of it.
        /// </summary>
        public static Dictionary<string, int> getNumber = new Dictionary<string, int>()
        {
            { "Bílý král", 0},
            { "Bílá královna", 1 },
            { "Bílá věž", 2 },
            {  "Bílý kůň", 3 },
            { "Bílý střelec", 4 },
            {  "Bílý pěšec", 5 },
            {  "Bílý kámen", 6 },
            {  "Bílá dáma", 7 },
            { "Spodní shogi král", 8 },
            { "Spodní shogi věž", 9 },
            { "Povýšená spodní shogi věž", 10 },
            { "Spodní shogi střelec", 11 },
            { "Povýšený spodní shogi střelec", 12 },
            { "Spodní zlatý generál", 13 },
            { "Spodní stříbrný generál", 14 },
            { "Povýšený spodní stříbrný generál", 15 },
            { "Spodní shogi kůň", 16 },
            { "Povýšený spodní shogi kůň", 17 },
            { "Spodní kopiník", 18 },
            { "Povýšený spodní kopiník", 19 },
            { "Spodní shogi pěšák", 20 },
            { "Povýšený spodní shogi pěšák", 21 },
            { "Černý král", 22 },
            { "Černá královna", 23 },
            { "Černá věž", 24 },
            { "Černý kůň", 25 },
            { "Černý střelec", 26 },
            { "Černý pěšec", 27 },
            { "Černý kámen", 28 },
            { "Černá dáma", 29 },
            { "Vrchní shogi král", 30 },
            { "Vrchní shogi věž", 31 },
            { "Povýšená vrchní shogi věž", 32 },
            { "Vrchní shogi střelec", 33 },
            { "Povýšený vrchní shogi střelec", 34 },
            { "Vrchní zlatý generál", 35 },
            { "Vrchní stříbrný generál", 36 },
            { "Povýšený vrchní stříbrný generál", 37 },
            { "Vrchní shogi kůň", 38 },
            { "Povýšený vrchní shogi kůň", 39 },
            { "Vrchní kopiník", 40 },
            { "Povýšený vrchní kopiník", 41 },
            { "Vrchní shogi pěšák", 42 },
            { "Povýšený vrchní shogi pěšák", 43 }
        };

        /// <summary>
        /// List of all shogi pieces we can propagate. To propagate, it is enough to increment its number by one.
        /// </summary>
        public static int[] canPropagate = {9, 11, 14, 16, 18, 20, 31, 33, 36, 38, 40, 42};

        /// <summary>
        /// Given a name of a piece, returns number of piece corresponding to bottom/white side.
        /// </summary>
        public static Dictionary<string, int> getBottomNumber = new Dictionary<string, int>()
        {
            { "Král", 0},
            { "Královna", 1 },
            { "Věž", 2 },
            {  "Kůň", 3 },
            { "Střelec", 4 },
            {  "Pěšec", 5 },
            {  "Kámen", 6 },
            { "Dáma", 7 },
            { "Shogi král", 8 },
            { "Shogi věž", 9 },
            { "Povýšená shogi věž", 10 },
            { "Shogi střelec", 11 },
            { "Povýšený shogi střelec", 12 },
            { "Zlatý generál", 13 },
            { "Stříbrný generál", 14 },
            { "Povýšený stříbrný generál", 15 },
            { "Shogi kůň", 16 },
            { "Povýšený shogi kůň", 17 },
            { "Kopiník", 18 },
            { "Povýšený kopiník", 19 },
            { "Shogi pěšák", 20 },
            { "Povýšený shogi pěšák", 21 }

        };

        /// <summary>
        /// Given a name of a piece, returns number of piece corresponding to upper/black side.
        /// </summary>
        public static Dictionary<string, int> getUpperNumber = new Dictionary<string, int>()
        {
            { "Král", 22 },
            { "Královna", 23 },
            { "Věž", 24 },
            { "Kůň", 25 },
            { "Střelec", 26 },
            { "Pěšec", 27 },
            { "Kámen", 28 },
            { "Dáma", 29 },
            { "Shogi král", 30 },
            { "Shogi věž", 31 },
            { "Povýšená shogi věž", 32 },
            { "Shogi střelec", 33 },
            { "Povýšený shogi střelec", 34 },
            { "Zlatý generál", 35 },
            { "Stříbrný generál", 36 },
            { "Povýšený stříbrný generál", 37 },
            { "Shogi kůň", 38 },
            { "Povýšený shogi kůň", 39 },
            { "Kopiník", 40 },
            { "Povýšený kopiník", 41 },
            { "Shogi pěšák", 42 },
            { "Povýšený shogi pěšák", 43 }

        };

        /// <summary>
        /// List of all possible moves of pieces. 
        /// </summary>
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
            { 20, Moves.PawnTwoForward },
            { 21, Moves.PawnTwoBackward },
            { 22, Moves.CheckersQueen }
        };

        public static Dictionary<string, int> getMoveName = new Dictionary<string, int>()
        {
            { "Dopředu", 1 },
            { "Dopředu vpravo", 2 },
            {  "Vpravo", 3 },
            { "Dozadu vpravo", 4 },
            { "Dozadu", 5 } /*,
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
            { 20, Moves.PawnTwoForward },
            { 21, Moves.PawnTwoBackward },
            { 22, Moves.CheckersQueen }*/
        };

        /// <summary>
        /// Updates dictionaries containing pieces by a new piece.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int UpdatePiece(string name)
        {
            int value = getNumber.Count();

            getName.Add(value, name);
            getNumber.Add(name, value);

            getBottomNumber.Add(name, value);
            getUpperNumber.Add(name, value);

            return value;
        }

        /// <summary>
        /// Since pieces are marked by number, and shogi pawns may have multiple numbers:
        /// For the upper and bottom piece, for the normal and promoted one.
        /// Here we return true when the number of given piece corresponds to shogi pawn in any form.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public static bool IsShogiPawn(Pieces piece)
        {
            switch (piece.GetNumber())
            {
                case 42: return true;
                case 43: return true;
                case 20: return true;
                case 21: return true;
            }
            return false;
        }

        /// <summary>
        /// Returns true when given piece is checkers piece.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public static bool IsCheckersPiece(Pieces piece)
        {
            switch (piece.GetNumber())
            {
                case 28: return true;
                case 6: return true;
            }
            return false;
        }

        public static bool IsWhiteCheckersPiece(Pieces piece)
        {
            switch (piece.GetNumber())
            {
                case 6: return true;
            }
            return false;
        }

        public static bool IsBlackCheckersPiece(Pieces piece)
        {
            switch (piece.GetNumber())
            {
                case 28: return true;
            }
            return false;
        }

        public static bool IsBottomPawn(Pieces piece)
        {
            if (piece.GetNumber() == 5)
            {
                return true;
            }

            return false;
        }

        public static bool IsUpperPawn(Pieces piece)
        {
            if (piece.GetNumber() == 27)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns true when given piece is checkers piece.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public static bool IsKing(Pieces piece)
        {
            switch (piece.GetNumber())
            {
                case 0: return true;
                case 22: return true;
            }
            return false;
        }

        /// <summary>
        /// Returns true when given piece is shogi king.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public static bool IsShogiKing(Pieces piece)
        {
            if (piece.GetNumber() == 30 || piece.GetNumber() == 8)
            {
                return true;
            }

            return false;
        }

        public static bool IsCheckersQueen(Pieces piece)
        {
            if (piece.GetNumber() == 7 || piece.GetNumber() == 29)
            {
                return true;
            }

            return false;
        }

        public static bool IsWhiteRook(Pieces piece)
        {
            if (piece.GetNumber() == 2)
            {
                return true;
            }

            return false;
        }

        public static bool IsBlackRook(Pieces piece)
        {
            if (piece.GetNumber() == 24)
            {
                return true;
            }

            return false;
        }




    }
}
