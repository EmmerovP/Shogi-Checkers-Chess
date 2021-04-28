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

        public static int AddingPieces(int eval, int depth, int alpha, int beta, bool isMaxing)
        {
            List<Pieces> PiecesList;

            if (isMaxing)
            {
                PiecesList = MainGameWindow.shogiAIPieces;
            }
            else
            {
                PiecesList = MainGameWindow.shogiPlayerPieces;
            }

            if ((Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi) && (PiecesList.Count != 0))
            {
                List<Pieces> availablePieces = new List<Pieces>();
                availablePieces.AddRange(PiecesList);

                foreach (var piece in availablePieces)
                {
                    for (int i = 0; i < Board.board.GetLength(0); i++)
                    {
                        for (int j = 0; j < Board.board.GetLength(1); j++)
                        {
                            if (Board.board[i, j] == null)
                            {
                                Board.board[i, j] = piece;
                                Board.board[i, j].isWhite = false;
                                PiecesList.Remove(piece);

                                if (isMaxing)
                                {
                                    eval = Math.Max(eval, OneStepMax(depth - 1, alpha, beta, false));
                                }
                                else
                                {
                                    eval = Math.Min(eval, OneStepMax(depth - 1, alpha, beta, true));
                                }                             

                                PiecesList.Add(piece);
                                Board.board[i, j] = null;
                            }
                        }
                    }
                }
            }


            return eval;
        }




        public static int OneStepMax(int depth, int alpha, int beta, bool isMaxing)
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
                        Generating.Generate(Board.board[i, j], false, i, j, false, Board.board);
                    }
                }
            }

            int eval;

            if (isMaxing)
            {
                eval = Int32.MinValue;
                //eval = Math.Max(eval, AddingPieces(eval, depth, alpha, beta, isMaxing));
            }
            else
            {
                eval = Int32.MaxValue;
                //eval = Math.Min(eval, AddingPieces(eval, depth, alpha, beta, isMaxing));
            }
            




            if (Moves.final_x.Count != 0)
            {
                //vykopírujeme si tahy
                var cp = Moves.MakeCopyEmpty();
                //prohodíme strany na další tah
                Generating.WhitePlays = !Generating.WhitePlays;
                //tvoříme děti jednotlivých tahů
                for (int k = 0; k < cp.final_x.Count; k++)
                {
                    MoveController.ApplyMove(cp.start_x[k], cp.start_y[k], cp.final_x[k], cp.final_y[k], Board.board);
                    var piece = MoveController.takenPiece;
                    int taken_x = MoveController.taken_x;
                    int taken_y = MoveController.taken_y;
                    bool isCastling = MoveController.isCastling;
                    var movedPiece = MoveController.moved;


                    if (isMaxing)
                    {
                        eval = Math.Max(OneStepMax(depth - 1, alpha, beta, false), eval);
                    }
                    else
                    {
                        eval = Math.Min(OneStepMax(depth - 1, alpha, beta, true), eval);
                    }

                    MoveController.ReapplyMove(cp.start_x[k], cp.start_y[k], cp.final_x[k], cp.final_y[k], piece, taken_x, taken_y, isCastling, movedPiece, Board.board);


                    if (isMaxing)
                    {
                        alpha = Math.Max(alpha, eval);
                    }
                    else
                    {
                        beta = Math.Min(beta, eval);
                    }


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

    }
}
