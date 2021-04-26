using System;
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
                MoveController.ApplyMove(moves.start_x[i], moves.start_y[i], moves.final_x[i], moves.final_y[i]);
                var piece = MoveController.takenPiece;
                int taken_x = MoveController.taken_x;
                int taken_y = MoveController.taken_y;
                bool isCastling = MoveController.isCastling;
                var movedPiece = MoveController.moved;


                choice.Add(Minimax.OneStepMax(3, Int32.MinValue, Int32.MaxValue, false));




                MoveController.ReapplyMove(moves.start_x[i], moves.start_y[i], moves.final_x[i], moves.final_y[i], piece, taken_x, taken_y, isCastling, movedPiece);

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
                                if (piece.GetNumber() == 19)
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
                if ((Board.board[i, column] != null) && (Board.board[i, column].GetNumber() == 19))
                {

                    return true;
                }

            }
            return false;
        }
    }
}
