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
                    default:
                        Main(args);
                        break;
                }

                MainGameWindow.whiteShogiAIPieces = new List<Pieces>();
                MainGameWindow.shogiAIPieces = new List<Pieces>();

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
        const bool CUSTOMCHESSBOARD = false;


        public void CreateChessBoard(int[,] chessboard)
        {
            if (CUSTOMCHESSBOARD)
            {
                chessboard = new int[,] {
        {-1,-1,-1,-1,-1,1,1,-1},
        {-1,-1,-1,-1,-1,-1,-1,1},
        {-1,-1,-1,-1,-1,-1,-1,1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {22,-1,-1,-1,-1,-1,-1,-1},
        {22,-1,-1,-1,-1,-1,-1,-1},
        {-1,22,22,-1,-1,-1,-1,-1},
        };
            }



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
            bool player = Generating.WhitePlays;

            Moves.EmptyCoordinates();
            int move = MonteCarlo.MonteCarloMove(player);

            //int move = Minimax.GetNextMove();
            /*
            int move;

            if (player)
            {
                move = MonteCarlo.MonteCarloMove(player);

            }
            else
            {
                move = Minimax.GetNextMove();
            }
            */
            //int move = MonteCarlo.FindRandomMove(Board.board);

            if (move == -1)
            {
                Gameclass.CurrentGame.GameEnded = true;
                return;
            }

            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi && Board.board[Moves.final_x[move], Moves.final_y[move]] != null)
            {
                if (player)
                {
                    MainGameWindow.whiteShogiAIPieces.Add(Board.board[Moves.final_x[move], Moves.final_y[move]]);
                }
                else
                {
                    MainGameWindow.shogiAIPieces.Add(Board.board[Moves.final_x[move], Moves.final_y[move]]);
                }
            }


            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi && Minimax.isAddingPiece)
            {
                Board.AddPiece(Moves.start_x[move], Moves.final_x[move], Moves.final_y[move], Board.board);
            }
            else
            {
                MoveController.ApplyMove(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move], Board.board);
            }




            /*
            int move;
            
            if (Generating.WhitePlays)
            {
                move = Minimax.GetNextMove();
            }
            else
            {
                move =  MonteCarlo.MonteCarloMove(player);
            }*/

            Generating.WhitePlays = player;

            Minimax.WhiteSide = !Minimax.WhiteSide;

            Generating.WhitePlays = !Generating.WhitePlays;

            Minimax.isAddingPiece = false;
        }

        public void DrawBoard()
        {
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(1); j++)
                {
                    if (Board.board[i, j] == null)
                    {
                        if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi)
                        {
                            Console.Write("|  |");
                        }
                        else
                        {
                            Console.Write("| |");
                        }

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
                            case 7:
                                Console.Write("|07|");
                                break;
                            case 8:
                                Console.Write("|08|");
                                break;
                            case 9:
                                Console.Write("|09|");
                                break;
                            default:
                                Console.Write("|" + number + "|");
                                break;
                        }



                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
