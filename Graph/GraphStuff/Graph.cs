using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        public Graph(string path)
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
            
                using(StreamReader reader = new StreamReader(path))
                {
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                provider.NumberDecimalDigits = 2;
                string line;
                    int lineNumber=0;
                while ((line = reader.ReadLine()) != null) {
                    if (lineNumber == 0)
                    {
                        int noOfNodes = line.Split('\t').Count();
                        for (int i = 0; i < noOfNodes-1; i++)
                            Nodes.Add(new Node());
                    }
                    string[] details = line.Split('\t');
                    for (int i = lineNumber + 1; i < details.Count()-1; i++)
                    {
                        double weight = Convert.ToDouble(details[i], provider);
                        Edge edge = new Edge(Nodes[lineNumber], Nodes[i], weight);
                        Edges.Add(edge);
                    }

                    lineNumber++;
                    }
              
                }
        }

        public List<Edge> GetEdges(Node node)
        {
            List<Edge> neighbors = new List<Edge>();
            foreach(Edge edge in Edges)
            {
                if (edge.Contains(node))
                    neighbors.Add(edge);
            }
            return neighbors;
        }

        public Edge GetEdge(Node x, Node y)
        {
            foreach(Edge edge in Edges)
            {
                if (edge.Contains(x) && edge.Contains(y))
                    return edge;
            }
            return null;
        }
        
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
           for(int i = 0; i < Nodes.Count(); i++)
            {
                for(int j = 0; j < Nodes.Count(); j++)
                {
                    if (i == j)
                        builder.Append("0\t");
                    else
                    {
                        Edge edge = GetEdge(Nodes[i], Nodes[j]);
                        builder.Append(edge.Weight + "\t");
                    }
                    
                }
                builder.Append("\n");
            }
            return builder.ToString();
        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\Filip\Desktop\Grafy\15.txt";
            Graph g = new Graph(path);
            Console.WriteLine(g.ToString());
            
            Console.ReadKey();
        }
    }
}
