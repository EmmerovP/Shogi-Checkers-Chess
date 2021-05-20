namespace ShogiCheckersChess
{
    /// <summary>
    /// Class for applying and reapplying moves on a board.
    /// </summary>
    public static class MoveController
    {
        /// <summary>
        /// x coordinate of a piece which needs to be deleted.
        /// </summary>
        public static int delete_x;

        /// <summary>
        /// y coordinate of a piece which needs to be deleted.
        /// </summary>
        public static int delete_y;


        /// <summary>
        /// Signalizes whether the ongoing move is castling.
        /// </summary>
        public static bool isCastling;

        //coordinates needed for castling
        public static int castling_x;
        public static int castling_y;
        public static int castling_z;

        /// <summary>
        /// Taken piece in out move
        /// </summary>
        public static Pieces takenPiece;

        /// <summary>
        /// x coordinate of taken piece, if none was taken, -1 is the value
        /// </summary>
        public static int taken_x;

        /// <summary>
        /// y coordinate of taken piece, if none was taken, -1 is the value
        /// </summary>
        public static int taken_y;

        /// <summary>
        /// Which piece was moved
        /// </summary>
        public static Pieces moved;

        /// <summary>
        /// True if the move changed the piece into another piece.
        /// </summary>
        public static bool pieceChanged;

        /// <summary>
        /// When piece changes, this variable remembers the state of it before it happened.
        /// </summary>
        public static int previousPiece;

        /// <summary>
        /// Changing pieces.
        /// Chess pawns can be changed when they are on the end of the board. They don't change automatically for user player, only when algorithm plays.
        /// Checker pieces change into queen at the end of the board automatically.
        /// Shogi pieces can be promoted. They don't change automatically for user player, only when algorithm plays.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="piece"></param>
        /// <returns></returns>
        public static void ChangePiece(int x, int y, Pieces piece, Pieces[,] board)
        {
            pieceChanged = false;
            previousPiece = -1;

            if (!MainGameWindow.isPlayer)
            {
                //black pawn changes into black queen
                if ((piece.GetNumber() == 27) && (x == board.GetLength(0) - 1))
                {
                    previousPiece = piece.GetNumber();
                    Board.AddPiece(23, x, y, board);
                    pieceChanged = true;
                }

                //white pawn changes into white queen
                if ((piece.GetNumber() == 5) && (x == 0))
                {
                    previousPiece = piece.GetNumber();
                    Board.AddPiece(1, x, y, board);
                    pieceChanged = true;
                }

                //shogi promotions
                if ((Generating.UpperShogiPromotion(x, board) && (!piece.isWhite)) || (Generating.BottomShogiPromotion(x) && piece.isWhite))
                {
                    foreach (var pieceNumber in PiecesNumbers.canPropagate)
                    {
                        if (pieceNumber == piece.GetNumber())
                        {
                            previousPiece = piece.GetNumber();
                            Board.AddPiece(pieceNumber + 1, x, y, board);
                            pieceChanged = true;
                        }
                    }
                }

            }

            //checkers change into queen
            if ((piece.GetNumber() == 28) && (x == board.GetLength(1) - 1))
            {
                previousPiece = piece.GetNumber();
                Board.AddPiece(29, x, y, board);
                pieceChanged = true;

            }

            if ((piece.GetNumber() == 6) && (x == 0))
            {
                previousPiece = piece.GetNumber();
                Board.AddPiece(07, x, y, board);
                pieceChanged = true;
            }
        }

        /// <summary>
        /// Checks whether the move is bottom enpassante, and makes correct changes on the board.
        /// </summary>
        /// <param name="start_x"></param>
        /// <param name="start_y"></param>
        /// <param name="final_x"></param>
        /// <param name="final_y"></param>
        /// <param name="Board"></param>
        public static void BottomEnpassante(int start_x, int start_y, int final_x, int final_y, Pieces[,] Board)
        {

            if (Board[final_x, final_y] != null)
            {
                return;
            }

            if (start_x == 3)
            {
                if ((final_x == 2 && final_y == start_y - 1) && (Board[start_x, start_y - 1] != null))
                {
                    takenPiece = Board[start_x, start_y - 1];

                    Board[start_x, start_y - 1] = null;
                    delete_x = start_x;
                    delete_y = start_y - 1;

                    taken_x = start_x;
                    taken_y = start_y - 1;
                }
                else if ((final_x == 2 && final_y == start_y + 1) && (Board[start_x, start_y + 1] != null))
                {
                    takenPiece = Board[start_x, start_y + 1];

                    Board[start_x, start_y + 1] = null;
                    delete_x = start_x;
                    delete_y = start_y + 1;

                    taken_x = start_x;
                    taken_y = start_y + 1;
                }
            }
        }

        /// <summary>
        /// Checks whether the move is upper enpassante, and makes correct changes on the board.
        /// </summary>
        /// <param name="start_x"></param>
        /// <param name="start_y"></param>
        /// <param name="final_x"></param>
        /// <param name="final_y"></param>
        /// <param name="Board"></param>
        public static void UpperEnpassante(int start_x, int start_y, int final_x, int final_y, Pieces[,] Board)
        {
            if (Board[final_x, final_y] != null)
            {
                return;
            }

            if (start_x == Board.GetLength(0) - 4)
            {
                if (final_x == Board.GetLength(0) - 3 && final_y == start_y - 1 && Board[start_x, start_y - 1] != null)
                {
                    takenPiece = Board[start_x, start_y - 1];

                    Board[start_x, start_y - 1] = null;
                    delete_x = start_x;
                    delete_y = start_y - 1;

                    taken_x = start_x;
                    taken_y = start_y - 1;
                }
                else if (final_x == Board.GetLength(0) - 3 && final_y == start_y + 1 && Board[start_x, start_y + 1] != null)
                {
                    takenPiece = Board[start_x, start_y + 1];

                    Board[start_x, start_y + 1] = null;
                    delete_x = start_x;
                    delete_y = start_y + 1;

                    taken_x = start_x;
                    taken_y = start_y + 1;
                }
            }
        }

        /// <summary>
        ///  Checks whether the move is castling, and makes correct changes on the board.
        /// </summary>
        /// <param name="start_x"></param>
        /// <param name="start_y"></param>
        /// <param name="final_x"></param>
        /// <param name="final_y"></param>
        /// <param name="Board"></param>
        /// <returns></returns>
        public static bool IsCastling(int start_x, int start_y, int final_x, int final_y, Pieces[,] Board)
        {

            //we return when the board is incorrect size
            if (!(Board.GetLength(0) == 8 && Board.GetLength(1) == 8))
            {
                return false;
            }

            if (start_x == final_x && start_y == final_y + 2)
            {
                //upper castling
                if (start_x == 0)
                {
                    isCastling = true;

                    Board[0, 3] = Board[0, 0];
                    Board[0, 0] = null;

                    isCastling = true;

                    castling_x = 0;
                    castling_y = 0;
                    castling_z = 3;


                    return true;
                }
                //bottom castling
                if (start_x == 7)
                {
                    isCastling = true;

                    Board[7, 3] = Board[7, 0];
                    Board[7, 0] = null;


                    castling_x = 7;
                    castling_y = 0;
                    castling_z = 3;


                    return true;
                }
            }

            if (start_x == final_x && start_y == final_y - 2)
            {
                //upper castling
                if (start_x == 0)
                {
                    isCastling = true;

                    Board[0, 5] = Board[0, 7];
                    Board[0, 7] = null;

                    castling_x = 0;
                    castling_y = 7;
                    castling_z = 5;


                    return true;
                }

                //bottom castling
                if (start_x == 7)
                {
                    isCastling = true;

                    Board[7, 5] = Board[7, 7];
                    Board[7, 7] = null;

                    castling_x = 7;
                    castling_y = 7;
                    castling_z = 5;

                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Applies given move to a given game board. Takes castling, en passante, and checkers pieces into account.
        /// </summary>
        /// <param name="start_x"></param>
        /// <param name="start_y"></param>
        /// <param name="final_x"></param>
        /// <param name="final_y"></param>
        /// <param name="Board"></param>
        public static void ApplyMove(int start_x, int start_y, int final_x, int final_y, Pieces[,] Board)
        {

            //set all booleans to default state - false
            delete_x = -1;
            taken_x = -1;
            isCastling = false;
            takenPiece = null;
            moved = null;

            //get moving piece
            Pieces piece = Board[start_x, start_y];


            //en passante check
            if (piece.GetNumber() == 5)
            {
                BottomEnpassante(start_x, start_y, final_x, final_y, Board);
            }
            else if (piece.GetNumber() == 26)
            {
                UpperEnpassante(start_x, start_y, final_x, final_y, Board);
            }



            //checks whether we are taking another piece with checker piece
            if (PiecesNumbers.IsCheckersPiece(piece) && IsCheckersPieceTaking(start_x, final_x))
            {
                int x_position;
                int y_position;

                //finding out a position of deleted piece
                if (final_x > start_x)
                {
                    x_position = start_x + 1;
                }
                else
                {
                    x_position = final_x + 1;
                }

                if (final_y > start_y)
                {
                    y_position = start_y + 1;
                }
                else
                {
                    y_position = final_y + 1;
                }

                takenPiece = Board[x_position, y_position];
                Board[x_position, y_position] = null;

                delete_x = x_position;
                delete_y = y_position;

                taken_x = x_position;
                taken_y = y_position;

                var copy = Moves.MakeCopyEmptyCoordinates();


                if (piece.isWhite)
                {
                    if (Moves.WhiteCheckersTake(final_x, final_y, Board))
                    {

                        MainGameWindow.isCheckersPieceSupposedToTake = true;
                        Moves.EmptyCoordinates();
                        Moves.CoordinatesReturn(copy);
                    }
                }
                else
                {
                    if (Moves.BlackCheckersTake(final_x, final_y, Board))
                    {

                        MainGameWindow.isCheckersPieceSupposedToTake = true;
                        Moves.EmptyCoordinates();
                        Moves.CoordinatesReturn(copy);
                    }
                }


            }
            
            if (PiecesNumbers.IsCheckersQueen(piece))
            {
                int x_position = start_x;
                int y_position = start_y;

                int x_value;
                int y_value;

                if (start_x < final_x)
                {
                    x_value = 1;
                }
                else
                {
                    x_value = -1;
                }

                if (start_y < final_y)
                {
                    y_value = 1;
                }
                else
                {
                    y_value = -1;
                }

                while (x_position != final_x && y_position != final_y)
                {
                    x_position += x_value;
                    y_position += y_value;

                    if (Board[x_position, y_position] != null)
                    {
                        takenPiece = Board[x_position, y_position];
                        Board[x_position, y_position] = null;

                        delete_x = x_position;
                        delete_y = y_position;

                        taken_x = x_position;
                        taken_y = y_position;

                        var copy = Moves.MakeCopyEmptyCoordinates();

                        if (Moves.CheckersQueenTake(final_x, final_y, Board))
                        {
                            MainGameWindow.isCheckersPieceSupposedToTake = true;
                            Moves.EmptyCoordinates();
                            Moves.CoordinatesReturn(copy);
                        }

                        break;

                    }
                }

            }

            //we need to mark a piece we are deleting
            if (Board[final_x, final_y] != null)
            {
                taken_x = final_x;
                taken_y = final_y;

                takenPiece = Board[final_x, final_y];
            }


            //movement of a piece
            Board[final_x, final_y] = piece;
            Board[start_x, start_y] = null;

            //look if there are some pieces changing
            ChangePiece(final_x, final_y, piece, Board);


            //mark kinh as moved when we move him
            if (PiecesNumbers.IsKing(piece))
            {
                if (piece.Moved == false)
                {
                    moved = piece;
                }

                piece.Moved = true;

                //check whether the move is castling
                IsCastling(start_x, start_y, final_x, final_y, Board);
            }


            return;
        }


        /// <summary>
        /// Returns true when the move is supposed to take another piece with checkers piece.
        /// </summary>
        /// <param name="start_x"></param>
        /// <param name="final_x"></param>
        /// <returns></returns>
        public static bool IsCheckersPieceTaking(int start_x, int final_x)
        {
            if (start_x == final_x - 2 || start_x == final_x + 2)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Reapplies given move, taking care of taken pieces, castling, en passante.
        /// </summary>
        /// <param name="start_x"></param>
        /// <param name="start_y"></param>
        /// <param name="final_x"></param>
        /// <param name="final_y"></param>
        /// <param name="piece"></param>
        /// <param name="local_taken_x"></param>
        /// <param name="local_taken_y"></param>
        /// <param name="isCastling"></param>
        /// <param name="board"></param>
        public static void ReapplyMove(int start_x, int start_y, int final_x, int final_y, int piece, int local_taken_x, int local_taken_y, bool isCastling, Pieces[,] board, int previousPiece)
        {

            if (isCastling)
            {
                if (start_x == final_x && start_y == final_y + 2)
                {
                    //upper castling
                    if (start_x == 0)
                    {
                        board[0, 0] = board[0, 3];
                        board[0, 3] = null;
                    }
                    //bottom castling
                    else if (start_x == 7)
                    {
                        board[7, 0] = board[7, 3];
                        board[7, 3] = null;
                    }
                }
                else if (start_x == final_x && start_y == final_y - 2)
                {
                    //upper castling
                    if (start_x == 0)
                    {
                        board[0, 7] = board[0, 5];
                        board[0, 5] = null;
                    }
                    //bottom castling
                    else if (start_x == 7)
                    {
                        board[7, 7] = board[7, 5];
                        board[7, 5] = null;
                    }
                }
            }

            //reapply move
            board[start_x, start_y] = board[final_x, final_y];
            board[final_x, final_y] = null;

            //put back taken piece
            if (local_taken_x != -1)
            {
                Board.AddPiece(piece, local_taken_x, local_taken_y, board);
            }

            if (previousPiece != -1)
            {
                Board.AddPiece(previousPiece, start_x, start_y, board);
            }


            //switch back movement flag on the king piece
            if (PiecesNumbers.IsKing(board[start_x, start_y]))
            {
                board[start_x, start_y].Moved = false;
            }

        }


    }
}
