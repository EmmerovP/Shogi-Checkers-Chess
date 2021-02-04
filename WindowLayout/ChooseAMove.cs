﻿using System;
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
        public static bool WhiteSide = false;


        //já nevím tohle jde asi líp...
        public static int CurrentHighest;



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

            if (depth == 0)
            {
                return EvaluateChessboard();
            }

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

            if (Moves.final_x.Count != 0)
            {
                //vykopírujeme si tahy
                var cp = Moves.MakeCopyEmpty();
                List<int> Evaluation = new List<int>();
                int eval = 0;
                //prohodíme strany na další tah
                Generating.WhitePlays = !Generating.WhitePlays;
                //tvoříme děti jednotlivých tahů
                for (int k = 0; k < cp.final_x.Count; k++)
                {
                    var piece = Board.board[cp.start_x[k], cp.start_y[k]];
                    var takenpiece = Board.board[cp.final_x[k], cp.final_y[k]];
                    Board.board[cp.final_x[k], cp.final_y[k]] = Board.board[cp.start_x[k], cp.start_y[k]];
                    Board.board[cp.start_x[k], cp.start_y[k]] = null;


                    eval = OneStepMax(depth - 1, alpha, beta);

                    Evaluation.Add(eval);

                    Board.board[cp.start_x[k], cp.start_y[k]] = piece;
                    Board.board[cp.final_x[k], cp.final_y[k]] = takenpiece;


                    //Tato možnost se zdá být velmi pomalá, ta druhá rychlá, ale na tak účinná
                    // alpha = Math.Max(beta, Evaluation[k]);
                    alpha = Math.Max(alpha, eval);

                    if (beta <= alpha)
                    {
                        break;
                    }

                }

                Generating.WhitePlays = !Generating.WhitePlays;

                return Highest(Evaluation);
            }

            return 0;

        }

        public static int EvaluateChessboard()
        {
            int eval = 0;
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(0); j++)
                {
                    if (Board.board[i, j] != null)
                    {
                        if (Board.board[i, j].isWhite == Generating.WhitePlays)
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
                for (int j = 0; j < Board.board.GetLength(0); j++)
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
                List<int> Evaluation = new List<int>();
                int eval = 0;
                //prohodíme strany na další tah
                Generating.WhitePlays = !Generating.WhitePlays;
                //tvoříme děti jednotlivých tahů
                for (int k = 0; k < cp.final_x.Count; k++)
                {
                    var piece = Board.board[cp.start_x[k], cp.start_y[k]];
                    var takenpiece = Board.board[cp.final_x[k], cp.final_y[k]];
                    Board.board[cp.final_x[k], cp.final_y[k]] = Board.board[cp.start_x[k], cp.start_y[k]];
                    Board.board[cp.start_x[k], cp.start_y[k]] = null;

                    eval = OneStepMax(depth - 1, alpha, beta);



                    Evaluation.Add(eval);

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

                return Lowest(Evaluation);
            }

            return 0;

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
            var Evaluations = new List<int>();

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

                moves.value[i] = (OneStepMin(2, Int32.MinValue, Int32.MaxValue));

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
            Board.board[Moves.final_x[pos], Moves.final_y[pos]] = Board.board[Moves.start_x[pos], Moves.start_y[pos]];
            Board.board[Moves.start_x[pos], Moves.start_y[pos]] = null;

            return pos;



        }
    }
}
