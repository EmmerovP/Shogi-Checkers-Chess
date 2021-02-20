using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShogiCheckersChess;
using System.Diagnostics;


namespace ConsoleApplication2
{
    class Program
    {

        static void Main(string[] args)
        {
            Game game = new Game();
            while (true)
            {
                Console.WriteLine("Choose a type of game (chess, shogi, checkers): ");

                int[,] chessboard = new int[8, 8];

                string TypeOfGame = Console.ReadLine();

                switch (TypeOfGame)
                {
                    case "chess":
                        chessboard = GameStarts.chess;
                        Gameclass.CurrentGame.gameType = Gameclass.GameType.chess;
                        break;
                    case "checkers":
                        chessboard = GameStarts.checkers;
                        Gameclass.CurrentGame.gameType = Gameclass.GameType.checkers;
                        break;
                    case "shogi":
                        chessboard = GameStarts.shogi;
                        Gameclass.CurrentGame.gameType = Gameclass.GameType.shogi;
                        break;
                }

                Gameclass.CurrentGame.GameEnded = false;

                game.CreateChessBoard(chessboard);

                int steps = 0;
                Stopwatch sw = new Stopwatch();

                sw.Start();
                while (!Gameclass.CurrentGame.GameEnded)
                {
                    game.MakeMove();
                    steps++;

                    if (steps%10 == 0)
                    {
                        game.DrawBoard();
                    }                  

                    if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi)
                    {
                        if (Gameclass.CurrentGame.KingOut())
                        {
                            Gameclass.CurrentGame.GameEnded = true;
                        }
                    }
                }
                sw.Stop();
                Console.WriteLine();
                Console.WriteLine("Elapsed={0}", sw.Elapsed);
                Console.WriteLine("Number of steps: " + steps);

            }

        }
    }

    class Game
    {
        public void CreateChessBoard(int[,] chessboard)
        {
            int dimension = chessboard.GetLength(0);
            Board.board = new Pieces[dimension, dimension];

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (chessboard[i, j] != -1)
                        Board.AddPiece(chessboard[i, j], i, j);
                }
            }
        }

        public void MakeMove()
        {
            

            int move = RandomMoveGen.FindPiece();
            if (move == -1)
            {
                Gameclass.CurrentGame.GameEnded = true;
                return;
            }

            int start_x = Moves.start_x[move];
            int start_y = Moves.start_y[move];

            int final_x = Moves.final_x[move];
            int final_y = Moves.final_y[move];


            Pieces piece = Board.board[start_x, start_y];
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
                Board.board[xpiece, ypiece] = null;
            }

            Board.board[final_x, final_y] = piece;
            Board.board[start_x, start_y] = null;

            Generating.WhitePlays = !Generating.WhitePlays;


        }

        public void DrawBoard()
        {
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(1); j++)
                {
                    if (Board.board[i, j] == null)
                    {
                        Console.Write("|O|");
                    }
                    else
                    {
                        Console.Write("|" + Board.board[i, j].GetNumber() + "|");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
