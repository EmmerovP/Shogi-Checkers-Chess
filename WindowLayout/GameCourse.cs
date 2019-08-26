using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowLayout
{
    public static class GameCourse
    {
        public static bool WhitePlays = true;

        public static void PlayGame()
        {

        }

        public static void GenerateMoves(Pieces piece, bool delete, int x, int y)
        {
            //nejprve si smaže seznam tahů
            if (delete)
                Moves.EmptyCoordinates();

            piece.GenerateMoves(x, y, Board.board);
        }

        public static void Generate(Pieces piece, bool delete, int x, int y)
        {
            GenerateMoves(piece, delete, x, y);

            WhitePlays = !WhitePlays;

            List<int> remove = new List<int>();

            for (int i = 0; i < Moves.final_x.Count; i++)
            {
                Pieces takenpiece = Board.board[Moves.final_x[i], Moves.final_y[i]];
                Board.board[Moves.final_x[i], Moves.final_y[i]] = Board.board[Moves.start_x[i], Moves.start_y[i]];
                Board.board[Moves.start_x[i], Moves.start_y[i]] = null;

                if (Gameclass.CurrentGame.KingCheck())
                {
                    remove.Add(i);
                }

                Board.board[Moves.start_x[i], Moves.start_y[i]] = Board.board[Moves.final_x[i], Moves.final_y[i]];
                Board.board[Moves.final_x[i], Moves.final_y[i]] = takenpiece;
            }


            WhitePlays = !WhitePlays;

        }

    }

}

