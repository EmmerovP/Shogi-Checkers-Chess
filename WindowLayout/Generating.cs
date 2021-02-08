using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShogiCheckersChess
{
    public static class Generating
    {
        public static bool WhitePlays = true;

        public static bool CheckersTake = false;

        //vnitřní funkce, která jen vygeneruje tahy 

        public static void GenerateMoves(Pieces piece, bool delete, int x, int y)
        {


            CheckersTake = false;

            //musíme-li vzít figurku v dámě, nemůžeme povolit žádný jiný tah
            if ((Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers) && (Gameclass.CurrentGame.MustTakeCheckersPiece()))
            {
                    if (piece.Value == 10)
                    {
                        CheckersTake = true;
                        Moves.CheckersTake(x, y, Board.board);
                        return;
                    }
                    else
                    {
                        piece.GenerateMoves(x, y, Board.board);
                        var copied_coordinates = Moves.MakeCopyEmpty();
                        for (int i = 0; i < copied_coordinates.final_x.Count; i++)
                        {
                            if (Board.board[copied_coordinates.final_x[i], copied_coordinates.final_y[i]]!= null &&
                                Board.board[copied_coordinates.final_x[i], copied_coordinates.final_y[i]].isWhite != piece.isWhite)
                            {
                                Moves.final_x.Add(copied_coordinates.final_x[i]);
                                Moves.final_y.Add(copied_coordinates.final_y[i]);

                                Moves.start_x.Add(copied_coordinates.start_x[i]);
                                Moves.start_y.Add(copied_coordinates.start_y[i]);

                                Moves.value.Add(copied_coordinates.value[i]);
                            }
                        }
                        return;                                       
                    }
            }
            else
            {
                piece.GenerateMoves(x, y, Board.board);
            }

        }

        //main generating function
        public static void Generate(Pieces piece, bool delete, int x, int y)
        {
            //nejprve si smaže seznam tahů
            if (delete)
                Moves.EmptyCoordinates();

            int moves_start = Moves.final_x.Count; 

            GenerateMoves(piece, delete, x, y);

            //zamezíme tahům, které by nebyly validní, tzn. těm, co ohrozí vlastního krále
            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.chess)
            {
                WhitePlays = !WhitePlays;

                List<int> remove = new List<int>();

                //pro Aičko by se to tady asi ani nemuselo brát od nuly...
                for (int i = moves_start; i < Moves.final_x.Count; i++)
                {
                    Pieces takenpiece = Board.board[Moves.final_x[i], Moves.final_y[i]];
                    Board.board[Moves.final_x[i], Moves.final_y[i]] = Board.board[Moves.start_x[i], Moves.start_y[i]];
                    Board.board[Moves.start_x[i], Moves.start_y[i]] = null;




                    //kontrola šachu - do seznamu remove dá ty tahy, jež mají šach
                    if (Gameclass.CurrentGame.KingCheck())
                    {
                        remove.Add(i);
                    }


                    Board.board[Moves.start_x[i], Moves.start_y[i]] = Board.board[Moves.final_x[i], Moves.final_y[i]];
                    Board.board[Moves.final_x[i], Moves.final_y[i]] = takenpiece;
                }

                //removneme jak špatné tahy, tak jejich value pro aiščko
                for (int i = 0; i < remove.Count; i++)
                {
                    Moves.ReplaceAt(remove[i]);
                }

                Moves.Delete(-1);

                WhitePlays = !WhitePlays;
            }


        }

        public static bool UpperShogiPromotion(int x)
        {
            if ((x == Board.board.GetLength(1) - 3) || (x == Board.board.GetLength(1) - 1) || (x == Board.board.GetLength(1) - 2))
                return true;
            return false;
        }

        public static bool BottomShogiPromotion(int x)
        {
            if ((x == 0) || (x == 1) || (x == 2))
                return true;
            return false;
        }

        public static void MovePiece(int x, int y, int xpic, int ypic, Pieces pic, Label label)
        {


        }
        
    }

}

