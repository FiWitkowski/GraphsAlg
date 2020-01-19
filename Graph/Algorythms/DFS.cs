﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.GraphStuff;

namespace Graph.Algorythms
{
    public class DFS
    {
        List<Node> zajete;
        GraphStuff.Graph g;
        public DFS(GraphStuff.Graph g)
        {
            zajete = new List<Node>();
            this.g = g;
        }

        public void Do()
        {
            Node node = g.Nodes[0];

            Continue(node);



        }
        private void Continue(Node currentNode)
        {
            zajete.Add(currentNode);
            foreach(Node n in g.GetNeighbors(currentNode))
            {
                if (!zajete.Contains(n))
                    Continue(n);
            }
        }

        public bool DoForTree()
        {
            Node node = g.Nodes[0];

            return ContinueForTree(node,node);



        }
        private bool ContinueForTree(Node currentNode, Node prev)
        {
            bool isTree = true;
            zajete.Add(currentNode);
            List<Node> neightbors = g.GetNeighbors(currentNode);
            foreach (Node n in neightbors)
            {
                if (!zajete.Contains(n))
                    isTree = ContinueForTree(n,currentNode);
                else
                {
                    if (!n.Equals(prev))
                        return false;
                }
                if (!isTree)
                    return false;
            }
            return isTree;
        }

    }
}
