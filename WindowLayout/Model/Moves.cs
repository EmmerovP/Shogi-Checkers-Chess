using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiCheckersChess
{
    /// <summary>
    /// Class taking care of all possible piece movement, and storing generated moves.
    /// </summary>
    public static class Moves
    {

        //main lists used for storing generated moves coordinates for current game
        public static List<int> final_x = new List<int>();
        public static List<int> final_y = new List<int>();

        public static List<int> start_x = new List<int>();
        public static List<int> start_y = new List<int>();

        //class for storing a copy of main moves coordinates
        public class CoordinatesCopy
        {
            public List<int> final_x = new List<int>();
            public List<int> final_y = new List<int>();

            public List<int> start_x = new List<int>();
            public List<int> start_y = new List<int>();

            /// <summary>
            /// Returns count of items in list of moves coordinates.
            /// </summary>
            /// <returns>Count of items in final_x, final_y, and so.</returns>
            public int GetCount()
            {
                return final_x.Count;
            }
        }

        /// <summary>
        /// Returns count of items in list of moves coordinates.
        /// </summary>
        /// <returns>Count of items in final_x, final_y, and so.</returns>
        public static int GetCount()
        {
            return final_x.Count();
        }

        /// <summary>
        /// Clear all of main moves coordinates lists.
        /// </summary>
        public static void EmptyCoordinates()
        {
            final_x.Clear();
            final_y.Clear();

            start_x.Clear();
            start_y.Clear();

        }

        /// <summary>
        /// Remove element at specified index in all of move coordinates lists.
        /// </summary>
        /// <param name="i"></param>
        public static void RemoveAt(int i)
        {
            final_x.RemoveAt(i);
            final_y.RemoveAt(i);

            start_x.RemoveAt(i);
            start_y.RemoveAt(i);

        }

        /// <summary>
        /// Replace element in all move coordinates list for -1.
        /// </summary>
        /// <param name="index">index of replacement</param>
        public static void ReplaceAt(int index)
        {
            final_x[index] = -1;
            final_y[index] = -1;

            start_x[index] = -1;
            start_y[index] = -1;

        }

        /// <summary>
        /// Delete all occurences of value in move coordinates lists.
        /// </summary>
        /// <param name="index"></param>
        public static void Delete(int index)
        {
            final_x.RemoveAll(item => item == index);
            final_y.RemoveAll(item => item == index);

            start_x.RemoveAll(item => item == index);
            start_y.RemoveAll(item => item == index);

        }

        /// <summary>
        /// Return all coordinates from a specified copy of move coordinates to main lists.
        /// </summary>
        /// <param name="copy"></param>
        public static void CoordinatesReturn(CoordinatesCopy copy)
        {
            final_x.AddRange(copy.final_x);
            final_y.AddRange(copy.final_y);

            start_x.AddRange(copy.start_x);
            start_y.AddRange(copy.start_y);

        }

        /// <summary>
        /// Make copy of move coordinates and empty main lists.
        /// </summary>
        /// <returns></returns>
        public static CoordinatesCopy MakeCopyEmptyCoordinates()
        {
            CoordinatesCopy cp = new CoordinatesCopy();

            cp.final_x.AddRange(final_x);
            cp.final_y.AddRange(final_y);

            cp.start_x.AddRange(start_x);
            cp.start_y.AddRange(start_y);


            EmptyCoordinates();

            return cp;
        }

        /// <summary>
        /// Indicates whether we already met an enemy figure while generating move across multiple fields. We can stop generating the move then.
        /// </summary>
        public static bool enemyMet = false;
        
        /// <summary>
        /// Checks whether we can generate a move to this field.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="chessboard"></param>
        /// <returns></returns>
        public static bool ValidMove(int x, int y, Pieces[,] chessboard)
        {
            
            if (enemyMet == true)
                return false;


            //check the boundaries of a given chessboard
            int height = chessboard.GetLength(0);
            int width = chessboard.GetLength(1);

            if ((x < 0) || (y < 0))
                return false;
            if ((x >= height) || (y >= width))
                return false;

            //what to do when there is another piece in final destination
            if (chessboard[x, y] != null)
            {
                if (enemyMet == false)
                {
                    if (chessboard[x, y].isWhite == !Generating.WhitePlays)
                    {
                        enemyMet = true;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    enemyMet = false;
                    return false;
                }

            }
            enemyMet = false;
            return true;
        }

        public static void ForwardInfinity(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            x--;
            while (Moves.ValidMove(x, y, chessboard))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);
                x--;
            }
            enemyMet = false;
        }


        public static void LeftInfinity(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            y--;
            while (ValidMove(x, y, chessboard))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                y--;
            }
            enemyMet = false;
        }

        public static void RightInfinity(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            y++;
            while (ValidMove(x, y, chessboard))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                y++;
            }
            enemyMet = false;
        }

        public static void BackInfinity(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            x++;
            while (ValidMove(x, y, chessboard))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                x++;
            }
            enemyMet = false;
        }

        public static void ForwardLeftInfinity(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            x--;
            y--;
            while (ValidMove(x, y, chessboard))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);
                x--;
                y--;
            }
            enemyMet = false;
        }

        public static void BackLeftInfinity(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            x++;
            y--;
            while (ValidMove(x, y, chessboard))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                x++;
                y--;
            }
            enemyMet = false;
        }

        public static void ForwardRightInfinity(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            x--;
            y++;
            while (ValidMove(x, y, chessboard))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                x--;
                y++;
            }
            enemyMet = false;
        }

        public static void BackRightInfinity(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            x++;
            y++;
            while (ValidMove(x, y, chessboard))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                x++;
                y++;
            }
            enemyMet = false;
        }

        public static void Forward(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            x--;
            if (ValidMove(x, y, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y);

                final_x.Add(x);
                final_y.Add(y);

            }
            enemyMet = false;
        }

        public static void Left(int x, int y, Pieces[,] chessboard)
        {
            int y_starting_pos = y;
            y--;
            if (ValidMove(x, y, chessboard))
            {
                start_x.Add(x);
                start_y.Add(y_starting_pos);

                final_x.Add(x);
                final_y.Add(y);

            }
            enemyMet = false;
        }

        public static void Right(int x, int y, Pieces[,] chessboard)
        {
            int y_starting_pos = y;
            y++;
            if (ValidMove(x, y, chessboard))
            {
                start_x.Add(x);
                start_y.Add(y_starting_pos);

                final_x.Add(x);
                final_y.Add(y);

            }
            enemyMet = false;
        }

        public static void Back(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            x++;
            if (ValidMove(x, y, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y);

                final_x.Add(x);
                final_y.Add(y);

            }
            enemyMet = false;
        }

        public static void ForwardLeft(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;
            x--;
            y--;
            if (ValidMove(x, y, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x);
                final_y.Add(y);

            }
            enemyMet = false;
        }

        public static void BackLeft(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;
            x++;
            y--;
            if (ValidMove(x, y, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x);
                final_y.Add(y);

            }
            enemyMet = false;
        }

        public static void ForwardRight(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;
            x--;
            y++;
            if (ValidMove(x, y, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x);
                final_y.Add(y);

            }
            enemyMet = false;
        }

        public static void BackRight(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;
            x++;
            y++;
            if (ValidMove(x, y, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x);
                final_y.Add(y);

            }
            enemyMet = false;
        }

        public static void HorseForward(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            if (ValidMove(x - 2, y + 1, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x - 2);
                final_y.Add(y + 1);

            }
            enemyMet = false;

            if (ValidMove(x - 2, y - 1, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x - 2);
                final_y.Add(y - 1);

            }
            enemyMet = false;
        }

        public static void HorseBackward(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            if (ValidMove(x + 2, y + 1, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x + 2);
                final_y.Add(y + 1);

            }
            enemyMet = false;

            if (ValidMove(x + 2, y - 1, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x + 2);
                final_y.Add(y - 1);


            }
            enemyMet = false;
        }

        public static void Horse(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            if (ValidMove(x + 1, y - 2, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x + 1);
                final_y.Add(y - 2);

            }
            enemyMet = false;

            if (ValidMove(x - 1, y - 2, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x - 1);
                final_y.Add(y - 2);


            }
            enemyMet = false;

            if (ValidMove(x - 1, y + 2, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x - 1);
                final_y.Add(y + 2);

            }
            enemyMet = false;

            if (ValidMove(x + 1, y + 2, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x + 1);
                final_y.Add(y + 2);


            }
            enemyMet = false;

            if (ValidMove(x + 2, y + 1, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x + 2);
                final_y.Add(y + 1);


            }
            enemyMet = false;

            if (ValidMove(x + 2, y - 1, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x + 2);
                final_y.Add(y - 1);

            }
            enemyMet = false;
        }

        public static bool BlackCheckersTake(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            bool enemy = false;
            enemyMet = false;

            if ((ValidMove(x + 1, y + 1, chessboard)) && (Board.board[x + 1, y + 1] != null))
            {
                enemyMet = false;
                if ((ValidMove(x + 2, y + 2, chessboard)) && (Board.board[x + 2, y + 2] == null))
                {
                    start_x.Add(x_starting_pos);
                    start_y.Add(y_starting_pos);

                    final_x.Add(x + 2);
                    final_y.Add(y + 2);

                    enemy = true;
                }

                enemyMet = false;
            }

            if ((ValidMove(x + 1, y - 1, chessboard)) && (Board.board[x + 1, y - 1] != null))
            {
                enemyMet = false;
                if ((ValidMove(x + 2, y - 2, chessboard)) && (Board.board[x + 2, y - 2] == null))
                {
                    start_x.Add(x_starting_pos);
                    start_y.Add(y_starting_pos);

                    final_x.Add(x + 2);
                    final_y.Add(y - 2);


                    enemy = true;

                }
                enemyMet = false;

            }

            return enemy;
        }

        public static bool WhiteCheckersTake(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            bool enemy = false;
            enemyMet = false;

            if ((ValidMove(x - 1, y + 1, chessboard)) && (Board.board[x - 1, y + 1] != null))
            {
                enemyMet = false;
                if ((ValidMove(x - 2, y + 2, chessboard)) && (Board.board[x - 2, y + 2] == null))
                {
                    start_x.Add(x_starting_pos);
                    start_y.Add(y_starting_pos);

                    final_x.Add(x - 2);
                    final_y.Add(y + 2);

                    enemy = true;

                }
                enemyMet = false;

            }

            if ((ValidMove(x - 1, y - 1, chessboard)) && (Board.board[x - 1, y - 1] != null))
            {
                enemyMet = false;
                if ((ValidMove(x - 2, y - 2, chessboard)) && (Board.board[x - 2, y - 2] == null))
                {
                    start_x.Add(x_starting_pos);
                    start_y.Add(y_starting_pos);

                    final_x.Add(x - 2);
                    final_y.Add(y - 2);


                    enemy = true;

                }
            }

            return enemy;
        }

        public static bool BlackChecker(int x, int y, Pieces[,] chessboard)
        {

            int x_starting_pos = x;
            int y_starting_pos = y;

            bool enemy = false;


            if ((ValidMove(x + 1, y + 1, chessboard)) && (Board.board[x + 1, y + 1] == null))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x + 1);
                final_y.Add(y + 1);


            }
            enemyMet = false;

            if ((ValidMove(x + 1, y - 1, chessboard)) && (Board.board[x + 1, y - 1] == null))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x + 1);
                final_y.Add(y - 1);


            }
            enemyMet = false;

            return enemy;

        }

        public static bool WhiteChecker(int x, int y, Pieces[,] chessboard)
        {

            int x_starting_pos = x;
            int y_starting_pos = y;

            bool enemy = false;

            if ((ValidMove(x - 1, y - 1, chessboard)) && (Board.board[x - 1, y - 1] == null))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x - 1);
                final_y.Add(y - 1);


            }
            enemyMet = false;


            if ((ValidMove(x - 1, y + 1, chessboard)) && (Board.board[x - 1, y + 1] == null))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x - 1);
                final_y.Add(y + 1);

            }
            enemyMet = false;

            return enemy;

        }

        public static void PawnSkewForward(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            enemyMet = false;

            if (ValidMove(x - 1, y - 1, chessboard))
            {
                if (chessboard[x - 1, y - 1] != null)
                {
                    start_x.Add(x_starting_pos);
                    start_y.Add(y_starting_pos);

                    final_x.Add(x - 1);
                    final_y.Add(y - 1);


                }
            }
            enemyMet = false;

            if (ValidMove(x - 1, y + 1, chessboard))
            {
                if (chessboard[x - 1, y + 1] != null)
                {
                    start_x.Add(x_starting_pos);
                    start_y.Add(y_starting_pos);

                    final_x.Add(x - 1);
                    final_y.Add(y + 1);

                }
            }
            enemyMet = false;

        }

        public static void PawnSkewBackward(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            enemyMet = false;

            if (ValidMove(x + 1, y + 1, chessboard))
            {
                if (chessboard[x + 1, y + 1] != null)
                {
                    start_x.Add(x_starting_pos);
                    start_y.Add(y_starting_pos);

                    final_x.Add(x + 1);
                    final_y.Add(y + 1);

                }
            }
            enemyMet = false;

            if (ValidMove(x + 1, y - 1, chessboard))
            {
                if (chessboard[x + 1, y - 1] != null)
                {
                    start_x.Add(x_starting_pos);
                    start_y.Add(y_starting_pos);

                    final_x.Add(x + 1);
                    final_y.Add(y - 1);

                }
            }
            enemyMet = false;
        }

        public static void PawnTwoForward(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            x--;

            if ((ValidMove(x, y, chessboard)) && (Board.board[x, y] == null))
            {
                final_x.Add(x);
                final_y.Add(y);

                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);
            }
            else
            {
                return;
            }
            enemyMet = false;

            if (x != (chessboard.GetLength(0) - 3))
                return;

            x--;
            if ((ValidMove(x, y, chessboard)) && (Board.board[x, y] == null))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);
            }
            enemyMet = false;
        }

        public static void PawnTwoBackward(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            x++;
            if ((ValidMove(x, y, chessboard)) && (Board.board[x, y] == null))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);
            }
            else
            {
                return;
            }
            enemyMet = false;

            if (x != 2)
                return;

            x++;
            if ((ValidMove(x, y, chessboard)) && (Board.board[x, y] == null))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);
            }
            enemyMet = false;
        }

        public static void Castling(int x, int y, Pieces[,] chessboard)
        {
            if (chessboard[x, y].Moved)
            {
                return;
            }

            if (!(chessboard.GetLength(0) == 8 && chessboard.GetLength(1) == 8))
            {
                return;
            }

            //for bottom big castling
            if (x == 7 && y == 4
                    && chessboard[7, 0] != null
                    && chessboard[7, 0].Value == 50
                    && chessboard[7, 0].isWhite == chessboard[x, y].isWhite
                    && chessboard[7, 1] == null
                    && chessboard[7, 2] == null
                    && chessboard[7, 3] == null)
            {
                start_x.Add(x);
                start_y.Add(y);
                final_x.Add(x);
                final_y.Add(y - 2);
            }

            //for bottom small castling
            if (x == 7 && y == 4
                    && chessboard[7, 7] != null
                    && chessboard[7, 7].Value == 50
                    && chessboard[7, 7].isWhite == chessboard[x, y].isWhite
                    && chessboard[7, 6] == null
                    && chessboard[7, 5] == null)
            {
                start_x.Add(x);
                start_y.Add(y);
                final_x.Add(x);
                final_y.Add(y + 2);
            }

            //for upper big castling
            if (x == 0 && y == 4
                    && chessboard[0, 0] != null
                    && chessboard[0, 0].Value == 50
                    && chessboard[0, 0].isWhite == chessboard[x, y].isWhite
                    && chessboard[0, 1] == null
                    && chessboard[0, 2] == null
                    && chessboard[0, 3] == null)
            {
                start_x.Add(x);
                start_y.Add(y);
                final_x.Add(x);
                final_y.Add(y - 2);
            }

            //for upper small castling
            if (x == 0 && y == 4
                    && chessboard[0, 7] != null
                    && chessboard[0, 7].Value == 50
                    && chessboard[0, 7].isWhite == chessboard[x, y].isWhite
                    && chessboard[0, 6] == null
                    && chessboard[0, 5] == null)
            {
                start_x.Add(x);
                start_y.Add(y);
                final_x.Add(x);
                final_y.Add(y + 2);
            }
        }

        public static void BottomEnPassante(int x, int y, Pieces[,] chessboard)
        {
            if (chessboard.GetLength(0) < 5)
            {
                return;
            }

            if (x == 3)
            {
                if (y < chessboard.GetLength(1) - 1 && x > 0 && chessboard[x, y + 1] != null && chessboard[x, y + 1].GetNumber() == 26)
                {
                    start_x.Add(x);
                    start_y.Add(y);
                    final_x.Add(x - 1);
                    final_y.Add(y + 1);
                }

                if (y > 0 && x > 0 && chessboard[x, y - 1] != null && chessboard[x, y - 1].GetNumber() == 26)
                {
                    start_x.Add(x);
                    start_y.Add(y);
                    final_x.Add(x - 1);
                    final_y.Add(y - 1);
                }
            }
        }

        public static void UpperEnPassante(int x, int y, Pieces[,] chessboard)
        {
            if (chessboard.GetLength(0) < 5)
            {
                return;
            }

            if (x == chessboard.GetLength(0) - 4)
            {
                if (x < chessboard.GetLength(0) - 1 && y<chessboard.GetLength(1) - 1 && chessboard[x, y + 1] != null && chessboard[x, y + 1].GetNumber() == 5)
                {
                    start_x.Add(x);
                    start_y.Add(y);
                    final_x.Add(x + 1);
                    final_y.Add(y + 1);
                }

                if (x < chessboard.GetLength(0) - 1 && y>0 && chessboard[x, y - 1] != null && chessboard[x, y - 1].GetNumber() == 5)
                {
                    start_x.Add(x);
                    start_y.Add(y);
                    final_x.Add(x + 1);
                    final_y.Add(y - 1);
                }
            }
        }
    }
}
