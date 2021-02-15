using System;
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
            public List<Node> children;
        }


        const float MAXTIME = 1.0F;
        public static Node MonteCarloRoot(Node Root)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            while (time.ElapsedMilliseconds < MAXTIME)
            {
                Node leaf = Traverse(Root);
                var simulation_result = Rollout(leaf);
                Backpropagate(leaf, simulation_result);
            }

            return BestChild(Root);
        }

        public static Node Traverse(Node node)
        {
            //dokud není uzel "fully explored"
            while (Endgame(node.board))
            {
                node = BestUCT(node);
            }

            for (int i = 0; i < node.children.Count; i++)
            {
                if (node.children[i].visited == 0)
                {
                    return node.children[i];
                }
            }

            return node;
        }

        public static bool Endgame(Pieces[,] board)
        {
            //zda na dané šachovnici došlo ke konci hry
            return false;
        }

        public static Node BestUCT(Node node)
        {
            //vygenerujeme všechny boardy z daného node, napojíme je na původní node
            //vypočítáme si uct
            //vybereme nejvyšší uct, napojíme ho
            return node;
        }

        //prostě se vybere náhodný child node 
        public static Node Rollout(Node node)
        {
            Random random = new Random();
            int i = random.Next(node.children.Count);
            return node.children[i];
        }

        public static void Backpropagate(Node leaf, Node result)
        {
            if (leaf.parent == null)
            {
                return;
            }

            //update stats??

            Backpropagate(leaf.parent, result);


        }

        public static Node BestChild(Node root)
        {
            Node bestnode = root.children[0];

            for (int i = 1; i < root.children.Count; i++)
            {
                if (root.children[i].visited > bestnode.visited)
                {
                    bestnode = root.children[i];
                }
            }

            return bestnode;
        }
    }
}   
