using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiCheckersChess
{
    public class Gameclass
    {
        public static class CurrentGame
        {
            public static GameType gameType;
            public static PlayerType playerType;

            public static bool GameEnded;


            //pro dámu, zda musí vzít určitou figurku
            public static bool MustTake()
            {
                Moves.CoordinatesCopy cp = Moves.MakeCopyEmpty();

                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        if ((Board.board[i, j] != null) && (Generating.WhitePlays == Board.board[i, j].isWhite))
                        {

                            //okej, tohle jsem si mohla zakomentovat. Asi tady vytvořím seznam tahů? 
                            bool musttake = Moves.CheckersTake(i, j, Board.board);
                            Moves.EmptyCoordinates();

                            if (musttake)
                            {

                                Moves.CoordinatesReturn(cp);
                                return true;
                            }
                        }
                    }
                }

                Moves.CoordinatesReturn(cp);
                return false;
            }

            public static bool MustTakeAI()
            {
                bool take = false;
                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        if ((Board.board[i, j] != null) && (Generating.WhitePlays == Board.board[i, j].isWhite))
                        {

                            Moves.CoordinatesCopy cp = Moves.MakeCopyEmpty();
                            bool musttake = Moves.CheckersTake(i, j, Board.board);

                            if (!musttake)
                            {

                                Moves.EmptyCoordinates();
                            }
                            else
                            {
                                take = true;
                            }
                            Moves.CoordinatesReturn(cp);

                        }
                    }
                }

                return take;
            }

            //zda v dámě má hráč figurky či už se nemůže hýbat
            public static bool CheckersEnd()
            {
                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        if ((Board.board[i, j] != null) && (Generating.WhitePlays == Board.board[i, j].isWhite))
                        {
                            Generating.Generate(Board.board[i, j], true, i, j);
                            if (Moves.final_x.Count != 0)
                            {
                                return false;
                            }
                        }
                    }
                }

                return true;
            }

            //na konci tahu řekne zda šach či ne
            public static bool KingCheck()
            {
                Moves.CoordinatesCopy cp = Moves.MakeCopyEmpty();

                bool[,] board = new bool[Board.board.GetLength(0), Board.board.GetLength(1)];

                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        if ((Board.board[i, j] != null) && (Board.board[i, j].isWhite == Generating.WhitePlays))
                        {
                            Generating.GenerateMoves(Board.board[i, j], false, i, j);
                        }
                    }
                }

                for (int i = 0; i < Moves.final_x.Count; i++)
                {
                    Pieces piece = Board.board[Moves.final_x[i], Moves.final_y[i]];
                    if ((piece != null) && ((piece.GetNumber() == 0) || (piece.GetNumber() == 21)) && (Generating.WhitePlays != piece.isWhite))
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

            //kontrola šachu matu?
            //provádí se jen v případě, že je šach
            //zkusím využít té featury programu, že se vygenerují pouze tahy, které jsou možné udělat
            //takže pokud se nám nepodaří vygenerovat žádný tah pro žádnou figurku, je to šach mat
            public static bool CheckMate()
            {
                Moves.CoordinatesCopy cp = Moves.MakeCopyEmpty();

                Generating.WhitePlays = !Generating.WhitePlays;

                //teď musíme pohnout každou (naší) figurkou... a zjišťovat zda se změní šach mat...   
                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        if ((Board.board[i, j] != null) && (Generating.WhitePlays == Board.board[i, j].isWhite))
                        {
                            Generating.Generate(Board.board[i, j], true, i, j);

                            if (Moves.final_x.Count != 0)
                            {
                                Generating.WhitePlays = !Generating.WhitePlays;
                                return false;
                            }

                        }
                    }
                }

                //žádný způsob jak se vynout šachu jsme nezjistili, končíme hru
                Generating.WhitePlays = !Generating.WhitePlays;
                return true;
            }

            //zda je král vůbec na šachovnici - pro shogi
            public static bool KingOut()
            {
                bool OneKing = false;
                bool SecondKing = false;
                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        if ((Board.board[i, j] != null) && (Board.board[i, j].GetNumber() == 7))
                        {
                            OneKing = true;
                        }
                        if ((Board.board[i, j] != null) && (Board.board[i, j].GetNumber() == 28))
                        {
                            SecondKing = true;
                        }
                    }
                }
                if ((!OneKing)||(!SecondKing))
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
