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

        public static int FindPiece()
        {
            Moves.EmptyCoordinates();

            //vygeneruj všechny možný tahy

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

            //pokud je nějaký tah možný, vyber nějaký s největší hodnotou a posuň tam figurku
            if (Moves.final_x.Count != 0)
            {
                //Random rnd = new Random();
                HighestNumber();

                int pos = Moves.value.IndexOf(CurrentHighest);
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
