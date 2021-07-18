using System.Collections.Generic;

namespace GeneralBoardGames
{
    public class Gameclass
    {
        public static class CurrentGame
        {
            /// <summary>
            /// Type of current game - chess, checkers or shogi.
            /// </summary>
            public static GameType gameType;

            /// <summary>
            /// Type of current game - chess, checkers or shogi.
            /// </summary>
            public static GameType whiteGameType;

            /// <summary>
            /// Type of current game - chess, checkers or shogi.
            /// </summary>
            public static GameType blackGameType;



            /// <summary>
            /// Type of current game - chess, checkers or shogi.
            /// </summary>
            public static GameType playType;

            /// <summary>
            /// Type of current game - chess, checkers or shogi.
            /// </summary>
            public static GameType whitePlayType;

            /// <summary>
            /// Type of current game - chess, checkers or shogi.
            /// </summary>
            public static GameType blackPlayType;




            /// <summary>
            /// Type of player - singleplayer or multiplayer.
            /// </summary>
            public static PlayerType playerType;

            /// <summary>
            /// Algorithm which is used to play - minimax or montecarlo.
            /// </summary>
            public static AlgorithmType algorithmType;

            /// <summary>
            /// Signalizes whether the game has come to an end.
            /// </summary>
            public static bool GameEnded;

            /// <summary>
            /// Returns true when we have to take a piece in checker games.
            /// </summary>
            /// <param name="Board">board we are playing on</param>
            /// <returns></returns>
            public static bool MustTake(Pieces[,] Board)
            {
                Moves.CoordinatesCopy cp = Moves.MakeCopyEmptyCoordinates();

                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.GetLength(1); j++)
                    {
                        //in case current piece is checkers piece
                        if ((Board[i, j] != null) && (Generating.WhitePlays == Board[i, j].isWhite) && PiecesNumbers.IsCheckersPiece(Board[i,j]))
                        {
                            if (Generating.WhitePlays && Moves.WhiteCheckersTake(i, j, Board))
                            {
                                Moves.EmptyCoordinates();
                                Moves.CoordinatesReturn(cp);
                                return true;
                            }
                            else if (!Generating.WhitePlays && Moves.BlackCheckersTake(i,j, Board))
                            {
                                Moves.EmptyCoordinates();
                                Moves.CoordinatesReturn(cp);
                                return true;
                            }
                        }

                        else if ((Board[i, j] != null) && (Generating.WhitePlays == Board[i, j].isWhite) && PiecesNumbers.IsCheckersQueen(Board[i, j]))
                        {
                            if (Moves.CheckersQueenTake(i, j, Board))
                            {
                                Moves.EmptyCoordinates();
                                Moves.CoordinatesReturn(cp);
                                return true;
                            }
                        }

                        //in case of other piece
                        else if ((Board[i, j] != null) && (Generating.WhitePlays == Board[i, j].isWhite))
                        {
                            Board[i, j].GenerateMoves(i, j, Board);
                            for (int k = 0; k < Moves.GetCount(); k++)
                            {
                                if (Board[Moves.final_x[k], Moves.final_y[k]] != null && Board[Moves.final_x[k], Moves.final_y[k]].isWhite != Board[i,j].isWhite)
                                {
                                    Moves.EmptyCoordinates();
                                    Moves.CoordinatesReturn(cp);
                                    return true;
                                }
                            }                          
                        }
                    }
                }
                Moves.EmptyCoordinates();
                Moves.CoordinatesReturn(cp);

                return false;
            }         

            /// <summary>
            /// Returns true when the game of checkers ended. The game ends when there are no possible moves.
            /// </summary>
            /// <param name="Board"></param>
            /// <returns></returns>
            public static bool CheckersEnd(Pieces[,] Board)
            {
                for (int i = 0; i < Board.GetLength(0); i++)
                {   
                    for (int j = 0; j < Board.GetLength(1); j++)
                    {
                        if ((Board[i, j] != null) && (Generating.WhitePlays == Board[i, j].isWhite))
                        {
                            Generating.Generate(Board[i, j], true, i, j, true, Board);

                            //when we can make a move, the game has not ended yet
                            if (Moves.GetCount() != 0)
                            {
                                return false;
                            }
                        }
                    }
                }

                return true;
            }

