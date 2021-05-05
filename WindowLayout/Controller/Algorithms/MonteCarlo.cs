using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShogiCheckersChess
{

    public class MonteCarlo
    {

        public class Node
        {
            public Pieces[,] board;
            public Node parent;
            public int numberOfSimulations;
            public int wins;
            public List<Node> children;
            public bool WhitePlays; 
            public int id;

            public int start_x;
            public int start_y;
            public int final_x;
            public int final_y;
        }

        public static int MonteCarloMove()
        {

            var rootnode = new Node
            {
                children = new List<Node>(),
                WhitePlays = false,
                board = Board.board.Clone() as Pieces[,],
                numberOfSimulations = 1,
                wins = 0,
                parent = null,
                id = 0
            };

            var node = MonteCarloRoot(rootnode);

            Moves.final_x.Add(node.final_x);
            Moves.final_y.Add(node.final_y);
            Moves.start_x.Add(node.start_x);
            Moves.start_y.Add(node.start_y);

            return 0;

        }


        const float MAXTIME = 3000.0F;
        const int LOOPS = 2000;

        public static Node MonteCarloRoot(Node Root)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            int steps = 0;

            while (time.ElapsedMilliseconds < MAXTIME)
            {
                Node highest_UCB = Selection(Root);
                Node leaf = Expansion(highest_UCB);
                int reward = Rollout(leaf);
                Backpropagation(leaf, reward);

                steps++;
            }

            return BestChild(Root);
        }

        public static Node Selection(Node node)
        {
            Node selected_child = node;

            while (selected_child.children.Count != 0)
            {
                double max_ucb = Double.MinValue;

                if (double.IsNaN(max_ucb))
                {
                    throw new Exception();
                }

                foreach (var child in selected_child.children)
                {
                    double curr_ucb = Ucb_value(child);

                    if (curr_ucb > max_ucb)
                    {
                        max_ucb = curr_ucb;
                        selected_child = child;
                    }
                }

                if (selected_child.parent == null)
                {
                    throw new Exception();
                }
            }

            return selected_child;

        }

        public static Node Expansion(Node node)
        {

            Create_children(node);

            if (node.children.Count == 0)
            {
                return node;
            }

            Random random = new Random();

            int count = node.children.Count;

            return node.children[random.Next(count)];
        }

        public static double Ucb_value(Node node)
        {
            return (node.wins / (node.numberOfSimulations + 0.01)) + Math.Sqrt(2) * Math.Sqrt(Math.Log(node.parent.numberOfSimulations + 0.01) / (node.numberOfSimulations + 0.01));
        }

        public static void Create_children(Node node)
        {
            Generating.WhitePlays = node.WhitePlays;

            bool checkValidMoves = false;

            if (node.parent == null)
            {
                checkValidMoves = true;
            }

            for (int i = 0; i < node.board.GetLength(0); i++)
            {
                for (int j = 0; j < node.board.GetLength(1); j++)
                {
                    if (node.board[i, j] != null && node.board[i, j].isWhite == node.WhitePlays)
                    {
                        Generating.Generate(node.board[i, j], false, i, j, checkValidMoves, node.board);
                    }
                }
            }

            for (int i = 0; i < Moves.final_x.Count; i++)

            {
                Node newnode = new Node
                {
                    children = new List<Node>(),
                    WhitePlays = !node.WhitePlays,
                    board = node.board.Clone() as Pieces[,],
                    numberOfSimulations = 0,
                    wins = 0,
                    parent = node,

                    final_x = Moves.final_x[i],
                    final_y = Moves.final_y[i],
                    start_x = Moves.start_x[i],
                    start_y = Moves.start_y[i]
                };

                newnode.board[Moves.final_x[i], Moves.final_y[i]] = newnode.board[Moves.start_x[i], Moves.start_y[i]];
                newnode.board[Moves.start_x[i], Moves.start_y[i]] = null;

                node.children.Add(newnode);
            }

            Moves.EmptyCoordinates();
        }

        public static int FindRandomMove(Pieces[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != null && board[i, j].isWhite == Generating.WhitePlays)
                    {
                        Generating.Generate(board[i, j], false, i, j, false, board);
                    }
                }
            }

            Random rnd = new Random();

            if (Moves.final_x.Count == 0)
            {
                return -1;
            }

            return rnd.Next(Moves.final_x.Count);
        }

        public static int Rollout(Node node)
        {
            Pieces[,] board = node.board.Clone() as Pieces[,];

            Generating.WhitePlays = node.WhitePlays;

            for (int i = 0; i < LOOPS; i++)
            {
                //tady udělat na šachovnici tah
                int move = FindRandomMove(board);




                //nenašel se žádný tah
                if (move == -1)
                {
                    if (Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers)
                    {

                        if (Generating.WhitePlays)
                        {
                            return -1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    return 0;
                }

                //aplikuj tah na dané šachovnici
                MoveController.ApplyMove(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move], board);

                Moves.EmptyCoordinates();

                if (Gameclass.CurrentGame.gameType == Gameclass.GameType.chess)
                {
                    //zda skončila hra
                    if (IsMissing(0, board))
                    {
                        return 1;
                    }

                    if (IsMissing(21, board))
                    {
                        return -1;
                    }
                }


                if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi)
                {
                    //zda skončila hra
                    if (IsMissing(7, board))
                    {
                        return 1;
                    }

                    if (IsMissing(28, board))
                    {
                        return -1;
                    }
                }


                Generating.WhitePlays = !Generating.WhitePlays;
            }

            return 0;
        }

        public static bool IsMissing(int pieceNumber, Pieces[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != null && board[i, j].GetNumber() == pieceNumber)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void Backpropagation(Node node, int reward)
        {
            while (node != null)
            {
                /*if (node.WhitePlays)
                {
                    node.wins -= reward;
                }
                else
                {
                    node.wins += reward;
                }*/

                if ((!node.WhitePlays) && (reward==1))
                {
                    node.wins += 1;
                }

                if ((node.WhitePlays) && (reward == -1))
                {
                    node.wins += 1;
                }

                node.numberOfSimulations++;
                node = node.parent;
            }

        }


        public static Node BestChild(Node root)
        {
            Node bestnode = root.children[0];

            for (int i = 1; i < root.children.Count; i++)
            {
                if (root.children[i].wins < bestnode.wins)
                {
                    bestnode = root.children[i];
                }
            }

            return bestnode;
        }
    }
}
