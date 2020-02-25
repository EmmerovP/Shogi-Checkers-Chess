using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiCheckersChess
{
    public static class Board
    {
        public static Pieces[,] board;

        public static void AddPiece(int value, int x, int y)
        {
            Pieces piece = new Pieces
            {
                isWhite = false
            };
            switch (value)
            {
                case 0:
                    piece = new King
                    {
                        isWhite = true
                    };
                    break;
                case 1:
                    piece = new Queen
                    {
                        isWhite = true
                    };
                    break;
                case 2:
                    piece = new Rook
                    {
                        isWhite = true
                    };
                    break;
                case 3:
                    piece = new Horse
                    {
                        isWhite = true
                    };
                    break;
                case 4:
                    piece = new Bishop
                    {
                        isWhite = true
                    };
                    break;
                case 5:
                    piece = new BottomPawn
                    {
                        isWhite = true
                    };
                    break;
                case 6:
                    piece = new WhiteCheckersPiece
                    {
                        isWhite = true
                    };
                    break;
                case 7:
                    piece = new ShogiKing
                    {
                        isWhite = true
                    };
                    break;
                case 8:
                    piece = new ShogiRook
                    {
                        isWhite = true
                    };
                    break;
                case 9:
                    piece = new PromotedShogiRook
                    {
                        isWhite = true
                    };
                    break;
                case 10:
                    piece = new ShogiBishop
                    {
                        isWhite = true
                    };
                    break;
                case 11:
                    piece = new PromotedShogiBishop
                    {
                        isWhite = true
                    };
                    break;
                case 12:
                    piece = new BottomGoldGeneral
                    {
                        isWhite = true
                    };
                    break;
                case 13:
                    piece = new BottomSilverGeneral
                    {
                        isWhite = true
                    };
                    break;
                case 14:
                    piece = new BottomPromotedSilverGeneral
                    {
                        isWhite = true
                    };
                    break;
                case 15:
                    piece = new BottomShogiHorse
                    {
                        isWhite = true
                    };
                    break;
                case 16:
                    piece = new BottomPromotedKnight
                    {
                        isWhite = true
                    };
                    break;
                case 17:
                    piece = new BottomLance
                    {
                        isWhite = true
                    };
                    break;
                case 18:
                    piece = new BottomPromotedLance
                    {
                        isWhite = true
                    };
                    break;
                case 19:
                    piece = new ShogiBottomPawn
                    {
                        isWhite = true
                    };
                    break;
                case 20:
                    piece = new BottomPromotedPawn
                    {
                        isWhite = true
                    };
                    break;
                //ještě černá, ale shogi má vlastně obrácené pohyby...
                case 21:
                    piece = new King
                    {
                        isWhite = false
                    };
                    break;
                case 22:
                    piece = new Queen
                    {
                        isWhite = false
                    };
                    break;
                case 23:
                    piece = new Rook
                    {
                        isWhite = false
                    };
                    break;
                case 24:
                    piece = new Horse
                    {
                        isWhite = false
                    };
                    break;
                case 25:
                    piece = new Bishop
                    {
                        isWhite = false
                    };
                    break;
                case 26:
                    piece = new UpperPawn
                    {
                        isWhite = false
                    };
                    break;
                case 27:
                    piece = new BlackCheckersPiece
                    {
                        isWhite = false
                    };
                    break;
                case 28:
                    piece = new ShogiKing
                    {
                        isWhite = false
                    };
                    break;
                case 29:
                    piece = new ShogiRook
                    {
                        isWhite = false
                    };
                    break;
                case 30:
                    piece = new PromotedShogiRook
                    {
                        isWhite = false
                    };
                    break;
                case 31:
                    piece = new ShogiBishop
                    {
                        isWhite = false
                    };
                    break;
                case 32:
                    piece = new PromotedShogiBishop
                    {
                        isWhite = false
                    };
                    break;
                case 33:
                    piece = new UpperGoldGeneral
                    {
                        isWhite = false
                    };
                    break;
                case 34:
                    piece = new UpperSilverGeneral
                    {
                        isWhite = false
                    };
                    break;
                case 35:
                    piece = new UpperPromotedSilverGeneral
                    {
                        isWhite = false
                    };
                    break;
                case 36:
                    piece = new UpperShogiHorse
                    {
                        isWhite = false
                    };
                    break;
                case 37:
                    piece = new UpperPromotedKnight
                    {
                        isWhite = false
                    };
                    break;
                case 38:
                    piece = new UpperLance
                    {
                        isWhite = false
                    };
                    break;
                case 39:
                    piece = new UpperPromotedLance
                    {
                        isWhite = false
                    };
                    break;
                case 40:
                    piece = new ShogiUpperPawn
                    {
                        isWhite = false
                    };
                    break;
                case 41:
                    piece = new UpperPromotedPawn
                    {
                        isWhite = false
                    };
                    break;

            }

            board[x, y] = piece;
            piece.SetNumber(value);
        }
    }


}
