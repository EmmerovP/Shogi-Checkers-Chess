using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShogiCheckersChess
{

    public class MonteCarlo
    {

        public static bool whitePlays;

        public static bool isAddingPiece;

        public class Node
        {
            public Pieces[,] board;
            public Node parent;
            public int numberOfSimulations;
            public int wins;
            public List<Node> children;
            public bool WhitePlays;
            public int id;
            public Pieces piece;

            public List<Pieces> piecesTakenFromWhite;
            public List<Pieces> piecesTakenFromBlack;

            public int start_x;
            public int start_y;
            public int final_x;
            public int final_y;
        }

        public static int GetNextMove(bool isWhite)
        {

            isAddingPiece = false;

            var rootnode = new Node
            {
                children = new List<Node>(),
                WhitePlays = isWhite,
                board = Board.board.Clone() as Pieces[,],
                numberOfSimulations = 1,
                wins = 0,
                parent = null,
                id = 0,

                piecesTakenFromWhite = new List<Pieces>(),
                piecesTakenFromBlack = new List<Pieces>()
            };

            rootnode.piecesTakenFromBlack.AddRange(MainGameWindow.whiteShogiAIPieces);
            rootnode.piecesTakenFromWhite.AddRange(MainGameWindow.shogiAIPieces);

            whitePlays = isWhite;

            var node = MonteCarloRoot(rootnode);

            if (node == null)
            {
                return -1;
            }

            Moves.EmptyCoordinates();

            Moves.final_x.Add(node.final_x);
            Moves.final_y.Add(node.final_y);
            Moves.start_x.Add(node.start_x);
            Moves.start_y.Add(node.start_y);

            if (node.start_y == -1)
            {
                isAddingPiece = true;

                if (whitePlays)
                {
                    MainGameWindow.whiteShogiAIPieces.Remove(node.piece);
                }
                else
                {
                    MainGameWindow.shogiAIPieces.Remove(node.piece);
                }
            }

            return 0;

        }


        const float MAXTIME = 100.0F;
        const int LOOPS = 700;

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

            if (Root.children.Count == 0)
            {
                return null;
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

            Generating.GenerateAllMoves(node.board, true);

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

                    piecesTakenFromWhite = new List<Pieces>(),
                    piecesTakenFromBlack = new List<Pieces>(),

                    final_x = Moves.final_x[i],
                    final_y = Moves.final_y[i],
                    start_x = Moves.start_x[i],
                    start_y = Moves.start_y[i]
                };

                newnode.piecesTakenFromWhite.AddRange(node.piecesTakenFromWhite);
                newnode.piecesTakenFromBlack.AddRange(node.piecesTakenFromBlack);

                MoveController.ApplyMove(Moves.start_x[i], Moves.start_y[i], Moves.final_x[i], Moves.final_y[i], newnode.board);

                node.children.Add(newnode);
            }


            if (((MainGameWindow.shogiAIPieces.Count == 0) && (!whitePlays)) || ((MainGameWindow.whiteShogiAIPieces.Count == 0) && (whitePlays)))
            {
                return;
            }

            //create copy of available pieces we can put on a board, so we don't have an inconsistency during going through the list
            List<Pieces> availablePieces = new List<Pieces>();

            if (node.WhitePlays)
            {
                availablePieces.AddRange(node.piecesTakenFromBlack);
            }
            else
            {
                availablePieces.AddRange(node.piecesTakenFromWhite);
            }

            Moves.EmptyCoordinates();

            foreach (var piece in availablePieces)
            {
                for (int i = 0; i < node.board.GetLength(0); i++)
                {
                    for (int j = 0; j < node.board.GetLength(1); j++)
                    {
                        if (node.board[i, j] == null)
                        {
                            //we can't put another shogi pawn to the column where there already is
                            if (PiecesNumbers.IsShogiPawn(piece))
                            {
                                if (PawnColumn(j, whitePlays, node.board))
                                {
                                    break;
                                }

                            }

                            Node newnode = new Node
                            {
                                children = new List<Node>(),
                                WhitePlays = !node.WhitePlays,
                                board = node.board.Clone() as Pieces[,],
                                numberOfSimulations = 0,
                                wins = 0,
                                parent = node,
                                piece = piece,

                                piecesTakenFromWhite = new List<Pieces>(),
                                piecesTakenFromBlack = new List<Pieces>(),

                                final_x = i,
                                final_y = j,
                                start_y = -1
                            };

                            newnode.piecesTakenFromWhite.AddRange(node.piecesTakenFromWhite);
                            newnode.piecesTakenFromBlack.AddRange(node.piecesTakenFromBlack);

                            

                            if(node.WhitePlays)
                            {
                                Board.AddPiece(PiecesNumbers.getBottomNumber[piece.Name], i, j, newnode.board);
                                newnode.start_x = PiecesNumbers.getBottomNumber[piece.Name];
                                newnode.piecesTakenFromBlack.Remove(piece);
                            }
                            else
                            {
                                Board.AddPiece(PiecesNumbers.getUpperNumber[piece.Name], i, j, newnode.board);
                                newnode.start_x = PiecesNumbers.getUpperNumber[piece.Name];
                                newnode.piecesTakenFromWhite.Remove(piece);
                            }

                            node.children.Add(newnode);
                        }
                    }

                }
            }

            
        }

        /// <summary>
        /// Check whether it is okay to put a shogi pawn in specified column.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static bool PawnColumn(int column, bool isWhite, Pieces[,] Board)
        {
            for (int i = 0; i < Board.GetLength(1); i++)
            {
                if (Board[i, column] != null && PiecesNumbers.IsShogiPawn(Board[i, column]) && Board[i, column].isWhite == isWhite)
                {
                    return true;
                }

            }
            return false;
        }

        public static void FindRandomPiece(Pieces[,] board)
        {
            List<int> x = new List<int>();
            List<int> y = new List<int>();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i,j] != null && board[i,j].isWhite == Generating.WhitePlays)
                    {
                        x.Add(i);
                        y.Add(j);
                    }
                }
            }

            int counter = 0;
            Random rnd = new Random();

            while (Moves.GetCount()==0 && counter<x.Count)
            {
                var position = rnd.Next(x.Count);

                var piece = board[x[position], y[position]];

                piece.GenerateMoves(x[position], y[position], board);

                counter++;
            }
        }

        public static int FindRandomMove(Pieces[,] board)
        {
            FindRandomPiece(board);

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
                Moves.EmptyCoordinates();

                //tady udělat na šachovnici tah
                int move = FindRandomMove(board);

                //nenašel se žádný tah
                if (move == -1)
                {
                    if (Gameclass.CurrentGame.gameType == Gameclass.GameType.chess)
                    {
                        if ((whitePlays && node.WhitePlays) || (!whitePlays && !node.WhitePlays))
                        {
                            return -1;
                        }
                        else
                        {
                            return 1;
                        }
                    }

                    if (Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers)
                    {

                        if ((whitePlays && node.WhitePlays) || (!whitePlays && !node.WhitePlays))
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


                if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi)
                {

                    if (IsMissing(7, board))
                    {
                        if (whitePlays)
                        {
                            return -1;
                        }
                        else
                        {
                            return 1;
                        }
                    }

                    if (IsMissing(28, board))
                    {
                        if (whitePlays)
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
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
                        return false;
                    }
                }
            }
            return true;
        }

        public static void Backpropagation(Node node, int reward)
        {
            while (node != null)
            {
                if ((node.WhitePlays == whitePlays) && (reward == 1))
                {
                    node.wins += 1;
                }

                if ((node.WhitePlays != whitePlays) && (reward == -1))
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
