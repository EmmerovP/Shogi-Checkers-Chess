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
                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        if ((Board.board[i, j] != null) && (GameCourse.WhitePlays == Board.board[i, j].isWhite))
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

            //zda v dámě má hráč figurky či už se nemůže hýbat
            public static bool CheckersEnd()
            {
                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        if ((Board.board[i, j] != null) && (GameCourse.WhitePlays == Board.board[i, j].isWhite))
                        {
                            GameCourse.Generate(Board.board[i, j], true, i, j);
                            if (Moves.final_x.Count != 0)
                            {
                                return false;
                            }
                        }
                    }
                }

                return true;
            }

            //na konci tahu řekne zda šach či ne - funguje
            public static bool KingCheck()
            {
                Moves.CoordinatesCopy cp = Moves.MakeCopyEmpty();

                bool[,] board = new bool[Board.board.GetLength(0), Board.board.GetLength(1)];

                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        if ((Board.board[i,j] != null)&&(Board.board[i, j].isWhite == GameCourse.WhitePlays))
                        {
                            GameCourse.GenerateMoves(Board.board[i, j], false, i, j);
                        }
                    }
                }

                for (int i = 0; i < Moves.final_x.Count; i++)
                {
                    Pieces piece = Board.board[Moves.final_x[i], Moves.final_y[i]];
                    if ((piece != null)&&(piece.GetNumber() == 0)&&(GameCourse.WhitePlays != piece.isWhite))
                    {
                        Moves.EmptyCoordinates();
                        Moves.CoordinatesReturn(cp);
                        return true;
                    }
                }

                Moves.EmptyCoordinates();
                Moves.CoordinatesReturn(cp);

                return false;
            }


            //potřebujeme kontrolu tahů - zda tam, kam táhneme, můžeme vůbec táhnout













            //zda je král vůbec na šachovnici - pro shogi
            public static bool KingOut()
            {
                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        if ((Board.board[i, j] != null) && (Board.board[i, j].GetNumber() == 0) && (GameCourse.WhitePlays == Board.board[i, j].isWhite))
                        {
                            return false;
                        }
                    }
                }
                return true;
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
