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

        public static void Generate(Pieces piece, bool delete, int x, int y)
        {
            //nejprve si smaže seznam tahů
            if (delete)
                Moves.EmptyCoordinates();
            piece.GenerateMoves(x, y, Board.board);
        }
    }



}

