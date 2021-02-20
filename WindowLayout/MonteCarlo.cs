﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace ShogiCheckersChess
{

    public class MonteCarlo
    {
        public class Node
        {
            public Pieces[,] board;
            public Node parent;
            public int visited;
            public int score;
            public List<Node> children;
            public bool WhitePlays; //zda tah generovaný po tomto uzlu je bílý

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
                visited = 0,
                score = 0,
                parent = null
            };

            var node = MonteCarloRoot(rootnode);

            Moves.final_x.Add(node.final_x);
            Moves.final_y.Add(node.final_y);
            Moves.start_x.Add(node.start_x);
            Moves.start_y.Add(node.start_y);

            return 0;



        }


        const float MAXTIME = 3000.0F;
        public static Node MonteCarloRoot(Node Root)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            while (time.ElapsedMilliseconds < MAXTIME)
            {
                Node highest_UCB = Selection(Root);
                Node leaf = Expansion(highest_UCB);
                int reward = Rollout(leaf, 0);
                Backpropagation(leaf, reward);

            }

            return BestChild(Root);
        }

        public static Node Expansion(Node node)
        {
            if (node.children.Count == 0)
            {
                return node;
            }

            double max_ucb = Int32.MinValue;

            Node selected_child = null;

            foreach (var child in node.children)
            {
                double curr_ucb = Ucb_value(child);

                if (curr_ucb > max_ucb)
                {
                    max_ucb = curr_ucb;
                    selected_child = child;
                }
            }

            return selected_child;

        }

        public static Node Selection(Node node)
        {
            double max_ucb = Int32.MinValue;

            Node selected_child = null;

            if (node.children.Count == 0)
            {
                Create_children(node);
            }

            foreach (var child in node.children)
            {
                double curr_ucb = Ucb_value(child);

                if (curr_ucb > max_ucb)
                {
                    max_ucb = curr_ucb;
                    selected_child = child;
                }
            }

            return selected_child;
        }

        public static double Ucb_value(Node node)
        {
            return node.score + 2 * (Math.Sqrt(Math.Log(node.parent.visited + 0.01 + Math.E) / (node.visited + 0.01)));
        }

        public static void Create_children(Node node)
        {
            for (int i = 0; i < node.board.GetLength(0); i++)
            {
                for (int j = 0; j < node.board.GetLength(1); j++)
                {
                    if (node.board[i, j] != null && node.board[i, j].isWhite == node.WhitePlays)
                    {
                        node.board[i, j].GenerateMoves(i, j, node.board);
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
                    visited = 0,
                    score = 0,
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

        //prostě se vybere náhodný child node 
        public static int Rollout(Node node, int steps)
        {
            if (steps > 200)
            {
                return 0;
            }

            if (node.children.Count == 0)
            {
                Create_children(node);
            }
           

            if (node.children.Count == 0)
            {
                if (node.WhitePlays)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            Random random = new Random();
            int i = random.Next(node.children.Count);
            steps++;
            return Rollout(node.children[i], steps);
        }

        public static Node Backpropagation(Node node, int reward)
        {
            while (node.parent != null)
            {
                node.score += reward;
                node.visited++;
                node = node.parent;
            }

            return node;

        }


        public static Node BestChild(Node root)
        {
            Node bestnode = root.children[0];

            for (int i = 1; i < root.children.Count; i++)
            {
                if (root.children[i].score > bestnode.score)
                {
                    bestnode = root.children[i];
                }
            }

            return bestnode;
        }
    }
}
