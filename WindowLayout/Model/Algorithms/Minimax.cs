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

        /// <summary>
        /// Returns highest number of a list of integers.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int GetHighestValue(List<int> list)
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

        /// <summary>
        /// Returns list of indexes of a given list which contains a specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<int> GetAllIndexes(int value, List<int> list)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == value)
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }



        /// <summary>
        /// One step of a minimax algorithm.
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <param name="isMaxing"></param>
        /// <returns></returns>
        public static int OneStep(int depth, int alpha, int beta, bool isMaxing)
        {

            if (depth == 0)
            {
                return EvaluateChessboard();
            }

            Generating.GenerateAllMoves(Board.board, false, false);

            int eval;

            if (isMaxing)
            {
                eval = Int32.MinValue;
            }
            else
            {
                eval = Int32.MaxValue;
            }
            
            if (Moves.final_x.Count != 0)
            {
                var cp = Moves.MakeCopyEmpty();
                Generating.WhitePlays = !Generating.WhitePlays;
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
                        eval = Math.Max(OneStep(depth - 1, alpha, beta, false), eval);
                    }
                    else
                    {
                        eval = Math.Min(OneStep(depth - 1, alpha, beta, true), eval);
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


        /// <summary>
        /// Evaluates chessboard for minimax algorithm.
        /// </summary>
        /// <returns></returns>
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

        public static bool isAddingPiece;
        public static Pieces AddingPiece;


        /// <summary>
        /// Gets a next move for minimax algorithm.
        /// </summary>
        /// <returns></returns>
        public static int GetNextMove()
        {
            bool WhoPlays = Generating.WhitePlays;
            isAddingPiece = false;

            Generating.CheckersTake = false;
            Moves.EmptyCoordinates();

            List<int> choice = new List<int>();

            Generating.GenerateAllMoves(Board.board, true, false);

            Generating.WhitePlays = !Generating.WhitePlays;

            var moves = Moves.MakeCopyEmpty();


            //skončili jsme

            if (moves.final_x.Count == 0)
            {
                return -1;
            }

            for (int i = 0; i < moves.final_x.Count; i++)
            {
                MoveController.ApplyMove(moves.start_x[i], moves.start_y[i], moves.final_x[i], moves.final_y[i], Board.board);
                var piece = MoveController.takenPiece;
                int taken_x = MoveController.taken_x;
                int taken_y = MoveController.taken_y;
                bool isCastling = MoveController.isCastling;
                var movedPiece = MoveController.moved;


                choice.Add(Minimax.OneStep(3, Int32.MinValue, Int32.MaxValue, false));




                MoveController.ReapplyMove(moves.start_x[i], moves.start_y[i], moves.final_x[i], moves.final_y[i], piece, taken_x, taken_y, isCastling, movedPiece, Board.board);

            }

            int normalMoves = moves.final_x.Count;

            List<Pieces> removePieces = new List<Pieces>();

            if ((Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi) && (MainGameWindow.shogiAIPieces.Count != 0))
            {
                List<Pieces> availablePieces = new List<Pieces>();
                availablePieces.AddRange(MainGameWindow.shogiAIPieces);

                foreach (var piece in availablePieces)
                {
                    for (int i = 0; i < Board.board.GetLength(0); i++)
                    {
                        for (int j = 0; j < Board.board.GetLength(1); j++)
                        {
                            if (Board.board[i, j] == null)
                            {
                                if (piece.Name == "Shogi pěšák")
                                {
                                    //koukni jestli ve sloupečku již není pěšák, můžeš to udělat tou funkcí co už máš
                                    if (PawnColumn(j))
                                    {
                                        break;
                                    }

                                }

                                Board.board[i, j] = piece;
                                Board.board[i, j].isWhite = false;
                                MainGameWindow.shogiAIPieces.Remove(piece);

                                choice.Add(Minimax.OneStep(2, Int32.MinValue, Int32.MaxValue, false));

                                moves.final_x.Add(i);
                                moves.final_y.Add(j);

                                moves.start_x.Add(PiecesNumbers.getUpperNumber[piece.Name]);
                                removePieces.Add(piece);

                                MainGameWindow.shogiAIPieces.Add(piece);
                                Board.board[i, j] = null;
                            }
                        }
                    }
                }
            }

            Generating.WhitePlays = WhoPlays;

            //pokud je nějaký tah možný, vyber nějaký s největší hodnotou a posuň tam figurku

            Random rnd = new Random();
            Moves.EmptyCoordinates();
            Moves.CoordinatesReturn(moves);

            int highest = GetHighestValue(choice);
            var indexes = GetAllIndexes(highest, choice);
            int move = rnd.Next(indexes.Count);
            int pos = indexes[move];

            if (pos >= Moves.start_y.Count)
            {
                isAddingPiece = true;
                MainGameWindow.shogiAIPieces.Remove(removePieces[pos - Moves.start_y.Count]);
            }

            return pos;



        }


        /// <summary>
        /// Check whether it is okay to put a shogi pawn in specified column.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static bool PawnColumn(int column)
        {
            for (int i = 0; i < Board.board.GetLength(1); i++)
            {
                if ((Board.board[i, column] != null) && ((Board.board[i, column].GetNumber() == 40) || (Board.board[i, column].GetNumber() == 41)))
                {
                    return true;
                }

            }
            return false;
        }

    }
}
