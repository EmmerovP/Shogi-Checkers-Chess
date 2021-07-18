using GeneralBoardGames;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace GameTester
{
    class Program
    {
        /// <summary>
        /// Main function, reads user's input and then calls functions to run games.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //set encoding to unicode, so we can shows symbols of chess figures
            Console.OutputEncoding = System.Text.Encoding.Unicode;


            //loop the program
            while (true)
            {
                Game game = new Game
                {
                    shouldChessGameEnd = 0,
                    shouldCheckersGameEnd = 0
                };

                //get file with game
                GetCustomGame();

                //choose algoritm for white side
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

                //choose algorithm for black side
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

                //in case minimax algorithm was chosen, we set the parameters - depth of search tree and usage of alpha-beta pruning
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

                //in case montecarlo algorithm was chosen, we set the parameters - time used to traverse the tree
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
                                MonteCarlo.maxTime = (float)time * 1000;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Given input wasn't an integer number.");
                        }
                    }
                }

                //set additional parameters
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

                bool isCorrectNumber = false;
                int numberOfGames = 0;

                while (!isCorrectNumber)
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
                            isCorrectNumber = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Given input wasn't an integer number.");
                    }
                }

                Console.WriteLine("Playing has started...");

                List<string> information = new List<string>();

                string isEndGame = "";

                //loop playing of games
                for (int i = 0; i < numberOfGames; i++)
                {
                    //first, we initialize values - new lists for taken pieces
                    MainGameWindow.whiteShogiAIPieces = new List<Pieces>();
                    MainGameWindow.shogiAIPieces = new List<Pieces>();

                    Gameclass.CurrentGame.GameEnded = false;

                    //create a logical board for playing
                    game.CreateChessBoard(MainGameWindow.baseBoard);


                    if (visualize)
                    {
                        game.DrawBoard();
                    }

                    //set initial state of game
                    Generating.WhitePlays = true;
                    Minimax.WhiteSide = true;

                    //measure steps and time
                    int steps = 0;
                    Stopwatch sw = new Stopwatch();

                    sw.Start();

                    while (!Gameclass.CurrentGame.GameEnded)
                    {
                        isEndGame = game.MakeMove();
                        steps++;

                        if (visualize)
                        {
                            game.DrawBoard();
                        }

                        //check for end game of shogi game
                        if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi)
                        {
                            if (Gameclass.CurrentGame.KingOut(Board.board))
                            {
                                Gameclass.CurrentGame.GameEnded = true;
                                if (Generating.WhitePlays)
                                {
                                    isEndGame = "Black side won";
                                }
                                else
                                {
                                    isEndGame = "White side won";
                                }
                            }
                        }

                    }

                    sw.Stop();
                    int gameNumber = i + 1;

                    information.Add(gameNumber + ": " + isEndGame + ", " + steps + " steps were made, " + sw.Elapsed + " elapsed time.");
                    Console.WriteLine("Game number " + gameNumber + " has been finished.");
                }

                Console.WriteLine();
                Console.WriteLine("Results:");

                for (int i = 0; i < information.Count; i++)
                {
                    Console.WriteLine(information[i]);
                }
            }

        }

        /// <summary>
        /// Loads custom game and checks validity of the file
        /// </summary>
        public static void GetCustomGame()
        {
            bool succes = false;

            while (!succes)
            {

                Console.WriteLine("Specify the filepath to the file with game:");

                string file = Console.ReadLine();

                LoadGame loadGame = new LoadGame();


                try
                {
                    loadGame.GetGame(file);
                    succes = true;
                }
                catch (Exception exception)
                {
                    Console.WriteLine("File couldn't be loaded: " + exception);
                }
            }
        }
    }


    class Game
    {
        /// <summary>
        /// Is true when white side plays with minimax algorithm, false when it plays with MCTS.
        /// </summary>
        public bool whiteMinimax;

        /// <summary>
        /// Is true when black side plays with minimax algorithm, false when it plays with MCTS.
        /// </summary>
        public bool blackMinimax;

        /// <summary>
        /// Counts number of repeating moves, ends game with draw when it takes too long.
        /// </summary>
        public int shouldChessGameEnd;

        /// <summary>
        /// Counts number of repeating moves, ends game with draw when it takes too long.
        /// </summary>
        public int shouldCheckersGameEnd;

        /// <summary>
        /// From numeric representation of board, creates logical one with Pieces
        /// </summary>
        /// <param name="chessboard"></param>
        public void CreateChessBoard(int[,] chessboard)
        {
            int dimension = chessboard.GetLength(0);
            Board.board = new Pieces[dimension, dimension];

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (chessboard[i, j] != -1)
                    {
                        Board.AddPiece(chessboard[i, j], i, j, Board.board);
                    }
                }
            }

        }

        /// <summary>
        /// Plays one move
        /// </summary>
        /// <returns></returns>
        public string MakeMove()
        {

            //remember current parameters in case algorithms change them
            bool whitePlays = Generating.WhitePlays;
            Gameclass.GameType playType = Gameclass.CurrentGame.playType;
            Gameclass.GameType gameType = Gameclass.CurrentGame.gameType;

            Moves.EmptyCoordinates();

            int move;

            //get chosen algorithm and generate a move
            if ((whitePlays && whiteMinimax) || (!whitePlays && blackMinimax))
            {
                move = Minimax.GetNextMove();

            }
            else
            {
                move = MonteCarlo.GetNextMove(whitePlays);
            }

            Gameclass.CurrentGame.playType = playType;
            Gameclass.CurrentGame.gameType = gameType;

            //we can't make a move - one side must have won
            if (move == -1)
            {
                Gameclass.CurrentGame.GameEnded = true;
                if (whitePlays == true)
                {
                    return "Black side won";
                }
                else
                {
                    return "White side won";
                }
            }

            //we are taking a piece in a game of shogi type - we add it to a list
            if ((Gameclass.CurrentGame.blackPlayType == Gameclass.GameType.shogi && whitePlays == false ||
               Gameclass.CurrentGame.whitePlayType == Gameclass.GameType.shogi && whitePlays == true) &&
               Board.board[Moves.final_x[move], Moves.final_y[move]] != null)
            {
                if (whitePlays)
                {
                    MainGameWindow.whiteShogiAIPieces.Add(Board.board[Moves.final_x[move], Moves.final_y[move]]);
                }
                else
                {
                    MainGameWindow.shogiAIPieces.Add(Board.board[Moves.final_x[move], Moves.final_y[move]]);
                }
            }

            //for chess, end game after 50 moves without taking a figure or moving a pawn
            if ((Gameclass.CurrentGame.blackGameType == Gameclass.GameType.chess && whitePlays == false ||
               Gameclass.CurrentGame.whiteGameType == Gameclass.GameType.chess && whitePlays == true ||
               Gameclass.CurrentGame.gameType == Gameclass.GameType.chess) && (!Minimax.isAddingPiece) && (!MonteCarlo.isAddingPiece) &&
               (Board.board[Moves.final_x[move], Moves.final_y[move]] == null && (Board.board[Moves.start_x[move], Moves.start_y[move]] != null && (!PiecesNumbers.IsPawn(Board.board[Moves.start_x[move], Moves.start_y[move]])))))
            {
                shouldChessGameEnd++;
            }
            else
            {
                shouldChessGameEnd = 0;
            }


            //for checkers, end game after 50 moves only with queen
            if ((Gameclass.CurrentGame.blackGameType == Gameclass.GameType.checkers && whitePlays == false ||
                Gameclass.CurrentGame.whiteGameType == Gameclass.GameType.checkers && whitePlays == true ||
                Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers) && (!Minimax.isAddingPiece) && (!MonteCarlo.isAddingPiece) &&
                (Board.board[Moves.start_x[move], Moves.start_y[move]].GetNumber() == PiecesNumbers.getNumber["Bílá dáma"] || Board.board[Moves.start_x[move], Moves.start_y[move]].GetNumber() == PiecesNumbers.getNumber["Černá dáma"]))
            {
                shouldCheckersGameEnd++;
            }
            else
            {
                shouldCheckersGameEnd = 0;
            }

            //whether we should add a piece to board, or move a piece
            if (Minimax.isAddingPiece || MonteCarlo.isAddingPiece)
            {
                Board.AddPiece(Moves.start_x[move], Moves.final_x[move], Moves.final_y[move], Board.board);
            }
            else
            {
                MoveController.ApplyMove(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move], Board.board);
            }


            //get ready for opponent
            Generating.WhitePlays = whitePlays;

            Minimax.WhiteSide = !Minimax.WhiteSide;

            Generating.WhitePlays = !Generating.WhitePlays;

            Minimax.isAddingPiece = false;


            //check if the game should end in draw
            if (shouldChessGameEnd > 49)
            {
                Gameclass.CurrentGame.GameEnded = true;
                return "Draw";
            }

            if (shouldCheckersGameEnd > 49)
            {
                Gameclass.CurrentGame.GameEnded = true;
                return "Draw";
            }

            return "";
        }

        /// <summary>
        /// draws 2D board on console, each field consists of 3 spaces
        /// </summary>
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
                        //checks whether the symbol is in dictionary, else just write its number
                        int number = Board.board[i, j].GetNumber();
                        try
                        {
                            Console.Write("|" + getSymbol[number] + "|");
                        }
                        catch
                        {
                            if (number < 10)
                            {
                                Console.Write("| " + number + " |");
                            }
                            else if (number > 9 && number < 100)
                            {
                                Console.Write("|" + number + " |");
                            }
                            else
                            {
                                Console.Write("|" + number + "|");
                            }
                        }

                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Dictionary with symbol which we draw on the board
        /// </summary>
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
