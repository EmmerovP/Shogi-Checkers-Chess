using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShogiCheckersChess
{

    public class EvaluationTree
    {
        int value;

        public Moves.CoordinatesCopy coordinates_parent;

        public List<EvaluationTree> coordinates_children;
    }

    public class RandomMoveGen
    {
        const int depth = 3;

        public static bool WhiteSide = false;


        //já nevím tohle jde asi líp...
        public static int CurrentHighest;

        

        //není něco v knihovně na tohle?
        public static bool isEqual(int a)
        {
            if (a == CurrentHighest)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<int> HighestIndexes(int highest, List<int> list)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == highest)
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

        public static int Highest(List<int> list)
        {
            int highest = Int32.MinValue;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > highest)
                {
                    highest = list[i];
                }
            }
            return highest;
        }

        public static int Lowest(List<int> list)
        {
            int lowest = Int32.MaxValue;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < lowest)
                {
                    lowest = list[i];
                }
            }
            return lowest;
        }


        public static int EvaluateMaxTree(EvaluationTree tree)
        {
            int highest = Int32.MinValue;

            //nejprve zjisti, jakou hodnotu má podstrom. Pokud už žádný není, je to 0
            for (int i = 0; i < tree.coordinates_children.Count; i++)
            {
                if (tree.coordinates_children[i] != null)
                {
                    int value = EvaluateMinTree(tree.coordinates_children[i]) + tree.coordinates_parent.value[i]; 
                    if (value > highest)
                    {
                        highest = value;
                    }
                }
                else
                {
                    return Highest(tree.coordinates_parent.value);
                }              
            }

            return highest;
        }

        public static int EvaluateMinTree(EvaluationTree tree)
        {
            int lowest = Int32.MaxValue;

            //nejprve zjisti, jakou hodnotu má podstrom. Pokud už žádný není, je to 0
            for (int i = 0; i < tree.coordinates_children.Count; i++)
            {
                if (tree.coordinates_children[i] != null)
                {
                    int value = EvaluateMaxTree(tree.coordinates_children[i]) - tree.coordinates_parent.value[i];
                    if (value < lowest)
                    {
                        lowest = value;
                    }
                }
                else
                {
                    return Lowest(tree.coordinates_parent.value) * (-1);
                }
            }

            return lowest;
        }


        public static EvaluationTree OneStep(int depth)
        {
            if (depth == 0)
            {
                return null;
            }

            //Vygenerujeme možné tahy na momentální šachovnici
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(0); j++)
                {
                    if ((Board.board[i, j] != null) && (Board.board[i, j].isWhite == Generating.WhitePlays))
                    {
                        Generating.Generate(Board.board[i, j], false, i, j);
                    }
                }
            }

            if (Moves.final_x.Count != 0)
            {
                //vytvoříme nový evaluační strom, do parentu dáme tahy
                EvaluationTree newTree = new EvaluationTree();
                var cp = Moves.MakeCopyEmpty();
                newTree.coordinates_parent = cp;
                newTree.coordinates_children = new List<EvaluationTree>();

                //prohodíme strany na další tah
                Generating.WhitePlays = !Generating.WhitePlays;
                //tvoříme děti jednotlivých tahů
                for (int k = 0; k < cp.final_x.Count; k++)
                {
                    var piece = Board.board[cp.start_x[k], cp.start_y[k]];
                    var takenpiece = Board.board[cp.final_x[k], cp.final_y[k]];
                    Board.board[cp.final_x[k], cp.final_y[k]] = Board.board[cp.start_x[k], cp.start_y[k]];
                    Board.board[cp.start_x[k], cp.start_y[k]] = null;

                    newTree.coordinates_children.Add(OneStep(depth - 1));

                    Board.board[cp.start_x[k], cp.start_y[k]] = piece;
                    Board.board[cp.final_x[k], cp.final_y[k]] = takenpiece;
                }

                Generating.WhitePlays = !Generating.WhitePlays;

                return newTree;
            }

            return null;

        }

        public static int FindPiece()
        {
            bool WhoPlays = Generating.WhitePlays;

            Generating.CheckersTake = false;
            Moves.EmptyCoordinates();


            EvaluationTree tree = new EvaluationTree();

            //vygeneruj všechny možný tahy, pokud je dáma  amusí se vzít figurka tak jen ty
            if (!((Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers) && (Gameclass.CurrentGame.MustTakeAI())))
            {
                tree = OneStep(depth);
            }
            else
            {
                Generating.CheckersTake = true;
            }

            Generating.WhitePlays = WhoPlays;

            //pokud je nějaký tah možný, vyber nějaký s největší hodnotou a posuň tam figurku

            Random rnd = new Random();

            if (tree.coordinates_parent.value.Count == 0)
            {
                return -1;
            }

            for (int i = 0; i < tree.coordinates_parent.value.Count; i++)
            {
                if (tree.coordinates_children[i] != null)
                {
                    tree.coordinates_parent.value[i] = tree.coordinates_parent.value[i] + EvaluateMinTree(tree.coordinates_children[i]);
                }
            }

            int highest = Highest(tree.coordinates_parent.value);
            var indexes = HighestIndexes(highest, tree.coordinates_parent.value);
            int move = rnd.Next(indexes.Count);

            Moves.EmptyCoordinates();

            Moves.CoordinatesReturn(tree.coordinates_parent);

            int pos = indexes[move];
            Board.board[Moves.final_x[pos], Moves.final_y[pos]] = Board.board[Moves.start_x[pos], Moves.start_y[pos]];
            Board.board[Moves.start_x[pos], Moves.start_y[pos]] = null;

            //vrať nějaké číslo
            return pos;

        }
    }
}
