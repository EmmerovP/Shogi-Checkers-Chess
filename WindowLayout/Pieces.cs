using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowLayout
{
    public static class GameStarts
    {
        //Musí se odečíst jednička
        //soubor    

        //základní rozestavení šachových figurek
        public static int[,] chess = new int[,] {
        {24,25,26,22,23,26,25,24},
        {27,27,27,27,27,27,27,27},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {6,6,6,6,6,6,6,6},
        {3,4,5,1,2,5,4,3}
        };

        /*//šach mat - ukázková šachovnice
        public static int[,] chess = new int[,] {
        {24,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,27,0,0,0,0,0},
        {2,0,0,0,0,0,0,0},
        {0,2,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,22},
        }; */

        /*    
        //základní rozestavení figurek shogi
        public static int[,] shogi = new int[,] {
        {39,37,35,34,29,34,35,37,39},
        {0,30,0,0,0,0,0,32,0},
        {41,41,41,41,41,41,41,41,41},
        {0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0},
        {20,20,20,20,20,20,20,20,20},
        {0,11,0,0,0,0,0,9,0},
        {18,16,14,13,8,13,14,16,18}
        }; */

        //speciální případ - konec hry
        public static int[,] shogi = new int[,] {
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,29,0,0,0,0,0},
        {0,0,0,41,0,0,0,0},
        {0,0,0,8,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        };

        //základní rozestavení figurek dámy
        public static int[,] checkers = new int[,] {
        {0,28,0,28,0,28,0,28},
        {28,0,28,0,28,0,28,0},
        {0,28,0,28,0,28,0,28},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {7,0,7,0,7,0,7,0},
        {0,7,0,7,0,7,0,7},
        {7,0,7,0,7,0,7,0},
        };

        /*//speciální rozestavení - test konce
        public static int[,] checkers = new int[,] {
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,28,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,7,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        };*/

    }


    public class Pieces
    {
        public virtual void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {

        }
        public bool moved;
        public bool isWhite;
        public virtual int GetNumber()
        {
            return -1;
        }
    }

    //šachy
    //nápady: číslo figurky je asi zbytečné, lepší je, na které straně je - white a !white, kvůli vyhazování
    //nějaký public static na zjištění kdo je na tahu
    class Queen : Pieces
    {
        public override int GetNumber()
        {
            return 1;
        }
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.ForwardInfinity(x, y, chessboard);
            Moves.ForwardLeftInfinity(x, y, chessboard);
            Moves.ForwardRightInfinity(x, y, chessboard);
            Moves.LeftInfinity(x, y, chessboard);
            Moves.RightInfinity(x, y, chessboard);
            Moves.BackInfinity(x, y, chessboard);
            Moves.BackLeftInfinity(x, y, chessboard);
            Moves.BackRightInfinity(x, y, chessboard);
        }
    }

    class King : Pieces
    {
        public override int GetNumber()
        {
            return 0;
        }

        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.Forward(x, y, chessboard);
            Moves.ForwardLeft(x, y, chessboard);
            Moves.ForwardRight(x, y, chessboard);
            Moves.Left(x, y, chessboard);
            Moves.Right(x, y, chessboard);
            Moves.Back(x, y, chessboard);
            Moves.BackLeft(x, y, chessboard);
            Moves.BackRight(x, y, chessboard);
        }
    }

    class BottomPawn : Pieces
    {
        public override int GetNumber()
        {
            return 5;
        }
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.TwoForward(x, y, chessboard);
            Moves.SkewForward(x, y, chessboard);
        }
    }

    class UpperPawn : Pieces
    {
        public override int GetNumber()
        {
            return 26;
        }
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.TwoBackward(x, y, chessboard);
            Moves.SkewBackward(x, y, chessboard);
        }
    }

    class Horse : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.Horse(x, y, chessboard);
            Moves.HorseForward(x, y, chessboard);
        }
    }

    class Rook : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.ForwardInfinity(x, y, chessboard);
            Moves.BackInfinity(x, y, chessboard);
            Moves.LeftInfinity(x, y, chessboard);
            Moves.RightInfinity(x, y, chessboard);
        }
    }

    class Bishop : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.ForwardLeftInfinity(x, y, chessboard);
            Moves.BackLeftInfinity(x, y, chessboard);
            Moves.ForwardRightInfinity(x, y, chessboard);
            Moves.BackRightInfinity(x, y, chessboard);
        }
    }

    //ještě shogi... Ještě dáma...
    class ShogiKing : Pieces
    {
        public override int GetNumber()
        {
            return 0;
        }

        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.Forward(x, y, chessboard);
            Moves.ForwardLeft(x, y, chessboard);
            Moves.ForwardRight(x, y, chessboard);
            Moves.Left(x, y, chessboard);
            Moves.Right(x, y, chessboard);
            Moves.Back(x, y, chessboard);
            Moves.BackLeft(x, y, chessboard);
            Moves.BackRight(x, y, chessboard);
        }
    }

    class ShogiRook : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.ForwardInfinity(x, y, chessboard);
            Moves.BackInfinity(x, y, chessboard);
            Moves.LeftInfinity(x, y, chessboard);
            Moves.RightInfinity(x, y, chessboard);
        }
    }

    class ShogiBishop : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.ForwardLeftInfinity(x, y, chessboard);
            Moves.BackLeftInfinity(x, y, chessboard);
            Moves.ForwardRightInfinity(x, y, chessboard);
            Moves.BackRightInfinity(x, y, chessboard);
        }
    }

    class BottomGoldGeneral : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.Forward(x, y, chessboard);
            Moves.ForwardLeft(x, y, chessboard);
            Moves.ForwardRight(x, y, chessboard);
            Moves.Left(x, y, chessboard);
            Moves.Right(x, y, chessboard);
            Moves.Back(x, y, chessboard);
        }
    }

    class UpperGoldGeneral : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.Forward(x, y, chessboard);
            Moves.BackLeft(x, y, chessboard);
            Moves.BackRight(x, y, chessboard);
            Moves.Left(x, y, chessboard);
            Moves.Right(x, y, chessboard);
            Moves.Back(x, y, chessboard);
        }
    }

    class BottomSilverGeneral : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.Forward(x, y, chessboard);
            Moves.ForwardLeft(x, y, chessboard);
            Moves.ForwardRight(x, y, chessboard);
            Moves.BackLeft(x, y, chessboard);
            Moves.BackRight(x, y, chessboard);
        }
    }

    class UpperSilverGeneral : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.Back(x, y, chessboard);
            Moves.ForwardLeft(x, y, chessboard);
            Moves.ForwardRight(x, y, chessboard);
            Moves.BackLeft(x, y, chessboard);
            Moves.BackRight(x, y, chessboard);
        }
    }

    class BottomShogiHorse : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.HorseForward(x, y, chessboard);
        }
    }

    class UpperShogiHorse : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.HorseBackward(x, y, chessboard);
        }
    }

    class BottomLance : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.ForwardInfinity(x, y, chessboard);
        }
    }

    class UpperLance : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.BackInfinity(x, y, chessboard);
        }
    }

    class ShogiBottomPawn : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.Forward(x, y, chessboard);
        }
    }

    class ShogiUpperPawn : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.Back(x, y, chessboard);
        }
    }

    class PromotedShogiRook : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.ForwardInfinity(x, y, chessboard);
            Moves.BackInfinity(x, y, chessboard);
            Moves.LeftInfinity(x, y, chessboard);
            Moves.RightInfinity(x, y, chessboard);
            Moves.BackLeft(x, y, chessboard);
            Moves.BackRight(x, y, chessboard);
            Moves.ForwardLeft(x, y, chessboard);
            Moves.ForwardRight(x, y, chessboard);
        }
    }

    class PromotedShogiBishop : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.ForwardLeftInfinity(x, y, chessboard);
            Moves.BackLeftInfinity(x, y, chessboard);
            Moves.ForwardRightInfinity(x, y, chessboard);
            Moves.BackRightInfinity(x, y, chessboard);
            Moves.Forward(x, y, chessboard);
            Moves.Back(x, y, chessboard);
            Moves.Right(x, y, chessboard);
            Moves.Left(x, y, chessboard);
        }
    }

    class BottomPromotedSilverGeneral : BottomGoldGeneral
    {

    }

    class BottomPromotedKnight : BottomGoldGeneral
    {

    }

    class BottomPromotedLance : BottomGoldGeneral
    {

    }

    class BottomPromotedPawn : BottomGoldGeneral
    {

    }


    class UpperPromotedSilverGeneral : UpperGoldGeneral
    {

    }

    class UpperPromotedKnight : UpperGoldGeneral
    {

    }

    class UpperPromotedLance : UpperGoldGeneral
    {

    }

    class UpperPromotedPawn : UpperGoldGeneral
    {

    }

    class CheckersPiece : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.CheckersTake(x, y, chessboard);
        }

    }


    //custom figurka - zavolá se dané metoda na základě toho, 
    /* class Custom
     {
         if (vybere se tento tah)
             provede_se_tah();
     } */
}
