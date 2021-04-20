using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShogiCheckersChess
{
    public static class MoveController
    {
        //potřeba pro view
        public static int delete_x;
        public static int delete_y;

        public static bool isCastling;

        public static int castling_x;
        public static int castling_y;
        public static int castling_z;

        //potřeba pro reapply
        //vyhozená figurka
        public static Pieces takenPiece;
        public static int taken_x;
        public static int taken_y; //pokud není, hodnota -1. Řeší i vyhození v dámě a en passante

        public static Pieces moved;

        //+ v minimaxu si musím zapamatovat tyto položky pro danou instanci, pak je dostanu zpátky v reapply!



        public static void BottomEnpassante(int start_x, int start_y, int final_x, int final_y)
        {
            if (Board.board[final_x, final_y] != null)
            {
                return;
            }


            if (start_x == 3)
            {
                if ((final_x == 2 && final_y == start_y - 1) && (Board.board[start_x, start_y - 1] != null))
                {
                    takenPiece = Board.board[start_x, start_y - 1];

                    Board.board[start_x, start_y - 1] = null;
                    delete_x = start_x;
                    delete_y = start_y - 1;

                    taken_x = start_x;
                    taken_y = start_y - 1;
                }
                else if ((final_x == 2 && final_y == start_y + 1) && (Board.board[start_x, start_y + 1] != null))
                {
                    takenPiece = Board.board[start_x, start_y + 1];

                    Board.board[start_x, start_y + 1] = null;
                    delete_x = start_x;
                    delete_y = start_y + 1;

                    taken_x = start_x;
                    taken_y = start_y + 1;
                }
            }
        }

        public static void UpperEnpassante(int start_x, int start_y, int final_x, int final_y)
        {
                        if (Board.board[final_x, final_y] != null)
            {
                return;
            }

            if (start_x == Board.board.GetLength(0) - 4)
            {
                if (final_x == Board.board.GetLength(0) - 3 && final_y == start_y - 1 && Board.board[start_x, start_y - 1] != null)
                {
                    takenPiece = Board.board[start_x, start_y - 1];

                    Board.board[start_x, start_y - 1] = null;
                    delete_x = start_x;
                    delete_y = start_y - 1;

                    taken_x = start_x;
                    taken_y = start_y - 1;
                }
                else if (final_x == Board.board.GetLength(0) - 3 && final_y == start_y + 1 && Board.board[start_x, start_y + 1] != null)
                {
                    takenPiece = Board.board[start_x, start_y + 1];

                    Board.board[start_x, start_y + 1] = null;
                    delete_x = start_x;
                    delete_y = start_y + 1;

                    taken_x = start_x;
                    taken_y = start_y + 1;
                }
            }
        }

        public static bool IsCastling(int start_x, int start_y, int final_x, int final_y)
        {
            if (!(Board.board.GetLength(0) == 8 && Board.board.GetLength(1) == 8))
            {
                return false;
            }
            //je to rošáda
            if (start_x == final_x && start_y == final_y + 2)
            {
                //je to rošáda nahoře
                if (start_x == 0)
                {
                    isCastling = true;

                    Board.board[0, 3] = Board.board[0, 0];
                    Board.board[0, 0] = null;

                    isCastling = true;

                    castling_x = 0;
                    castling_y = 0;
                    castling_z = 3;


                    return true;
                }
                //je to rošáda dole
                if (start_x == 7)
                {
                    isCastling = true;

                    Board.board[7, 3] = Board.board[7, 0];
                    Board.board[7, 0] = null;


                    castling_x = 7;
                    castling_y = 0;
                    castling_z = 3;


                    return true;
                }
            }
            if (start_x == final_x && start_y == final_y - 2)
            {
                //je to rošáda nahoře
                if (start_x == 0)
                {
                    isCastling = true;

                    Board.board[0, 5] = Board.board[0, 7];
                    Board.board[0, 7] = null;

                    castling_x = 0;
                    castling_y = 7;
                    castling_z = 5;


                    return true;
                }
                //je to rošáda dole
                if (start_x == 7)
                {
                    isCastling = true;

                    Board.board[7, 5] = Board.board[7, 7];
                    Board.board[7, 7] = null;

                    castling_x = 7;
                    castling_y = 7;
                    castling_z = 5;

                    return true;
                }
            }
            return false;
        }



        public static void ApplyMove(int start_x, int start_y, int final_x, int final_y)
        {
            delete_x = -1;
            taken_x = -1;
            isCastling = false;
            takenPiece = null;
            moved = null;

            //CheckersTake = false;

            Pieces piece = Board.board[start_x, start_y];

            if (piece == null)
            {
                throw new Exception();
            }


            
            if (piece.GetNumber() == 5)
            {
                BottomEnpassante(start_x, start_y, final_x, final_y);
            }
            else if (piece.GetNumber() == 26)
            {
                UpperEnpassante(start_x, start_y, final_x, final_y);
            }
            


            //dáma
            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers && Board.board[start_x, start_y].Value == 10 &&
                    (start_x == final_x - 2 || start_x == final_x + 2))
            {
                int xpiece, ypiece;
                if (final_x > start_x)
                {
                    xpiece = start_x + 1;
                }
                else
                {
                    xpiece = final_x + 1;
                }

                if (final_y > start_y)
                {
                    ypiece = start_y + 1;
                }
                else
                {
                    ypiece = final_y + 1;
                }
                takenPiece = Board.board[xpiece, ypiece];
                Board.board[xpiece, ypiece] = null;

                delete_x = xpiece;
                delete_y = ypiece;

                taken_x = xpiece;
                taken_y = ypiece;


            }

            //v shogi se vyhazuje figurka, přidáváme jí do seznamu vyhozených figurek
            if (Board.board[final_x, final_y] != null)
            {
                taken_x = final_x;
                taken_y = final_y;

                takenPiece = Board.board[final_x, final_y];


            }

            Board.board[final_x, final_y] = piece;
            Board.board[start_x, start_y] = null;


            
            
            if (piece.Value == 900)
            {
                if (piece.Moved == false)
                {
                    moved = piece;
                }
                //tadyto vadí při ai
                piece.Moved = true;
                //pokud se král posunul o dvě políčka, jedná se o rošádu
                IsCastling(start_x, start_y, final_x, final_y);
            }

            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers && Gameclass.CurrentGame.MustTakeCheckersPiece())
            {
                Generating.WhitePlays = !Generating.WhitePlays;
            }

            //hlídání konců her
            return;
        }

        public static void ReapplyMove(int start_x, int start_y, int final_x, int final_y, Pieces piece, int local_taken_x, int local_taken_y, bool isCastling, Pieces MovedPiece)
        {
            if (isCastling)
            {
                if (start_x == final_x && start_y == final_y + 2)
                {
                    //je to rošáda nahoře
                    if (start_x == 0)
                    {
                        Board.board[0, 0] = Board.board[0, 3];
                        Board.board[0, 3] = null;
                    }
                    //je to rošáda dole
                    else if (start_x == 7)
                    {
                        Board.board[7, 0] = Board.board[7, 3];
                        Board.board[7, 3] = null;
                    }
                }
                else if (start_x == final_x && start_y == final_y - 2)
                {
                    //je to rošáda nahoře
                    if (start_x == 0)
                    {
                        Board.board[0, 7] = Board.board[0, 5];
                        Board.board[0, 5] = null;
                    }
                    //je to rošáda dole
                    else if (start_x == 7)
                    {
                        Board.board[7, 7] = Board.board[7, 5];
                        Board.board[7, 5] = null;
                    }
                }
            }

            Board.board[start_x, start_y] = Board.board[final_x, final_y];
            Board.board[final_x, final_y] = null;

            if (local_taken_x != -1)
            {
                if (piece == null)
                {
                    throw new Exception();
                }
                Board.board[local_taken_x, local_taken_y] = piece;
            }

            if (MovedPiece != null)
            {
                MovedPiece.Moved = false;
            }

        }


    }
}
