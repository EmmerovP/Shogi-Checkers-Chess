using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/** kontrola stavů hry 
 */

namespace ShogiCheckersChess
{
    public class Gameclass
    {
        public static class CurrentGame
        {
            public static GameType gameType;
            public static PlayerType playerType;
            public static AlgorithmType algorithmType;

            public static bool GameEnded;


            //pro dámu, zda musí vzít určitou figurku
            public static bool MustTakeCheckersPiece()
            {
                Moves.CoordinatesCopy cp = Moves.MakeCopyEmpty();

                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        //pokud je to speciální žeton v dámě
                        if ((Board.board[i, j] != null) && (Generating.WhitePlays == Board.board[i, j].isWhite) && Board.board[i,j].Value == 10)
                        {
                            if (Generating.WhitePlays && Moves.WhiteCheckersTake(i, j, Board.board))
                            {
                                Moves.EmptyCoordinates();
                                Moves.CoordinatesReturn(cp);
                                return true;
                            }
                            else if (!Generating.WhitePlays && Moves.BlackCheckersTake(i,j, Board.board))
                            {
                                Moves.EmptyCoordinates();
                                Moves.CoordinatesReturn(cp);
                                return true;
                            }
                            

                        }
                        //pokud je to královna či jiná figurka co bere normálně
                        else if ((Board.board[i, j] != null) && (Generating.WhitePlays == Board.board[i, j].isWhite))
                        {
                            Board.board[i, j].GenerateMoves(i, j, Board.board);
                            for (int k = 0; k < Moves.start_x.Count; k++)
                            {
                                if (Board.board[Moves.final_x[k], Moves.final_y[k]] != null && Board.board[Moves.final_x[k], Moves.final_y[k]].isWhite != Board.board[i,j].isWhite)
                                {
                                    Moves.EmptyCoordinates();
                                    Moves.CoordinatesReturn(cp);
                                    return true;
                                }
                            }
                            

                        }
                    }
                }
                Moves.EmptyCoordinates();
                Moves.CoordinatesReturn(cp);
                return false;
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
                            Generating.Generate(Board.board[i, j], true, i, j, true);
                            if (Moves.final_x.Count != 0)
                            {
                                return false;
                            }
                        }
                    }
                }

                return true;
            }

            /*
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

            */



            



            //na konci tahu řekne zda šach či ne - z pohledu hrající strany na ddruhou stranu
            public static bool KingCheck()
            {
                Moves.CoordinatesCopy cp = Moves.MakeCopyEmpty();

                int x = 0, y = 0;
                //najdi krále dané strany
                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        Pieces piece = Board.board[i, j];
                        if ((piece != null) && ((piece.GetNumber() == 0) || (piece.GetNumber() == 21)) && (Generating.WhitePlays != piece.isWhite))
                        {
                            x = i;
                            y = j;
                            break;
                        }
                    }
                }

                //Koukneme se na krále jako na všechny tahy - zatím jako dáma a kůň
                Generating.WhitePlays = !Generating.WhitePlays;

                Moves.BackInfinity(x, y, Board.board);
                Moves.BackLeftInfinity(x, y, Board.board);
                Moves.BackRightInfinity(x, y, Board.board);
                Moves.ForwardInfinity(x, y, Board.board);
                Moves.ForwardLeftInfinity(x, y, Board.board);
                Moves.ForwardRightInfinity(x, y, Board.board);
                Moves.LeftInfinity(x, y, Board.board);
                Moves.RightInfinity(x, y, Board.board);
                Moves.Horse(x, y, Board.board);
                Moves.HorseBackward(x, y, Board.board);
                Moves.HorseForward(x, y, Board.board);

                Generating.WhitePlays = !Generating.WhitePlays;

                for (int i = 0; i < Moves.final_x.Count; i++)
                {
                    Pieces piece = Board.board[Moves.final_x[i], Moves.final_y[i]];
                    if ((piece != null) && (Generating.WhitePlays == piece.isWhite))
                    {

                        int x_coor = Moves.final_x[i];
                        int y_coor = Moves.final_y[i];

                        Moves.CoordinatesCopy copy = Moves.MakeCopyEmpty();

                        Board.board[x_coor, y_coor].GenerateMoves(x_coor, y_coor, Board.board);


                        for (int j = 0; j < Moves.final_x.Count; j++)
                        {
                            Pieces isKing = Board.board[Moves.final_x[j], Moves.final_y[j]];
                            if ((isKing != null) && ((isKing.GetNumber() == 0) || (isKing.GetNumber() == 21)) && (Generating.WhitePlays != isKing.isWhite))
                            {
                                Moves.EmptyCoordinates();
                                Moves.CoordinatesReturn(cp);

                                return true;
                            }
                        }
                        Moves.EmptyCoordinates();
                        Moves.CoordinatesReturn(copy);
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
                            Generating.Generate(Board.board[i, j], true, i, j, true);

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
            shogi
        }

        public enum PlayerType
        {
            single,
            localmulti,
            webmulti
        }

        public enum AlgorithmType
        {
            minimax,
            montecarlo
        }
    }
}
