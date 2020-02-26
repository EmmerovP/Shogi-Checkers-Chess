using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiCheckersChess
{
    public static class GameStarts
    {
        //soubor    

        //základní rozestavení šachových figurek
        public static int[,] chess = new int[,] {
        {23,24,25,21,22,25,24,23},
        {26,26,26,26,26,26,26,26},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {5,5,5,5,5,5,5,5},
        {2,3,4,0,1,4,3,2}
        };

        /*//šach mat - ukázková šachovnice
        public static int[,] chess = new int[,] {
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,5,5,5,5,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {1,-1,-1,-1,-1,-1,-1,-1},
        {1,-1,-1,26,26,26,26,-1},
        {-1,-1,-1,-1,-1,-1,-1,21},
        };*/

         
        /*//základní rozestavení figurek shogi
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
        };*/

        //testovací rozestavění figurek shogi
        public static int[,] shogi = new int[,] {
        {-1,-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,19,8,-1,13,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,38,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,40,-1,31,29,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1,-1},
        };

        //základní rozestavení figurek dámy
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


        /*//testové rozestavení figurek dámy
        public static int[,] checkers = new int[,] {
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,6,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,27,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        }; */
    }


    public class Pieces
    {
        public virtual void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {

        }
        public bool moved;
        public bool isWhite;
        int number;
        public int GetNumber()
        {
            return number;
        }

        public void SetNumber(int value)
        {
            number = value;
        }
    }

    //šachy
    //nápady: číslo figurky je asi zbytečné, lepší je, na které straně je - white a !white, kvůli vyhazování
    //nějaký public static na zjištění kdo je na tahu
    class Queen : Pieces
    {
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
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.TwoForward(x, y, chessboard);
            Moves.SkewForward(x, y, chessboard);
        }
    }

    class UpperPawn : Pieces
    {
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

    class WhiteCheckersPiece : Pieces
    {
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.CheckersTake(x, y, chessboard);
        }

    }

    class BlackCheckersPiece : Pieces
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
