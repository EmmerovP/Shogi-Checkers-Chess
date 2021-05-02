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
            public static bool MustTakeCheckersPiece(Pieces[,] Board)
            {
                Moves.CoordinatesCopy cp = Moves.MakeCopyEmptyCoordinates();

                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.GetLength(1); j++)
                    {
                        //pokud je to speciální žeton v dámě
                        if ((Board[i, j] != null) && (Generating.WhitePlays == Board[i, j].isWhite) && Board[i,j].Value == 10)
                        {
                            if (Generating.WhitePlays && Moves.WhiteCheckersTake(i, j, Board))
                            {
                                Moves.EmptyCoordinates();
                                Moves.CoordinatesReturn(cp);
                                return true;
                            }
                            else if (!Generating.WhitePlays && Moves.BlackCheckersTake(i,j, Board))
                            {
                                Moves.EmptyCoordinates();
                                Moves.CoordinatesReturn(cp);
                                return true;
                            }
                            

                        }
                        //pokud je to královna či jiná figurka co bere normálně
                        else if ((Board[i, j] != null) && (Generating.WhitePlays == Board[i, j].isWhite))
                        {
                            Board[i, j].GenerateMoves(i, j, Board);
                            for (int k = 0; k < Moves.start_x.Count; k++)
                            {
                                if (Board[Moves.final_x[k], Moves.final_y[k]] != null && Board[Moves.final_x[k], Moves.final_y[k]].isWhite != Board[i,j].isWhite)
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
            public static bool CheckersEnd(Pieces[,] Board)
            {
                for (int i = 0; i < Board.GetLength(0); i++)
                {   
                    for (int j = 0; j < Board.GetLength(1); j++)
                    {
                        if ((Board[i, j] != null) && (Generating.WhitePlays == Board[i, j].isWhite))
                        {
                            Generating.Generate(Board[i, j], true, i, j, true, Board);
                            if (Moves.final_x.Count != 0)
                            {
                                return false;
                            }
                        }
                    }
                }

                return true;
            }

            //na konci tahu řekne zda šach či ne - z pohledu hrající strany na ddruhou stranu
            public static bool KingCheck(Pieces[,] Board)
            {
                Moves.CoordinatesCopy cp = Moves.MakeCopyEmptyCoordinates();

                int x = 0, y = 0;
                //najdi krále dané strany
                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.GetLength(1); j++)
                    {
                        Pieces piece = Board[i, j];
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

                Moves.BackInfinity(x, y, Board);
                Moves.BackLeftInfinity(x, y, Board);
                Moves.BackRightInfinity(x, y, Board);
                Moves.ForwardInfinity(x, y, Board);
                Moves.ForwardLeftInfinity(x, y, Board);
                Moves.ForwardRightInfinity(x, y, Board);
                Moves.LeftInfinity(x, y, Board);
                Moves.RightInfinity(x, y, Board);
                Moves.Horse(x, y, Board);
                Moves.HorseBackward(x, y, Board);
                Moves.HorseForward(x, y, Board);

                Generating.WhitePlays = !Generating.WhitePlays;

                for (int i = 0; i < Moves.final_x.Count; i++)
                {
                    Pieces piece = Board[Moves.final_x[i], Moves.final_y[i]];
                    if ((piece != null) && (Generating.WhitePlays == piece.isWhite))
                    {

                        int x_coor = Moves.final_x[i];
                        int y_coor = Moves.final_y[i];

                        Moves.CoordinatesCopy copy = Moves.MakeCopyEmptyCoordinates();

                        Board[x_coor, y_coor].GenerateMoves(x_coor, y_coor, Board);


                        for (int j = 0; j < Moves.final_x.Count; j++)
                        {
                            Pieces isKing = Board[Moves.final_x[j], Moves.final_y[j]];
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
            public static bool CheckMate(Pieces[,] Board)
            {
                Moves.CoordinatesCopy cp = Moves.MakeCopyEmptyCoordinates();

                Generating.WhitePlays = !Generating.WhitePlays;

                //teď musíme pohnout každou (naší) figurkou... a zjišťovat zda se změní šach mat...   
                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.GetLength(1); j++)
                    {
                        if ((Board[i, j] != null) && (Generating.WhitePlays == Board[i, j].isWhite))
                        {
                            Generating.Generate(Board[i, j], true, i, j, true, Board);

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
            public static bool KingOut(Pieces[,] Board)
            {
                bool OneKing = false;
                bool SecondKing = false;
                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.GetLength(1); j++)
                    {
                        if ((Board[i, j] != null) && (Board[i, j].GetNumber() == 7))
                        {
                            OneKing = true;
                        }
                        if ((Board[i, j] != null) && (Board[i, j].GetNumber() == 28))
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
