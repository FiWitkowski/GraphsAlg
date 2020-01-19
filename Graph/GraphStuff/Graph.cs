using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.GraphStuff
{
    public class Graph
    {
        private List<Node> nodes;
        private List<Edge> edges;

        public List<Node> Nodes { get => nodes; private set => nodes = value; }
        public List<Edge> Edges { get => edges; private set => edges = value; }

        public Graph(Graph g)
        {
            Nodes = new List<Node>(g.Nodes);
            Edges = new List<Edge>(g.Edges);
        }

        public Graph(int size)
        {

        }

        static void Main(string[] args)
        {
        }
    }
}
