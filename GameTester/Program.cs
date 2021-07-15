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
                    default:
                        Main(args);
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

                if (game.blackMinimax || game.whiteMinimax)
                {
                    Console.WriteLine("Choose a depth of minimax tree:");
                    bool isCorrectDepth = false;

                    while (!isCorrectDepth)
                    {
                        string depth = Console.ReadLine();
                        bool isNumber = Int32.TryParse(depth, out Minimax.treeSearchDepth);

                        if (isNumber)
                        {

                            if (Minimax.treeSearchDepth < 1 || Minimax.treeSearchDepth > 10)
                            {
                                Console.WriteLine("Number has to be between 1 and 10.");
                            }
                            else
                            {
                                isCorrectDepth = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Given input wasn't an integer number.");
                        }
                    }

                    Console.WriteLine("Use alpha-beta pruning (yes/no):");



                    bool isCorrectAnswer = false;

                    while (!isCorrectAnswer)
                    {
                        string useAlphaBeta = Console.ReadLine();


                        if (useAlphaBeta == "yes")
                        {
                            Minimax.useAlphaBetaPruning = true;
                            isCorrectAnswer = true;
                        }
                        else if (useAlphaBeta == "no")
                        {
                            Minimax.useAlphaBetaPruning = false;
                            isCorrectAnswer = true;
                        }
                        else
                        {
                            Console.WriteLine("Please indicate by typing yes or no.");
                        }
                    }
                }

                if (!game.blackMinimax || !game.whiteMinimax)
                {
                    Console.WriteLine("Time for Monte Carlo Tree Search in seconds:");
                    bool isCorrectTime = false;

                    while (!isCorrectTime)
                    {
                        string depth = Console.ReadLine();
                        bool isNumber = Int32.TryParse(depth, out int time);

                        if (isNumber)
                        {
                            if (time < 1 || time > 100)
                            {
                                Console.WriteLine("Number od seconds has to be between 1 and 100.");
                            }
                            else
                            {
                                isCorrectTime = true;
                                MonteCarlo.maxTime = (float)time;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Given input wasn't an integer number.");
                        }
                    }
                }

                Console.WriteLine("Should the progress of a game be visualized? (yes/no):");

                var answer = Console.ReadLine();

                bool visualize = false;

                switch (answer)
                {
                    case "yes":
                        visualize = true;
                        break;
                    case "no":
                        visualize = false;
                        break;
                    default:
                        Main(args);
                        break;
                }

                Console.WriteLine("Number of games:");

                bool isCorrentNumber = false;
                int numberOfGames = 0;

                while (!isCorrentNumber)
                {
                    string depth = Console.ReadLine();
                    bool isNumber = Int32.TryParse(depth, out numberOfGames);

                    if (isNumber)
                    {
                        if (numberOfGames < 1 || numberOfGames > 100)
                        {
                            Console.WriteLine("Number has to be between 1 and 100.");
                        }
                        else
                        {
                            isCorrentNumber = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Given input wasn't an integer number.");
                    }
                }

                MainGameWindow.whiteShogiAIPieces = new List<Pieces>();
                MainGameWindow.shogiAIPieces = new List<Pieces>();

                Gameclass.CurrentGame.GameEnded = false;

                game.CreateChessBoard(chessboard);



                Generating.WhitePlays = true;
                Minimax.WhiteSide = true;

                List<string> information = new List<string>();

                game.DrawBoard();

                for (int i = 0; i < numberOfGames; i++)
                {
                    int steps = 0;
                    Stopwatch sw = new Stopwatch();

                    sw.Start();

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

        }

        public static void GetCustomGame()
        {
            Console.WriteLine("Specify the filepath to the file with game:");

            string file = Console.ReadLine();

            LoadGame loadGame = new LoadGame();

            loadGame.GetGame(file);


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


            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi && (Minimax.isAddingPiece || MonteCarlo.isAddingPiece))
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
                        Console.Write("|   |");
                    }
                    else
                    {
                        int number = Board.board[i, j].GetNumber();
                        Console.Write("|" + getSymbol[number] + "|");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(1000);
        }

        public Dictionary<int, string> getSymbol = new Dictionary<int, string>()
        {
            { 0, " ♔ " },
            { 1, " ♕ " },
            { 2, " ♖ " },
            { 3, " ♘ " },
            { 4, " ♗ " },
            { 5, " ♙ " },
            { 6, " ♙ " },
            { 7, " ♕ " },
            { 8, "☖K " },
            { 9, "☖R " },
            { 10, "☖R+" },
            { 11, "☖B " },
            { 12, "☖B+" },
            { 13, "☖G " },
            { 14, "☖S " },
            { 15, "☖S+" },
            { 16, "☖N " },
            { 17, "☖N+" },
            { 18, "☖L " },
            { 19, "☖L+" },
            { 20, "☖P " },
            { 21, "☖P+" },
            { 22, " ♚ " },
            { 23, " ♛ " },
            { 24, " ♜ " },
            { 25, " ♞ " },
            { 26, " ♝ " },
            { 27, " ♟ " },
            { 28, " ♟ " },
            { 29, " ♛ " },
            { 30, "☗K " },
            { 31, "☗R " },
            { 32, "☗R+" },
            { 33, "☗B " },
            { 34, "☗B+" },
            { 35, "☗G " },
            { 36, "☗S " },
            { 37, "☗S+" },
            { 38, "☗N " },
            { 39, "☗N+" },
            { 40, "☗L " },
            { 41, "☗L+" },
            { 42, "☗P " },
            { 43, "☗P+" }
        };
    }
}
