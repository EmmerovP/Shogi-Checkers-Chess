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

            Console.OutputEncoding = System.Text.Encoding.Unicode;

            while (true)
            {
                Game game = new Game();

                Console.WriteLine("Choose a type of game (chess, shogi, checkers, other): ");

                int[,] chessboard = new int[8, 8];

                string TypeOfGame = Console.ReadLine();

                switch (TypeOfGame)
                {
                    case "chess":
                        chessboard = GameStart.chess;
                        Gameclass.CurrentGame.gameType = Gameclass.GameType.chess;
                        break;
                    case "checkers":
                        chessboard = GameStart.checkers;
                        Gameclass.CurrentGame.gameType = Gameclass.GameType.checkers;
                        break;
                    case "shogi":
                        chessboard = GameStart.shogi;
                        Gameclass.CurrentGame.gameType = Gameclass.GameType.shogi;
                        break;
                    case "other":
                        GetCustomGame();
                        break;
                    default:
                        Main(args);
                        break;
                }

                Console.WriteLine("Choose playing algorithm for white side (minimax, montecarlo):");

                var algorithm = Console.ReadLine();

                switch (algorithm)
                {
                    case "minimax":
                        game.whiteMinimax = true;
                        break;
                    case "montecarlo":
                        game.whiteMinimax = false;
                        break;
                    default: Main(args);
                        break;
                }

                Console.WriteLine("Choose playing algorithm for black side (minimax, montecarlo):");

                algorithm = Console.ReadLine();

                switch (algorithm)
                {
                    case "minimax":
                        game.blackMinimax = true;
                        break;
                    case "montecarlo":
                        game.blackMinimax = false;
                        break;
                    default:
                        Main(args);
                        break;
                }

                Console.WriteLine("Should the progress of a game be visualized? (yes/no):");

                var answer = Console.ReadLine();

                bool visualize = false;

                switch (answer)
                {
                    case "yes": visualize = true;
                        break;
                    case "no": visualize = false;
                        break;
                    default: Main(args);
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

                    if (visualize)
                    {
                        game.DrawBoard();
                    }
                

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

        public static void GetCustomGame()
        {
            Console.WriteLine("Specify the filepath to the file with game:");

            string file = Console.ReadLine();

            LoadGame.GetGame(file);


        }
    }

    class Game
    {
        const bool CUSTOMCHESSBOARD = false;

        public bool whiteMinimax;
        public bool blackMinimax;


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
        {-1,22,22,-1,-1,-1,-1,-1}
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

            int move;

            if ((player && whiteMinimax) || (!player && blackMinimax))
            {
                move = Minimax.GetNextMove();

            }
            else
            {
                move = MonteCarlo.GetNextMove(player);
            }


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


            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi && (Minimax.isAddingPiece|| MonteCarlo.isAddingPiece))
            {
                Board.AddPiece(Moves.start_x[move], Moves.final_x[move], Moves.final_y[move], Board.board);
            }
            else
            {
                MoveController.ApplyMove(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move], Board.board);
            }

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
            //System.Threading.Thread.Sleep(1000);
        }
    }
}
