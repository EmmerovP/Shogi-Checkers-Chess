using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiCheckersChess
{
    class RandomMoveGen
    {
        public static bool WhiteSide = false;

        public static int PickMove()
        {
            int pos;

            Moves.EmptyCoordinates();

            while (Moves.final_x.Count == 0)
            {
                pos = FindPiece();
            }

            Random rnd = new Random();
            pos = rnd.Next(Moves.start_x.Count);

            Board.board[Moves.final_x[pos], Moves.final_y[pos]] = Board.board[Moves.start_x[pos], Moves.start_y[pos]];
            Board.board[Moves.start_x[pos], Moves.start_y[pos]] = null;

            return pos;
        }

        public static int FindPiece()
        {
            List<Pieces> pieces = new List<Pieces>();
            List<int> x = new List<int>();
            List<int> y = new List<int>();

            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(0); j++)
                {
                    if ((Board.board[i, j] != null) && (Board.board[i, j].isWhite == WhiteSide))
                    {
                        pieces.Add(Board.board[i, j]);
                        x.Add(i);
                        y.Add(j);
                    }
                }
            }

            Random rnd = new Random();
            int pos = rnd.Next(pieces.Count - 1);

            Generating.GenerateMoves(pieces[pos], true, x[pos], y[pos]);
            return pos;
        }
    }
}
