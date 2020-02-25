using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiCheckersChess
{
    public static class Generating
    {
        public static bool WhitePlays = true;

        public static bool CheckersTake = false;

        public static void PlayGame()
        {

        }

        //vnitřní funkce, která jen vygeneruje tahy 

        public static void GenerateMoves(Pieces piece, bool delete, int x, int y)
        {
            //nejprve si smaže seznam tahů
            if (delete)
                Moves.EmptyCoordinates();

            CheckersTake = false;

            //musíme-li vzít figurku v dámě, nemůžeme povolit žádný jiný tah
            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers)
            {
                if (Gameclass.CurrentGame.MustTake())
                {
                    if (!Moves.CheckersTake(x, y, Board.board))
                    {
                        Moves.EmptyCoordinates();
                    }
                    else
                    {
                        CheckersTake = true;
                    }
                }
                else
                {
                    piece.GenerateMoves(x, y, Board.board);
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
            GenerateMoves(piece, delete, x, y);

            //zamezíme tahům, které by nebyly validní, tzn. těm, co ohrozí vlastního krále
            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.chess)
            {
                WhitePlays = !WhitePlays;

                List<int> remove = new List<int>();

                for (int i = 0; i < Moves.final_x.Count; i++)
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
            if ((x == Board.board.GetLength(1)) || (x == Board.board.GetLength(1) - 1) || (x == Board.board.GetLength(1) - 2))
                return true;
            return false;
        }

        public static bool BottomShogiPromotion(int x)
        {
            if ((x==0)||(x==1)||(x==2))
                return true;
            return false;
        }

        

    }

}

