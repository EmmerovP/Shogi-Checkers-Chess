using System;
using System.Threading;
using ShogiCheckersChess;

public class ServerClass
{
    const int MIN_ITERATIONS = int.MaxValue / 1000;
    const int MAX_ITERATIONS = MIN_ITERATIONS + 10000;

    long m_totalIterations = 0;
    readonly object m_totalItersLock = new object();
    // The method that will be called when the thread is started.
    public void DoWork()
    {
        Console.WriteLine(
            "ServerClass.InstanceMethod is running on another thread.");

        var x = GetNumber();
    }

    private int GetNumber()
    {
        var rand = new Random();
        var iters = rand.Next(MIN_ITERATIONS, MAX_ITERATIONS);
        var result = 0;
        lock (m_totalItersLock)
        {
            m_totalIterations += iters;
        }
        // we're just spinning here
        // and using Random to frustrate compiler optimizations
        for (var i = 0; i < iters; i++)
        {
            result = rand.Next();
        }
        return result;
    }
}

public class Simple
{
    public static void Main()
    {
        for (int i = 0; i < 1; i++)
        {
            CreateThreads();
        }
    }
    public static void CreateThreads()
    {
        Game game = new Game();
        Gameclass.CurrentGame.GameEnded = false;
        string TypeOfGame = Console.ReadLine();
        int[,] chessboard = new int[8, 8];
        chessboard = GameStarts.chess;
        Gameclass.CurrentGame.gameType = Gameclass.GameType.chess;
        game.CreateChessBoard(chessboard);

        Thread InstanceCaller = new Thread(new ThreadStart(game.MakeMove));
        // Start the thread.
        InstanceCaller.Start();

        Console.WriteLine("The Main() thread calls this after "
            + "starting the new InstanceCaller thread.");

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
        while (move != -1)
        {
            Gameclass.CurrentGame.GameEnded = true;
        }

        RandomMoveGen.WhiteSide = !RandomMoveGen.WhiteSide;

        //DrawBoard();
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