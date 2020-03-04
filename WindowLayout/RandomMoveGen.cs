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

        public static int FindPiece()
        {
            Moves.EmptyCoordinates();

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
            if (Moves.final_x.Count != 0)
            {
                Random rnd = new Random();
                int pos = rnd.Next(Moves.final_x.Count);
                Board.board[Moves.final_x[pos], Moves.final_y[pos]] = Board.board[Moves.start_x[pos], Moves.start_y[pos]];
                Board.board[Moves.start_x[pos], Moves.start_y[pos]] = null;

                return pos;
            }
            return -1;
        }
    }
}
