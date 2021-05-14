namespace ShogiCheckersChess
{
    /// <summary>
    /// Contains starting boards for basic three games.
    /// </summary>
    public static class GameStart
    {
        /// <summary>
        /// Starting board for playing chess.
        /// </summary>
        public static int[,] chess = new int[,] {
        {23,24,25,22,21,25,24,23},
        {26,26,26,26,26,26,26,26},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {5,5,5,5,5,5,5,5},
        {2,3,4,1,0,4,3,2}
        };

        /// <summary>
        /// Starting board for playing shogi.
        /// </summary>
        public static int[,] shogi = new int[,] {
        {38,36,34,33,28,33,34,36,38},
        {-1,29,-1,-1,-1,-1,-1,31,-1},
        {40,40,40,40,40,40,40,40,40},
        {-1,-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1,-1},
        {19,19,19,19,19,19,19,19,19},
        {-1,10,-1,-1,-1,-1,-1,8,-1},
        {17,15,13,12,7,12,13,15,17}
        };

        /// <summary>
        /// Starting board for playing checkers.
        /// </summary>
        public static int[,] checkers = new int[,] {
        {-1,27,-1,27,-1,27,-1,27},
        {27,-1,27,-1,27,-1,27,-1},
        {-1,27,-1,27,-1,27,-1,27},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {6,-1,6,-1,6,-1,6,-1},
        {-1,6,-1,6,-1,6,-1,6},
        {6,-1,6,-1,6,-1,6,-1},
        };

    }

    public static class Board
    {
       
        /// <summary>
        /// Base number of pieces written in code.
        /// </summary>
        const int NUMBER_OF_PIECES = 42;

        /// <summary>
        /// Main game board for current game.
        /// </summary>
        public static Pieces[,] board;

        /// <summary>
        /// Adds piece, specified by its number, to main game board
        /// </summary>
        /// <param name="number"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void AddPiece(int number, int x, int y, Pieces[,] gameboard)
        {
            Pieces piece;

            switch (number)
            {
                //for bottom/white pieces
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

                //for uper/black pieces
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
                default:
                    MakeCustomPiece(number, x, y);
                    return;

            }

            gameboard[x, y] = piece;
            piece.SetNumber(number);
        }


        /// <summary>
        /// Adds custom piece on the board. This piece needs to already be in DefinedPieces list.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void MakeCustomPiece(int number, int x, int y)
        {
            //index of custom piece in DefinedPieces list
            int index = number - NUMBER_OF_PIECES;

            var piece = new Custom(Pieces.DefinedPieces[index].moves, Pieces.DefinedPieces[index].Name, Pieces.DefinedPieces[index].Value)
            {
                isWhite = Pieces.DefinedPieces[number - NUMBER_OF_PIECES].isWhite
            };
            board[x, y] = piece;

            piece.SetNumber(PiecesNumbers.getNumber[piece.Name]);


        }
    }


}
