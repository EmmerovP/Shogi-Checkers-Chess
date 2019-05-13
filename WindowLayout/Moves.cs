using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//tohle je vlastně už vnitřní záležitost, ne windowlayout

namespace WindowLayout
{
    //reprezentace chessboard - 0 pokud na políčku nic není
    public static class Lists
    {

    }


    public static class Moves
    {
        //problémy s pairy: C# moc pairy nemá... U každé souřadnice bych musela vytvářet nový objekt, což je něco, čemu jsem se chtěla vyhnout :(
        //a co začátek tahu? Asi bych zase tahy musela reprezentovat 

        //public static Tuple<List<int>, List<int>> final = new Tuple<List<int>, List<int>>(new List<int>(), new List<int>());

        //public static List<List<int>> start = new List<List<int>>();

        public static List<int> final_x = new List<int>();
        public static List<int> final_y = new List<int>();

        public static List<int> start_x = new List<int>();
        public static List<int> start_y = new List<int>();


        public static void EmptyCoordinates()
        {
            final_x.Clear();
            final_y.Clear();

            start_x.Clear();
            start_y.Clear();
        }

        public static bool enemyMet = false;
        //okej, pokud bych pracovala s polem objektů, stačí poslední nulu asi přepsat na null
        public static bool ValidMove(int x, int y, Pieces[,] chessboard)
        {
            int height = chessboard.GetLength(0);
            int width = chessboard.GetLength(1);
            if ((x < 0) || (y < 0))
                return false;
            if ((x >= height) || (y >= width))
                return false;
            if (chessboard[x, y] != null)
            {
                if (enemyMet == false)
                {
                    if (chessboard[x, y].isWhite == !GameCourse.WhitePlays)
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

        //nekonečno do každého směru
        //možná z toho udělám třídy - definování custom figurek
        //nebo taky ne, nevím moc co s tím, tohle se mi zdá srozumitelnější? Ifové/case podmínky na vytvoření custom figurky
        public static void ForwardInfinity(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;


            x--;
            while (Moves.ValidMove(x, y, chessboard))
            {
                //konstruktor
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);
                x--;
            }

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
        }


        //jeden krok do každého směru
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
        }


        //tah pro koně - ten první je pro koně v shogi, po doplnění se zbytkem tahů se z toho stane kůň v šachách
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

            if (ValidMove(x - 2, y - 1, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x - 2);
                final_y.Add(y - 1);
            }
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

            if (ValidMove(x + 2, y - 1, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x + 2);
                final_y.Add(y - 1);
            }
        }
        //zbytek tahů pro šachy

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

            if (ValidMove(x - 1, y - 2, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x - 1);
                final_y.Add(y - 2);
            }

            if (ValidMove(x - 1, y + 2, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x - 1);
                final_y.Add(y + 2);
            }

            if (ValidMove(x + 1, y + 2, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x + 1);
                final_y.Add(y + 2);
            }

            if (ValidMove(x + 2, y + 1, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x + 2);
                final_y.Add(y + 1);
            }

            if (ValidMove(x + 2, y - 1, chessboard))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x + 2);
                final_y.Add(y - 1);
            }
        }

        //tady budou tahy, co se provádějí speciálně při vyhození figurky
        //dáma - o dvě políčka šikmo, pěšec šikmo... Nojo, ale nedaly by se použít tahy běžné? Již napsané výše?

        public static void CheckersTake(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            if ((chessboard[x + 1, y + 1] != null) && (ValidMove(x + 2, y + 2, chessboard)))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x + 2);
                final_y.Add(y + 2);
            }

            if ((chessboard[x + 1, y - 1] != null) && (ValidMove(x + 2, y - 2, chessboard)))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x + 2);
                final_y.Add(y - 2);
            }

            if ((chessboard[x - 1, y + 1] != null) && (ValidMove(x - 2, y + 2, chessboard)))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x - 2);
                final_y.Add(y + 2);
            }

            if ((chessboard[x - 1, y - 1] != null) && (ValidMove(x - 2, y - 2, chessboard)))
            {
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);

                final_x.Add(x - 2);
                final_y.Add(y - 2);
            }
        }

        //vyhazování dolních pěšců
        public static void SkewForward(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            if (ValidMove(x-1, y-1, chessboard))
            {
                if (chessboard[x - 1, y - 1] != null)
                {
                    start_x.Add(x_starting_pos);
                    start_y.Add(y_starting_pos);

                    final_x.Add(x - 1);
                    final_y.Add(y - 1);
                }
            }

            if (ValidMove(x-1, y+1, chessboard))
            {
                if (chessboard[x - 1, y + 1] != null)
                {
                    start_x.Add(x_starting_pos);
                    start_y.Add(y_starting_pos);

                    final_x.Add(x - 1);
                    final_y.Add(y + 1);
                }
            }

        }

        //horních 
        public static void SkewBackward(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            if (ValidMove(x+1, y+1, chessboard))
            {
                if (chessboard[x + 1, y + 1] != null)
                {
                    start_x.Add(x_starting_pos);
                    start_y.Add(y_starting_pos);

                    final_x.Add(x + 1);
                    final_y.Add(y + 1);
                }
            }

            if (ValidMove(x+1, y-1, chessboard))
            {
                if (chessboard[x + 1, y - 1] != null)
                {
                    start_x.Add(x_starting_pos);
                    start_y.Add(y_starting_pos);

                    final_x.Add(x + 1);
                    final_y.Add(y - 1);
                }
            }
        }

        // o dvě pole dopředu - pro první pozici pěšců
        public static void TwoForward(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            x--;
            if (ValidMove(x, y, chessboard))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);
            }

            if (x != (chessboard.GetLength(0) - 3))
                return;

            x--;
            if (ValidMove(x, y, chessboard))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);
            }
        }

        public static void TwoBackward(int x, int y, Pieces[,] chessboard)
        {
            int x_starting_pos = x;
            int y_starting_pos = y;

            x++;
            if (ValidMove(x, y, chessboard))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);
            }

            if (x != 2)
                return;

            x++;
            if (ValidMove(x, y, chessboard))
            {
                final_x.Add(x);
                final_y.Add(y);
                start_x.Add(x_starting_pos);
                start_y.Add(y_starting_pos);
            }
        }
    }
}
