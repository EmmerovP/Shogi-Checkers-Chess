using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShogiCheckersChess
{

    public class Minimax
    {
        public static bool WhiteSide = false;


        //já nevím tohle jde asi líp...
        public static int CurrentHighest;

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



        public static int Lowest(List<int> list)
        {
            int lowest = Int32.MaxValue;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < lowest)
                {
                    lowest = list[i];
                }
            }
            return lowest;
        }




        public static int OneStepMax(int depth, int alpha, int beta)
        {

            if (depth == 0) //or terminal node? Jako kingcheck
            {
                return EvaluateChessboard();
            }

            //Vygenerujeme možné tahy na momentální šachovnici
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(1); j++)
                {
                    if ((Board.board[i, j] != null) && (Board.board[i, j].isWhite == Generating.WhitePlays))
                    {
                        Generating.Generate(Board.board[i, j], false, i, j);
                    }
                }
            }

            if (Moves.final_x.Count != 0)
            {
                //vykopírujeme si tahy
                var cp = Moves.MakeCopyEmpty();
                int eval = Int32.MinValue;
                //prohodíme strany na další tah
                Generating.WhitePlays = !Generating.WhitePlays;
                //tvoříme děti jednotlivých tahů
                for (int k = 0; k < cp.final_x.Count; k++)
                {
                    var piece = Board.board[cp.start_x[k], cp.start_y[k]];
                    var takenpiece = Board.board[cp.final_x[k], cp.final_y[k]];
                    Board.board[cp.final_x[k], cp.final_y[k]] = Board.board[cp.start_x[k], cp.start_y[k]];
                    Board.board[cp.start_x[k], cp.start_y[k]] = null;


                    eval = Math.Max(OneStepMin(depth - 1, alpha, beta), eval);

                    Board.board[cp.start_x[k], cp.start_y[k]] = piece;
                    Board.board[cp.final_x[k], cp.final_y[k]] = takenpiece;

                    

                    // alpha = Math.Max(beta, Evaluation[k]);
                    alpha = Math.Max(alpha, eval);

                    if (beta <= alpha)
                    {
                        break;
                    }

                }

                Generating.WhitePlays = !Generating.WhitePlays;

                return eval;
            }

            return 0;

        }

        public static int EvaluateChessboard()
        {
            int eval = 0;
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(1); j++)
                {

                    if (Board.board[i, j] != null)
                    {
                        
                        //spodní pěšec
                        if (Board.board[i, j].GetNumber() == 5)
                        {
                            if (WhiteSide)
                            {
                                eval += (Board.board.GetLength(0) - i / 3 );
                            }
                            else
                            {
                                eval -= ( Board.board.GetLength(0) - i / 3);
                            }
                        }

                        //vrchní pěšec
                        if (Board.board[i, j].GetNumber() == 40)
                        {
                            if (WhiteSide)
                            {
                                eval -= i/3;
                            }
                            else
                            {
                                eval += i/3;
                            }
                        }


                        if (Board.board[i, j].isWhite != WhiteSide)
                        {
                            eval -= Board.board[i, j].Value;
                        }
                        else
                        {
                            eval += Board.board[i, j].Value;
                        }


                    }
                }
            }

            
            return eval;
        }

        public static int OneStepMin(int depth, int alpha, int beta)
        {
            if (depth == 0)
            {
                return EvaluateChessboard();
            }

            //Vygenerujeme možné tahy na momentální šachovnici
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(1); j++)
                {
                    if ((Board.board[i, j] != null) && (Board.board[i, j].isWhite == Generating.WhitePlays))
                    {
                        Generating.Generate(Board.board[i, j], false, i, j);
                    }
                }
            }

            if (Moves.final_x.Count != 0)
            {
                //vykopírujeme si tahy
                var cp = Moves.MakeCopyEmpty();

                int eval = Int32.MaxValue;
                //prohodíme strany na další tah
                Generating.WhitePlays = !Generating.WhitePlays;
                //tvoříme děti jednotlivých tahů
                for (int k = 0; k < cp.final_x.Count; k++)
                {
                    var piece = Board.board[cp.start_x[k], cp.start_y[k]];
                    var takenpiece = Board.board[cp.final_x[k], cp.final_y[k]];
                    Board.board[cp.final_x[k], cp.final_y[k]] = Board.board[cp.start_x[k], cp.start_y[k]];
                    Board.board[cp.start_x[k], cp.start_y[k]] = null;

                    eval = Math.Min(eval, OneStepMax(depth - 1, alpha, beta));

                    Board.board[cp.start_x[k], cp.start_y[k]] = piece;
                    Board.board[cp.final_x[k], cp.final_y[k]] = takenpiece;

                    
                    //Tato možnost se zdá být velmi pomalá, ta druhá rychlá, ale na tak účinná
                    // beta = Math.Min(beta, Evaluation[k]);
                    beta = Math.Min(beta, eval);

                    if (beta <= alpha)
                    {
                        break;
                    } 
                    

                }

                Generating.WhitePlays = !Generating.WhitePlays;

                return eval;
            }

            return 0;

        }

    }
}
