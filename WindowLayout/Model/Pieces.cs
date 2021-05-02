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
        {23,24,25,22,21,25,24,23},
        {26,26,26,26,26,26,26,26},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {5,5,5,5,5,5,5,5},
        {2,3,4,1,0,4,3,2}
        };

        /*
        
        //šach mat - ukázková šachovnice
        public static int[,] chess = new int[,] {
        {23,-1,-1,22,21,-1,-1,23},
        {26,26,26,26,26,26,26,26},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {5,5,5,5,5,5,5,5},
        {2,-1,-1,1,0,-1,-1,2}
        }; 
        */
        //základní rozestavení figurek shogi
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

        /*//testovací rozestavění figurek shogi
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
        */
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

        /*
        //testové rozestavení figurek dámy
        public static int[,] checkers = new int[,] {
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,6,-1,6,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,27,-1,-1,-1,27,-1,-1},
        {-1,-1,22,-1,-1,-1,-1,-1},
        };  */
    }

    public class DefinedPiece
    {
        public int[] moves;
        public int Value;
        public bool isWhite;
        public string Name;
    }

    

    public class Pieces
    {

        public static List<DefinedPiece> DefinedPieces;

        public virtual void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {

        }

        public virtual bool Moved { get; set; } = false;
        public bool isWhite;

        public virtual int Value { get; set; } = 0;

        public virtual string Name { get; protected set; }

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
        public override int Value { get; set; } = 90;

        public override string Name { get; protected set; } = "Dáma";
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
        public override bool Moved { get; set; } = false;
        public override int Value { get; set; } = 900;
        public override string Name { get; protected set; } = "Král";
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
            Moves.Castling(x, y, chessboard);
        }
    }

    class BottomPawn : Pieces
    {
        public override int Value { get; set; } = 10;
        public override string Name { get; protected set; } = "Pěšec";
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.PawnTwoForward(x, y, chessboard);
            Moves.PawnSkewForward(x, y, chessboard);
            Moves.BottomEnPassante(x, y, chessboard);
        }
    }

    class UpperPawn : Pieces
    {
        public override int Value { get; set; } = 10;
        public override string Name { get; protected set; } = "Pěšec";
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.PawnTwoBackward(x, y, chessboard);
            Moves.PawnSkewBackward(x, y, chessboard);
            Moves.UpperEnPassante(x, y, chessboard);
        }
    }

    class Horse : Pieces
    {
        public override int Value { get; set; } = 30;
        public override string Name { get; protected set; } = "Kůň";
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.Horse(x, y, chessboard);
            Moves.HorseForward(x, y, chessboard);
        }
    }

    class Rook : Pieces
    {
        public override int Value { get; set; } = 50;
        public override string Name { get; protected set; } = "Věž";
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
        public override int Value { get; set; } = 30;
        public override string Name { get; protected set; } = "Střelec";
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
        public override int Value { get; set; } = 900;
        public override string Name { get; protected set; } = "Shogi král";
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
        public override int Value { get; set; } = 50;
        public override string Name { get; protected set; } = "Shogi věž";
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
        public override int Value { get; set; } = 30;
        public override string Name { get; protected set; } = "Shogi střelec";
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
        public override int Value { get; set; } = 70;
        public override string Name { get; protected set; } = "Zlatý generál";
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
        public override int Value { get; set; } = 70;
        public override string Name { get; protected set; } = "Zlatý generál";
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
        public override int Value { get; set; } = 60;
        public override string Name { get; protected set; } = "Stříbrný generál";
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
        public override int Value { get; set; } = 60;
        public override string Name { get; protected set; } = "Stříbrný generál";
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
        public override int Value { get; set; } = 30;
        public override string Name { get; protected set; } = "Shogi kůň";
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.HorseForward(x, y, chessboard);
        }
    }

    class UpperShogiHorse : Pieces
    {
        public override int Value { get; set; } = 30;
        public override string Name { get; protected set; } = "Shogi kůň";
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.HorseBackward(x, y, chessboard);
        }
    }

    class BottomLance : Pieces
    {
        public override int Value { get; set; } = 30;
        public override string Name { get; protected set; } = "Kopiník";
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.ForwardInfinity(x, y, chessboard);
        }
    }

    class UpperLance : Pieces
    {
        public override int Value { get; set; } = 30;
        public override string Name { get; protected set; } = "Kopiník";
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.BackInfinity(x, y, chessboard);
        }
    }

    class ShogiBottomPawn : Pieces
    {
        public override int Value { get; set; } = 10;
        public override string Name { get; protected set; } = "Shogi pěšák";
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.Forward(x, y, chessboard);
        }
    }

    class ShogiUpperPawn : Pieces
    {
        public override int Value { get; set; } = 10;
        public override string Name { get; protected set; } = "Shogi pěšák";
        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.Back(x, y, chessboard);
        }
    }

    class PromotedShogiRook : Pieces
    {
        public override int Value { get; set; } = 60;
        public override string Name { get; protected set; } = "Shogi věž";
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
        public override int Value { get; set; } = 40;
        public override string Name { get; protected set; } = "Shogi střelec";
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
        public override string Name { get; protected set; } = "Stříbrný generál";
        public override int Value { get; set; } = 70;

    }

    class BottomPromotedKnight : BottomGoldGeneral
    {
        public override string Name { get; protected set; } = "Shogi kůň";
        public override int Value { get; set; } = 40;

    }

    class BottomPromotedLance : BottomGoldGeneral
    {
        public override string Name { get; protected set; } = "Kopiník";
        public override int Value { get; set; } = 40;

    }

    class BottomPromotedPawn : BottomGoldGeneral
    {
        public override string Name { get; protected set; } = "Shogi pěšák";
        public override int Value { get; set; } = 20;

    }


    class UpperPromotedSilverGeneral : UpperGoldGeneral
    {
        public override string Name { get; protected set; } = "Stříbrný generál";
        public override int Value { get; set; } = 70;

    }

    class UpperPromotedKnight : UpperGoldGeneral
    {
        public override string Name { get; protected set; } = "Shogi kůň";
        public override int Value { get; set; } = 40;

    }

    class UpperPromotedLance : UpperGoldGeneral
    {
        public override string Name { get; protected set; } = "Kopiník";
        public override int Value { get; set; } = 40;

    }

    class UpperPromotedPawn : UpperGoldGeneral
    {
        public override string Name { get; protected set; } = "Shogi pěšák";
        public override int Value { get; set; } = 20;

    }

    class WhiteCheckersPiece : Pieces
    {
        public override int Value { get; set; } = 10;

        public override string Name { get; protected set; } = "Kámen";

        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.WhiteChecker(x, y, chessboard);
        }

    }

    class BlackCheckersPiece : Pieces
    {
        public override int Value { get; set; } = 10;

        public override string Name { get; protected set; } = "Kámen";

        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.BlackChecker(x, y, chessboard);
        }

    }


    class Custom : Pieces
     {
        Action<int, int, Pieces[,]>[] moves; 

        public override int Value { get; set; }

        public override string Name { get; protected set; }

        public Custom(int[] numbersOfMoves, string name, int value)
        {
            moves = new Action<int, int, Pieces[,]>[numbersOfMoves.Length];
            for (int i = 0; i < moves.Length; i++)
            {
                moves[i] = PiecesNumbers.getMovefromNumber[numbersOfMoves[i]];
            }

            Name = name;
            Value = value;
        }

        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            foreach (var move in moves)
            {
                move(x, y, chessboard);
            }       
        }


    } 
}
