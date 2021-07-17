using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShogiCheckersChess
{
    /// <summary>
    /// Class taking care of implementation of Monte Carlo Tree Search Algorithm
    /// </summary>
    public class MonteCarlo
    {
        /// <summary>
        /// How long does the tree building and search run
        /// </summary>
        public static float maxTime;

        /// <summary>
        /// For how long should a game be played in tree search before it is pronounced a draw
        /// </summary>
        const int LOOPS = 100;

        /// <summary>
        /// Boolean signalizing which side currently plays in this move
        /// </summary>
        public static bool whitePlays;

        /// <summary>
        /// Boolean signalizing whether we are adding piece in this move
        /// </summary>
        public static bool isAddingPiece;

        /// <summary>
        /// One node of Monte Carlo Tree, with references to their parent and children
        /// </summary>
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

        /// <summary>
        /// For given side, chooses the next move with Monte Carlo Tree Search
        /// </summary>
        /// <param name="isWhite"></param>
        /// <returns></returns>
        public static int GetNextMove(bool isWhite)
        {
            //reset boolean for adding a piece on board
            isAddingPiece = false;

            //initialize root node for MCTS data structure
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

            //copy taken pieces from main game to MCTS's lists
            rootnode.piecesTakenFromBlack.AddRange(MainGameWindow.whiteShogiAIPieces);
            rootnode.piecesTakenFromWhite.AddRange(MainGameWindow.shogiAIPieces);

            //mark current playing side
            whitePlays = isWhite;

            //create the tree and search it
            var node = MonteCarloRoot(rootnode);

            //when no node is selected, that means we can't make any move, we return and game ends
            if (node == null)
            {
                return -1;
            }

            //empty list for coordinates in case there are still some coordinates left
            Moves.EmptyCoordinates();

            //add only value to this list - chosen move
            Moves.final_x.Add(node.final_x);
            Moves.final_y.Add(node.final_y);
            Moves.start_x.Add(node.start_x);
            Moves.start_y.Add(node.start_y);

            //if chosen move is adding a piece on board
            if (node.start_y == -1)
            {
                //mark to the caller that we are adding a piece on board
                isAddingPiece = true;

                //remove piece which we are adding from main list
                if (whitePlays)
                {
                    MainGameWindow.whiteShogiAIPieces.Remove(node.piece);
                }
                else
                {
                    MainGameWindow.shogiAIPieces.Remove(node.piece);
                }
            }

            //the chosem move is in the beginning of the Moves list
            return 0;
        }

        /// <summary>
        /// Main loop for MCTS
        /// </summary>
        /// <param name="Root"></param>
        /// <returns></returns>
        public static Node MonteCarloRoot(Node Root)
        {
            //start measuring time
            Stopwatch time = new Stopwatch();
            time.Start();

           
            //do until there is time set left
            while (time.ElapsedMilliseconds < maxTime)
            {
                //Step 1: Selection
                Node highest_UCB = Selection(Root);

                //Step 2: Expansion
                Node leaf = Expansion(highest_UCB);

                //Step 3: Rollout
                int reward = Rollout(leaf);

                //Step 4: Backpropagation
                Backpropagation(leaf, reward);
            }

            //when there are no children in tree, we can't make a move, game is over
            if (Root.children.Count == 0)
            {
                return null;
            }

            //return chosen node
            return BestChild(Root);
        }

        /// <summary>
        /// Selection phase in MCTS.
        /// Traverses tree and selects the best candidate for expansion with UCB.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns UCB value of given node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static double Ucb_value(Node node)
        {
            return (node.wins / (node.numberOfSimulations + 0.01)) + Math.Sqrt(2) * Math.Sqrt(Math.Log(node.parent.numberOfSimulations + 0.01) / (node.numberOfSimulations + 0.01));
        }

        /// <summary>
        /// Expansion phase in MCTS.
        /// Expand selected and return random new node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates children to given node, all moves, either made out of moving a piece or adding a piece.
        /// </summary>
        /// <param name="node"></param>
        public static void Create_children(Node node)
        {
            Generating.WhitePlays = node.WhitePlays;

            if (Generating.WhitePlays)
            {
                Gameclass.CurrentGame.playType = Gameclass.CurrentGame.whitePlayType;
            }
            else
            {
                Gameclass.CurrentGame.playType = Gameclass.CurrentGame.blackPlayType;
            }

            Generating.GenerateAllMoves(node.board, true);

            //create a new children node for every generated move
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

            //in case lists of taken pieces are empty, return, alse we need to add moves of adding piece to the board
            if (((node.piecesTakenFromWhite.Count == 0) && (!whitePlays)) || ((node.piecesTakenFromBlack.Count == 0) && (whitePlays)))
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

            //adding moves that add pieces to all possible places
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

                            //adds piece to board and removes it from node's list of removed pieces
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

                            if (node.parent == null)
                            {
                                
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

        /// <summary>
        /// Returns random piece from given board, generates all moves for this pieces
        /// </summary>
        /// <param name="board"></param>
        public static void FindRandomPiece(Pieces[,] board)
        {
            List<int> x = new List<int>();
            List<int> y = new List<int>();

            //get lists of coordinates of all available pieces
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

            //until we get a piece that can generate moves, or we find out that we can't generate any moves at all
            while (Moves.GetCount()==0 && counter<x.Count)
            {
                var position = rnd.Next(x.Count);

                var piece = board[x[position], y[position]];

                piece.GenerateMoves(x[position], y[position], board);

                counter++;
            }
        }

        /// <summary>
        /// Returns random move for a board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static int FindRandomMove(Pieces[,] board)
        {
            FindRandomPiece(board);

            Random rnd = new Random();

            //when there are no moves, we return -1
            if (Moves.final_x.Count == 0)
            {
                return -1;
            }

            return rnd.Next(Moves.final_x.Count);
        }

        /// <summary>
        /// Rollout phase of MCTS.
        /// Plays a random game and mark the winner.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static int Rollout(Node node)
        {
            Pieces[,] board = node.board.Clone() as Pieces[,];

            Generating.WhitePlays = node.WhitePlays;

            //until we end the game, or we run out of loops
            for (int i = 0; i < LOOPS; i++)
            {
                Moves.EmptyCoordinates();

                if (Generating.WhitePlays)
                {
                    Gameclass.CurrentGame.gameType = Gameclass.CurrentGame.whiteGameType;
                }
                else
                {
                    Gameclass.CurrentGame.gameType = Gameclass.CurrentGame.blackGameType;
                }

                //finds random move
                int move = FindRandomMove(board);

                //when no move has been found
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

                //apply the move on node's board
                MoveController.ApplyMove(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move], board);

                Moves.EmptyCoordinates();

                //when the game is type shogi
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
        /// <summary>
        /// Returns true when given piece is missing on given board.
        /// </summary>
        /// <param name="pieceNumber"></param>
        /// <param name="board"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Backpropagation step of MCTS.
        /// Gets reward of a played game in node and backpropagates its value to the root.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="reward"></param>
        public static void Backpropagation(Node node, int reward)
        {
            //until we reach the root
            while (node != null)
            {
                //set reawrd accordingly to who plays and whose node it is
                if ((node.WhitePlays == whitePlays) && (reward == 1))
                {
                    node.wins += 1;
                }

                if ((node.WhitePlays != whitePlays) && (reward == -1))
                {
                    node.wins += 1;
                }

                //increase number of simulations
                node.numberOfSimulations++;

                //get to the parent node
                node = node.parent;
            }

        }

        /// <summary>
        /// Looks at root's children and selects the one with highest score.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
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
