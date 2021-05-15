using System;
using System.Collections.Generic;

namespace ShogiCheckersChess
{
    /// <summary>
    /// Class taking care of a minimax algorithm, which traverses through a game tree and evaluates leaves by pieces on board
    /// </summary>
    public class Minimax
    {

        /// <summary>
        /// Whether currently plays white or black side. When white plays, it's true.
        /// </summary>
        public static bool WhiteSide = false;

        /// <summary>
        /// Signalizes whether minimax generated a move where we only add a piece to the board.
        /// </summary>
        public static bool isAddingPiece;

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

            Generating.GenerateAllMoves(Board.board, false);

            //when we can't make a move, we return evaluated chessboard
            if (Moves.GetCount() == 0)
            {
                return EvaluateChessboard();
            }

            int evaluation;

            if (isMaxing)
            {
                evaluation = Int32.MinValue;
            }
            else
            {
                evaluation = Int32.MaxValue;
            }

            //create a copy of generated moves
            var moves = Moves.MakeCopyEmptyCoordinates();

            //switch sides of the game
            Generating.WhitePlays = !Generating.WhitePlays;

            //iterate through generated moves
            for (int k = 0; k < moves.GetCount(); k++)
            {

                //apply given move and remember parameters needed to re-do the move
                MoveController.ApplyMove(moves.start_x[k], moves.start_y[k], moves.final_x[k], moves.final_y[k], Board.board);
                int piece = -1;
                if (MoveController.takenPiece != null)
                {
                    piece = MoveController.takenPiece.GetNumber();
                }
                int taken_x = MoveController.taken_x;
                int taken_y = MoveController.taken_y;
                bool isCastling = MoveController.isCastling;
                int previousPiece = MoveController.previousPiece;


                //depending on whether we are in the maxing or minimazing state, get according evaluation
                if (isMaxing)
                {
                    evaluation = Math.Max(OneStep(depth - 1, alpha, beta, false), evaluation);
                }
                else
                {
                    evaluation = Math.Min(OneStep(depth - 1, alpha, beta, true), evaluation);
                }

                //revert move
                MoveController.ReapplyMove(moves.start_x[k], moves.start_y[k], moves.final_x[k], moves.final_y[k], piece, taken_x, taken_y, isCastling, Board.board, previousPiece);


                //alpha-beta pruning
                if (isMaxing)
                {
                    alpha = Math.Max(alpha, evaluation);
                }
                else
                {
                    beta = Math.Min(beta, evaluation);
                }


                if (beta <= alpha)
                {
                    break;
                }

            }

            Generating.WhitePlays = !Generating.WhitePlays;

            return evaluation;
        }

