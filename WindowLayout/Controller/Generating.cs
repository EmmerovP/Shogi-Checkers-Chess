using System.Collections.Generic;


namespace ShogiCheckersChess
{
    /// <summary>
    /// Class taking care of generating moves.
    /// </summary>
    public static class Generating
    {
        /// <summary>
        /// Marks which player's moves should currently be generated.
        /// </summary>
        public static bool WhitePlays = true;

        /// <summary>
        /// Inner function, taking care of logic 
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="delete"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Board"></param>
        public static void GenerateMoves(Pieces piece, bool delete, int x, int y, Pieces[,] Board)
        {
            //takes care of special movement of checker pieces
            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers && (Gameclass.CurrentGame.MustTakeCheckersPiece(Board)))
            {
                //for checkers piece, generate special moves for taking pieces
                if (PiecesNumbers.IsCheckersPiece(piece))
                {
                    if (WhitePlays)
                    {
                        Moves.WhiteCheckersTake(x, y, Board);
                    }
                    else
                    {
                        Moves.BlackCheckersTake(x, y, Board);
                    }

                    return;
                }

                //for all other pieces, generate all their moves, then keep only the ones that take other pieces
                else
                {
                    piece.GenerateMoves(x, y, Board);
                    var copied_coordinates = Moves.MakeCopyEmptyCoordinates();
                    for (int i = 0; i < copied_coordinates.final_x.Count; i++)
                    {
                        if (Board[copied_coordinates.final_x[i], copied_coordinates.final_y[i]] != null &&
                            Board[copied_coordinates.final_x[i], copied_coordinates.final_y[i]].isWhite != piece.isWhite)
                        {
                            Moves.final_x.Add(copied_coordinates.final_x[i]);
                            Moves.final_y.Add(copied_coordinates.final_y[i]);

                            Moves.start_x.Add(copied_coordinates.start_x[i]);
                            Moves.start_y.Add(copied_coordinates.start_y[i]);
                        }
                    }
                    return;
                }
            }
            else
            {
                piece.GenerateMoves(x, y, Board);
            }

        }

        /// <summary>
        /// Main generating function.
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="delete"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="checkValidMoves"></param>
        /// <param name="Board"></param>
        public static void Generate(Pieces piece, bool delete, int x, int y, bool checkValidMoves, Pieces[,] Board)
        {
            //when needed, deletes current move coordinates
            if (delete)
                Moves.EmptyCoordinates();

            //marks position
            int movesStart = Moves.final_x.Count;

            GenerateMoves(piece, delete, x, y, Board);

            //we delete all the moves that would endanger a king in chess
            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.chess && checkValidMoves)
            {
                WhitePlays = !WhitePlays;

                List<int> remove = new List<int>();

                for (int i = movesStart; i < Moves.final_x.Count; i++)
                {
                    Pieces takenpiece = Board[Moves.final_x[i], Moves.final_y[i]];
                    Board[Moves.final_x[i], Moves.final_y[i]] = Board[Moves.start_x[i], Moves.start_y[i]];
                    Board[Moves.start_x[i], Moves.start_y[i]] = null;

                    if (Gameclass.CurrentGame.KingCheck(Board))
                    {
                        remove.Add(i);
                    }

                    Board[Moves.start_x[i], Moves.start_y[i]] = Board[Moves.final_x[i], Moves.final_y[i]];
                    Board[Moves.final_x[i], Moves.final_y[i]] = takenpiece;
                }

                for (int i = 0; i < remove.Count; i++)
                {
                    Moves.ReplaceAt(remove[i]);
                }

                Moves.Delete(-1);

                WhitePlays = !WhitePlays;
            }


        }

        /// <summary>
        /// Generates all possible moves for current side.
        /// </summary>
        /// <param name="Board"></param>
        /// <param name="checkValidMoves"></param>
        /// <param name="deleteMoves"></param>
        public static void GenerateAllMoves(Pieces[,] Board, bool checkValidMoves)
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if ((Board[i, j] != null) && (Board[i, j].isWhite == Generating.WhitePlays))
                    {
                        Generating.Generate(Board[i, j], false, i, j, checkValidMoves, Board);
                    }
                }
            }
        }

        /// <summary>
        /// Returns true when upper shogi piece can be promoted.
        /// </summary>
        /// <param name="row">row of piece</param>
        /// <returns></returns>
        public static bool UpperShogiPromotion(int row, Pieces[,] Board)
        {
            if ((row == Board.GetLength(1) - 3) || (row == Board.GetLength(1) - 1) || (row == Board.GetLength(1) - 2))
                return true;
            return false;
        }

        /// <summary>
        /// Returns true when bottom shogi piece can be promoted.
        /// </summary>
        /// <param name="row">row of piece</param>
        /// <returns></returns>
        public static bool BottomShogiPromotion(int row)
        {
            if ((row == 0) || (row == 1) || (row == 2))
                return true;
            return false;
        }

    }

}

