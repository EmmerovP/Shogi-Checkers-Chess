﻿using System;
using System.Collections.Generic;

namespace GeneralBoardGames
{
    /// <summary>
    /// Holds parameters needed for creation of a piece defined by user.
    /// </summary>
    public class DefinedPiece
    {
        /// <summary>
        /// List of moves of a piece, represented by integer array
        /// </summary>
        public int[] moves;

        /// <summary>
        /// Evaluation for minimax algorithm
        /// </summary>
        public int Value;

        /// <summary>
        /// True when the piece is on white/bottom side
        /// </summary>
        public bool isWhite;

        /// <summary>
        /// Piece's name
        /// </summary>
        public string Name;
    }


    /// <summary>
    /// Class all pieces inherit from.
    /// </summary>
    public class Pieces
    {

        /// <summary>
        /// Global list of pieces defined by user
        /// </summary>
        public static List<DefinedPiece> DefinedPieces;

        /// <summary>
        /// From a field given by coordinates, generate new moves for its piece
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="chessboard"></param>
        public virtual void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {

        }

        /// <summary>
        /// For a king in castling, true when king was moves
        /// </summary>
        public virtual bool Moved { get; set; } = false;

        /// <summary>
        /// True when a piece is white/belongs to the bottom side
        /// </summary>
        public bool isWhite;

        /// <summary>
        /// Evaluation for minimax algorithm
        /// </summary>
        public virtual int Value { get; set; } = 0;

        /// <summary>
        /// Name of piece
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Number representation of piece
        /// </summary>
        private int number;

        /// <summary>
        /// Get number of representation of piece
        /// </summary>
        /// <returns></returns>
        public int GetNumber()
        {
            return number;
        }

        /// <summary>
        /// Set number of piece
        /// </summary>
        /// <param name="value"></param>
        public void SetNumber(int value)
        {
            number = value;
        }
    }


    class Queen : Pieces
    {
        public override int Value { get; set; } = 500;

        public override string Name { get; protected set; } = "Královna";
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
        public override int Value { get; set; } = 30;
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
        public override int Value { get; set; } = 30;
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
        public override int Value { get; set; } = 30;
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
        public override int Value { get; set; } = 30;
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

    class CheckersQueen : Pieces
    {
        public override int Value { get; set; } = 90;

        public override string Name { get; protected set; } = "Dáma";

        public override void GenerateMoves(int x, int y, Pieces[,] chessboard)
        {
            Moves.CheckersQueen(x, y, chessboard);
        }
    }

    /// <summary>
    /// User defined piece.
    /// </summary>
    class Custom : Pieces
    {
        readonly Action<int, int, Pieces[,]>[] moves;

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