        /// <summary>
        /// Evaluates chessboard for minimax algorithm.
        /// </summary>
        /// <returns></returns>
        public static int EvaluateChessboard()
        {
            int evaluation = 0;

            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(1); j++)
                {

                    if (Board.board[i, j] != null)
                    {
                        if (Board.board[i, j].isWhite != WhiteSide)
                        {
                            evaluation -= Board.board[i, j].Value;
                        }
                        else
                        {
                            evaluation += Board.board[i, j].Value;
                        }


                    }
                }
            }

            return evaluation;
        }

        /// <summary>
        /// Tries to add piece to see what happens in minimax algorithm.
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="moves"></param>
        /// <param name="removePieces"></param>
        public static void TryToAddPiece(List<int> choice, Moves.CoordinatesCopy moves, List<Pieces> removePieces)
        {
            if (((MainGameWindow.shogiAIPieces.Count == 0)&&(!WhiteSide)) || ((MainGameWindow.whiteShogiAIPieces.Count == 0) && (WhiteSide)))
            {
                return;
            }

            //create copy of available pieces we can put on a board, so we don't have an inconsistency during going through the list
            List<Pieces> availablePieces = new List<Pieces>();

            if (WhiteSide)
            {
                availablePieces.AddRange(MainGameWindow.whiteShogiAIPieces);
            }
            else
            {
                availablePieces.AddRange(MainGameWindow.shogiAIPieces);
            }           

            foreach (var piece in availablePieces)
            {
                for (int i = 0; i < Board.board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.board.GetLength(1); j++)
                    {
                        if (Board.board[i, j] == null)
                        {
                            //we can't put another shogi pawn to the column where there already is
                            if (PiecesNumbers.IsShogiPawn(piece))
                            {
                                if (PawnColumn(j, WhiteSide))
                                {
                                    break;
                                }

                            }

                            //add piece on board
                            if (WhiteSide)
                            {
                                Board.AddPiece(PiecesNumbers.getBottomNumber[piece.Name], i, j, Board.board);
                                Board.board[i, j].isWhite = true;
                                MainGameWindow.whiteShogiAIPieces.Remove(piece);
                            }
                            else
                            {
                                Board.AddPiece(PiecesNumbers.getUpperNumber[piece.Name], i, j, Board.board);
                                Board.board[i, j].isWhite = false;
                                MainGameWindow.shogiAIPieces.Remove(piece);
                            }



                            choice.Add(Minimax.OneStep(2, Int32.MinValue, Int32.MaxValue, false));

                            moves.final_x.Add(i);
                            moves.final_y.Add(j);


                            if (WhiteSide)
                            {
                                moves.start_x.Add(PiecesNumbers.getBottomNumber[piece.Name]);
                                removePieces.Add(piece);

                                MainGameWindow.whiteShogiAIPieces.Add(piece);
                            }
                            else
                            {
                                moves.start_x.Add(PiecesNumbers.getUpperNumber[piece.Name]);
                                removePieces.Add(piece);

                                MainGameWindow.shogiAIPieces.Add(piece);
                            }

                            Board.board[i, j] = null;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Gets a next move for minimax algorithm.
        /// </summary>
        /// <returns></returns>
        public static int GetNextMove()
        {
            //remember current player
            bool WhoPlays = Generating.WhitePlays;

            //set bool for signalizing of piece addition to default value
            isAddingPiece = false;

            Moves.EmptyCoordinates();

            List<int> possibleMovesEvaluation = new List<int>();

            Generating.GenerateAllMoves(Board.board, true);

            //switch sides for nex move
            Generating.WhitePlays = !Generating.WhitePlays;

            //create a copy of generated moves
            var moves = Moves.MakeCopyEmptyCoordinates();

            //when there are no moves, the game is over
            if (moves.GetCount() == 0)
            {
                return -1;
            }

            for (int i = 0; i < moves.GetCount(); i++)
            {
                //apply given move and remember parameters needed to re-do the move
                MoveController.ApplyMove(moves.start_x[i], moves.start_y[i], moves.final_x[i], moves.final_y[i], Board.board);

                int piece = -1;
                if (MoveController.takenPiece != null)
                {
                    piece = MoveController.takenPiece.GetNumber();
                }
                int taken_x = MoveController.taken_x;
                int taken_y = MoveController.taken_y;
                bool isCastling = MoveController.isCastling;
                int previousPiece = MoveController.previousPiece;

                //run minimax algorithm for each move
                possibleMovesEvaluation.Add(Minimax.OneStep(4   , Int32.MinValue, Int32.MaxValue, false));

                //depending on whether we are in the maxing or minimazing state, get according evaluation
                MoveController.ReapplyMove(moves.start_x[i], moves.start_y[i], moves.final_x[i], moves.final_y[i], piece, taken_x, taken_y, isCastling, Board.board, previousPiece);

            }

            //segment for adding pieces to the chessboard
            List<Pieces> removePieces = new List<Pieces>();

            TryToAddPiece(possibleMovesEvaluation, moves, removePieces);

            //we finished generating moves, so we can return the value of who plays
            Generating.WhitePlays = WhoPlays;

            Random random = new Random();

            //we return generated moves to main lists, so we can access them even from outside
            Moves.EmptyCoordinates();
            Moves.CoordinatesReturn(moves);

            //there can be multiple moves with highest value, so we randomly pick one
            int highestEvaluation = GetHighestValue(possibleMovesEvaluation);
            List<int> indexesOfHighestValues = GetAllIndexes(highestEvaluation, possibleMovesEvaluation);
            int move = random.Next(indexesOfHighestValues.Count);
            int randomIndexOfHighestValue = indexesOfHighestValues[move];

            //checks if we are trying to add a piece to board, signalizes
            if (IsTryingToAddPiece(randomIndexOfHighestValue))
            {
                isAddingPiece = true;

                if (WhiteSide)
                {
                    MainGameWindow.whiteShogiAIPieces.Remove(removePieces[randomIndexOfHighestValue - Moves.start_y.Count]);
                }
                else
                {
                    MainGameWindow.shogiAIPieces.Remove(removePieces[randomIndexOfHighestValue - Moves.start_y.Count]);
                }
                
            }

            return randomIndexOfHighestValue;

        }

        /// <summary>
        /// Checks whether an index of preferred move is higher than all the items in start_y, because start_y coordinate isn't used when adding pieces
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool IsTryingToAddPiece(int index)
        {
            if (index >= Moves.start_y.Count)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check whether it is okay to put a shogi pawn in specified column.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static bool PawnColumn(int column, bool isWhite)
        {
            for (int i = 0; i < Board.board.GetLength(1); i++)
            {
                if (Board.board[i, column] != null && PiecesNumbers.IsShogiPawn(Board.board[i, column]) && Board.board[i, column].isWhite == isWhite)
                {
                    return true;
                }

            }
            return false;
        }

    }
}
