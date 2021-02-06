using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShogiCheckersChess
{
    //shogi-propagace
    //šachy - změna pěšce při dojití na konec


    public class RandomMoveGen
    {
        public static List<int> HighestIndexes(int highest, List<int> list)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == highest)
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

        public static int Highest(List<int> list)
        {
            int highest = Int32.MinValue;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > highest)
                {
                    highest = list[i];
                }
            }
            return highest;
        }
        public static int FindPiece()
        {
            bool WhoPlays = Generating.WhitePlays;

            Generating.CheckersTake = false;
            Moves.EmptyCoordinates();

            //Vygenerujeme možné tahy na momentální šachovnici
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(0); j++)
                {
                    if ((Board.board[i, j] != null) && (Board.board[i, j].isWhite == Generating.WhitePlays))
                    {
                        Generating.Generate(Board.board[i, j], false, i, j);
                    }
                }
            }

            Generating.WhitePlays = !Generating.WhitePlays;

            var moves = Moves.MakeCopyEmpty();

            //skončili jsme

            if (moves.final_x.Count == 0)
            {
                return -1;
            }

            for (int i = 0; i < moves.final_x.Count; i++)
            {
                var final_piece = Board.board[moves.final_x[i], moves.final_y[i]];
                Board.board[moves.final_x[i], moves.final_y[i]] = Board.board[moves.start_x[i], moves.start_y[i]];
                Board.board[moves.start_x[i], moves.start_y[i]] = null;

                moves.value[i] = (Minimax.OneStepMin(2, Int32.MinValue, Int32.MaxValue));

                Board.board[moves.start_x[i], moves.start_y[i]] = Board.board[moves.final_x[i], moves.final_y[i]];
                Board.board[moves.final_x[i], moves.final_y[i]] = final_piece;
            }

            Generating.WhitePlays = WhoPlays;

            //pokud je nějaký tah možný, vyber nějaký s největší hodnotou a posuň tam figurku

            Random rnd = new Random();
            Moves.EmptyCoordinates();
            Moves.CoordinatesReturn(moves);

            int highest = Highest(moves.value);
            var indexes = HighestIndexes(highest, moves.value);
            int move = rnd.Next(indexes.Count);

            int pos = indexes[move];
            return pos;



        }
    }
}
