using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.GraphStuff
{
   

    public class Edge
    {
        private static int numberOfEdges;
        private PairOfNodes nodes;
        private double weight;

        public PairOfNodes Nodes { get => nodes; private set => nodes = value; }
        public double Weight { get => weight; private set => weight = value; }

        public Edge(Node x, Node y, double weight)
        {
            nodes = new PairOfNodes(x, y);
            Weight = weight;
            numberOfEdges++;
        }


    }
}
