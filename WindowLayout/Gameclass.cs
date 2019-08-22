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

            public static bool MustTake()
            {
                for (int i = 0; i <Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        if ((Board.board[i, j] != null) && (GameCourse.WhitePlays == Board.board[i,j].isWhite))
                        {
                            Moves.CoordinatesCopy cp = Moves.MakeCopyEmpty();

                            bool musttake = Moves.CheckersTake(i, j, Board.board);

                            Moves.EmptyCoordinates();
                            Moves.CoordinatesReturn(cp);

                            if (musttake)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
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
