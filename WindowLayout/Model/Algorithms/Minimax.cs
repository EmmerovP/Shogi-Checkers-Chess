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

        public static bool isAddingPiece;
        public static Pieces AddingPiece;
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

        public static int FindPiece()
        {
            bool WhoPlays = Generating.WhitePlays;
            isAddingPiece = false;

            Generating.CheckersTake = false;
            Moves.EmptyCoordinates();

            List<int> choice = new List<int>();




            //Vygenerujeme možné tahy na momentální šachovnici
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(1); j++)
                {
                    if ((Board.board[i, j] != null) && (Board.board[i, j].isWhite == Generating.WhitePlays))
                    {
                        Generating.Generate(Board.board[i, j], false, i, j, true, Board.board);
                    }
                }
            }

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


                choice.Add(Minimax.OneStepMax(3, Int32.MinValue, Int32.MaxValue, false));




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

                                choice.Add(Minimax.OneStepMax(2, Int32.MinValue, Int32.MaxValue, false));

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

            int highest = Highest(choice);
            var indexes = HighestIndexes(highest, choice);
            int move = rnd.Next(indexes.Count);
            int pos = indexes[move];

            if (pos >= Moves.start_y.Count)
            {
                isAddingPiece = true;
                MainGameWindow.shogiAIPieces.Remove(removePieces[pos - Moves.start_y.Count]);
            }

            return pos;



        }

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