            /// <summary>
            /// Returns true when the current player's king is in check.
            /// </summary>
            /// <param name="Board"></param>
            /// <returns></returns>
            public static bool KingCheck(Pieces[,] Board)
            {
                Moves.CoordinatesCopy copyOfCoordinates = Moves.MakeCopyEmptyCoordinates();

                int king_x = 0;
                int king_y = 0;
                
                //first, we have to find where the king is located
                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.GetLength(1); j++)
                    {
                        Pieces piece = Board[i, j];
                        if ((piece != null) && (PiecesNumbers.IsKing(piece)) && (Generating.WhitePlays != piece.isWhite))
                        {
                            king_x = i;
                            king_y = j;
                            break;
                        }
                    }
                }

                //we generate all possible moves starting from king
                Generating.WhitePlays = !Generating.WhitePlays;

                Moves.BackInfinity(king_x, king_y, Board);
                Moves.BackLeftInfinity(king_x, king_y, Board);
                Moves.BackRightInfinity(king_x, king_y, Board);
                Moves.ForwardInfinity(king_x, king_y, Board);
                Moves.ForwardLeftInfinity(king_x, king_y, Board);
                Moves.ForwardRightInfinity(king_x, king_y, Board);
                Moves.LeftInfinity(king_x, king_y, Board);
                Moves.RightInfinity(king_x, king_y, Board);
                Moves.Horse(king_x, king_y, Board);
                Moves.HorseBackward(king_x, king_y, Board);
                Moves.HorseForward(king_x, king_y, Board);

                Generating.WhitePlays = !Generating.WhitePlays;

                //iterate through generated moves and check if there is some piece which could endanger the king
                for (int i = 0; i < Moves.GetCount(); i++)
                {
                    Pieces piece = Board[Moves.final_x[i], Moves.final_y[i]];

                    if ((piece != null) && (Generating.WhitePlays == piece.isWhite))
                    {
                        int x_coor = Moves.final_x[i];
                        int y_coor = Moves.final_y[i];

                        Moves.CoordinatesCopy copy = Moves.MakeCopyEmptyCoordinates();

                        Board[x_coor, y_coor].GenerateMoves(x_coor, y_coor, Board);


                        for (int j = 0; j < Moves.GetCount(); j++)
                        {
                            Pieces isKing = Board[Moves.final_x[j], Moves.final_y[j]];
                            if ((isKing != null) && (PiecesNumbers.IsKing(isKing)) && (Generating.WhitePlays != isKing.isWhite))
                            {
                                Moves.EmptyCoordinates();
                                Moves.CoordinatesReturn(copyOfCoordinates);

                                return true;
                            }
                        }
                        Moves.EmptyCoordinates();
                        Moves.CoordinatesReturn(copy);
                    }
                }

                Moves.EmptyCoordinates();
                Moves.CoordinatesReturn(copyOfCoordinates);

                return false;
            }            

            /// <summary>
            /// Returns true in case of checkmate to current player's king.
            /// </summary>
            /// <param name="Board"></param>
            /// <returns></returns>
            public static bool CheckMate(Pieces[,] Board)
            {
                Moves.CoordinatesCopy copyOfCoordinates = Moves.MakeCopyEmptyCoordinates();

                Generating.WhitePlays = !Generating.WhitePlays;

                //we try to move very piece, checking if we can escape the check somehow
                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.GetLength(1); j++)
                    {
                        if ((Board[i, j] != null) && (Generating.WhitePlays == Board[i, j].isWhite))
                        {
                            Generating.Generate(Board[i, j], true, i, j, true, Board);

                            //there is a way to escape the check
                            if (Moves.GetCount() != 0)
                            {
                                Generating.WhitePlays = !Generating.WhitePlays;
                                
                                return false;
                            }

                        }
                    }
                }

                //we haven't found a way to escape the check, we end the game
                Moves.CoordinatesReturn(copyOfCoordinates);
                Generating.WhitePlays = !Generating.WhitePlays;
                return true;
            }

            /// <summary>
            /// Returns true when there is no King in shogi game.
            /// </summary>
            /// <param name="Board"></param>
            /// <returns></returns>
            public static bool KingOut(Pieces[,] Board)
            {
                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.GetLength(1); j++)
                    {
                        if (Board[i, j] != null && PiecesNumbers.IsShogiKing(Board[i,j]) && Board[i,j].isWhite == Generating.WhitePlays)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }


        }

        /// <summary>
        /// Marks the type of the game, which signalizes how the game ends. Chess, checkers, shogi or other.
        /// </summary>
        public enum GameType
        {
            chess,
            checkers,
            shogi
        }

        /// <summary>
        /// Whether we are playing against human opponent or algorithm, singleplayer or multiplayer.
        /// </summary>
        public enum PlayerType
        {
            single,
            localmulti
        }

        /// <summary>
        /// Which algorithm we use for generating moves.
        /// </summary>
        public enum AlgorithmType
        {
            minimax,
            montecarlo
        }
    }
}
