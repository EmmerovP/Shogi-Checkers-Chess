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
            Console.OutputEncoding = System.Text.Encoding.Unicode;
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

                Generating.WhitePlays = true;
                Minimax.WhiteSide = true;

                while (!Gameclass.CurrentGame.GameEnded)
                {
                    game.MakeMove();
                    steps++;

                    game.DrawBoard();
                 

                    if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi)
                    {
                        if (Gameclass.CurrentGame.KingOut(Board.board))
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
                        Board.AddPiece(chessboard[i, j], i, j, Board.board);
                }
            }
        }

        public void MakeMove()
        {
            int move = MonteCarlo.FindRandomMove(Board.board);
            /*
            if (Generating.WhitePlays)
            {
                move = Minimax.GetNextMove();
            }
            else
            {
                move = MonteCarlo.FindRandomMove(Board.board);
            }*/


            if (move == -1)
            {
                Gameclass.CurrentGame.GameEnded = true;
                return;
            }

            MoveController.ApplyMove(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move], Board.board);

            Minimax.WhiteSide = !Minimax.WhiteSide;

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
                        Console.Write("| |");
                    }
                    else
                    {
                        int number = Board.board[i, j].GetNumber();
                         switch (number)
                        {
                            case 0: 
                                Console.Write("|♔|");
                                break;
                            case 1:
                                Console.Write("|♕|");
                                break;
                            case 2:
                                Console.Write("|♖|");
                                break;
                            case 3:
                                Console.Write("|♘|");
                                break;
                            case 4:
                                Console.Write("|♗|");
                                break;
                            case 5:
                                Console.Write("|♙|");
                                break;
                            case 6:
                                Console.Write("|♙|");
                                break;
                            case 21:
                                Console.Write("|♚|");
                                break;
                            case 22:
                                Console.Write("|♛|");
                                break;
                            case 23:
                                Console.Write("|♜|");
                                break;
                            case 24:
                                Console.Write("|♞|");
                                break;
                            case 25:
                                Console.Write("|♝|");
                                break;
                            case 26:
                                Console.Write("|\x265F|");
                                break;
                            case 27:
                                Console.Write("|\x265F|");
                                break;
                            default: Console.Write("|"+ number +"|");
                                break;
                        }
                        

                        
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //System.Threading.Thread.Sleep(500);
        }
    }
}
