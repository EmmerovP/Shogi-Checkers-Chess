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

        //vnitřní funkce, která jen vygeneruje tahy 

        public static void GenerateMoves(Pieces piece, bool delete, int x, int y)
        {
            //nejprve si smaže seznam tahů
            if (delete)
                Moves.EmptyCoordinates();

            piece.GenerateMoves(x, y, Board.board);
        }

        //main generating function
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

}

