using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiCheckersChess
{
    public class RandomMoveGen
    {
        public static bool WhiteSide = false;


        //já nevím tohle jde asi líp...
        public static int CurrentHighest;

        public static void Evaluate_moves()
        {

            Moves.CoordinatesCopy cp = Moves.MakeCopyEmpty();
            Generating.WhitePlays = !Generating.WhitePlays;

            for (int k = 0; k < cp.final_x.Count; k++)
            {

                Moves.EmptyCoordinates();

                var piece = Board.board[cp.start_x[k], cp.start_y[k]];
                //snažil by se tě někdo při udělání tohoto tahu vyhodit?
                var takenpiece = Board.board[cp.final_x[k], cp.final_y[k]];
                Board.board[cp.final_x[k], cp.final_y[k]] = Board.board[cp.start_x[k], cp.start_y[k]];
                Board.board[cp.start_x[k], cp.start_y[k]] = null;
                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        //potřebujeme enemáka
                        if ((Board.board[i, j] != null) && (Board.board[i, j].isWhite == Generating.WhitePlays))
                        {
                            Generating.GenerateMoves(Board.board[i, j], false, i, j);
                        }
                    }
                }

                //pokud je figurku možno vyhodit, uber hodnotu a breakni
                for (int i = 0; i < Moves.final_x.Count; i++)
                {
                    if ((Moves.final_x[i] == cp.final_x[k]) && (Moves.final_y[i] == cp.final_y[k]))
                    {
                        cp.value[k] = cp.value[k] - piece.Value;
                        break; 
                    }
                }

                Board.board[cp.start_x[k], cp.start_y[k]] = Board.board[cp.final_x[k], cp.final_y[k]];
                Board.board[cp.final_x[k], cp.final_y[k]] = takenpiece;
            }

            Generating.WhitePlays = !Generating.WhitePlays;

            Moves.EmptyCoordinates();
            Moves.CoordinatesReturn(cp);
        }

        public static void HighestNumber()
        {
            int highest = 0;
            for (int i = 0; i < Moves.value.Count; i++)
            {
                if (Moves.value[i] > highest)
                {
                    highest = Moves.value[i];
                }
            }
            CurrentHighest = highest;
        }

        //není něco v knihovně na tohle?
        public static bool isEqual(int a)
        {
            if (a == CurrentHighest)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<int> HighestIndexes()
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < Moves.value.Count; i++)
            {
                if (Moves.value[i] == CurrentHighest)
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

        public static int FindPiece()
        {
            Generating.CheckersTake = false;
            Moves.EmptyCoordinates();

            //vygeneruj všechny možný tahy, pokud je dáma  amusí se vzít figurka tak jen ty
            if (!((Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers) && (Gameclass.CurrentGame.MustTakeAI())))
            {
                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(0); j++)
                    {
                        if ((Board.board[i, j] != null) && (Board.board[i, j].isWhite == WhiteSide))
                        {
                            Generating.Generate(Board.board[i, j], false, i, j);
                        }
                    }
                }
            }
            else
            {
                Generating.CheckersTake = true;
            }


            //pokud je nějaký tah možný, vyber nějaký s největší hodnotou a posuň tam figurku
            if (Moves.final_x.Count != 0)
            {
                //Ohodnoď tahy z druhé strany
                if (!Generating.CheckersTake)
                {
                    Evaluate_moves();
                }


                Random rnd = new Random();
                HighestNumber();
                var indexes = HighestIndexes();
                int move = rnd.Next(indexes.Count);

                int pos = indexes[move];
                Board.board[Moves.final_x[pos], Moves.final_y[pos]] = Board.board[Moves.start_x[pos], Moves.start_y[pos]];
                Board.board[Moves.start_x[pos], Moves.start_y[pos]] = null;

                //vrať nějaké číslo
                return pos;
            }

            //žádný tah není možný - skončili jsme, vrať záporné číslo
            return -1;
        }
    }
}
