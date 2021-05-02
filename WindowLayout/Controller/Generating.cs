using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
        /// Marks whether we take a piece with checkers piece.
        /// </summary>
        public static bool CheckersTake = false;

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
            CheckersTake = false;

            //takes care of special movement of checker pieces
            if ((Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers) && (Gameclass.CurrentGame.MustTakeCheckersPiece(Board)))
            {
                if (piece.Value == 10)
                {
                    CheckersTake = true;
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
            //nejprve si smaže seznam tahů
            if (delete)
                Moves.EmptyCoordinates();

            int moves_start = Moves.final_x.Count;

            GenerateMoves(piece, delete, x, y, Board);

            //zamezíme tahům, které by nebyly validní, tzn. těm, co ohrozí vlastního krále
            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.chess && checkValidMoves)
            //if (Gameclass.CurrentGame.gameType == Gameclass.GameType.chess)
            {
                WhitePlays = !WhitePlays;

                List<int> remove = new List<int>();

                //pro Aičko by se to tady asi ani nemuselo brát od nuly...
                for (int i = moves_start; i < Moves.final_x.Count; i++)
                {
                    Pieces takenpiece = Board[Moves.final_x[i], Moves.final_y[i]];
                    Board[Moves.final_x[i], Moves.final_y[i]] = Board[Moves.start_x[i], Moves.start_y[i]];
                    Board[Moves.start_x[i], Moves.start_y[i]] = null;

                    //kontrola šachu - do seznamu remove dá ty tahy, jež mají šach
                    if (Gameclass.CurrentGame.KingCheck(Board))
                    {
                        remove.Add(i);
                    }


                    Board[Moves.start_x[i], Moves.start_y[i]] = Board[Moves.final_x[i], Moves.final_y[i]];
                    Board[Moves.final_x[i], Moves.final_y[i]] = takenpiece;
                }

                //removneme jak špatné tahy, tak jejich value pro aiščko
                for (int i = 0; i < remove.Count; i++)
                {
                    Moves.ReplaceAt(remove[i]);
                }

                Moves.Delete(-1);

                WhitePlays = !WhitePlays;
            }


        }

        public static void GenerateAllMoves(Pieces[,] Board, bool checkValidMoves, bool deleteMoves)
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if ((Board[i, j] != null) && (Board[i, j].isWhite == Generating.WhitePlays))
                    {
                        Generating.Generate(Board[i, j], deleteMoves, i, j, checkValidMoves, Board);
                    }
                }
            }
        }

        public static bool UpperShogiPromotion(int x)
        {
            if ((x == Board.board.GetLength(1) - 3) || (x == Board.board.GetLength(1) - 1) || (x == Board.board.GetLength(1) - 2))
                return true;
            return false;
        }

        public static bool BottomShogiPromotion(int x)
        {
            if ((x == 0) || (x == 1) || (x == 2))
                return true;
            return false;
        }

    }

}

