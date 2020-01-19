using Graph.Algorythms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.GraphStuff
{
    [Serializable]
    public class Graph
    {
        private List<Node> nodes;
        private List<Edge> edges;

        public List<Node> Nodes { get => nodes; private set => nodes = value; }
        public List<Edge> Edges { get => edges; private set => edges = value; }

        public Graph()
        {
            nodes = new List<Node>();
            edges = new List<Edge>();
        }

        public Graph(List<Node> nodes,List<Edge> edges)
        {
            Nodes = nodes;
            Edges = edges;
        }

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

        public bool IsTree()
        {
            DFS dfs = new DFS(this);
            return dfs.DoForTree();
        }

        public Graph MinimumSpanningTree()
        {
            Prim prim = new Prim(this);
            return prim.Do();
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
                        if (edge==null)
                            builder.Append("0\t");
                        else
                            builder.Append(edge.Weight + "\t");
                    }
                    
                }
                builder.Append("\n");
            }
            return builder.ToString();
        }

        public void Serialize(string path)
        {
            using(StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(this.ToString());
            }
        }

        

        public List<Node> GetNeighbors(Node n)
        {
            List<Node> nodes = new List<Node>();
            List<Edge> edges = GetEdges(n);
            foreach(Edge e in edges)
            {
                if (e.Nodes.X.Equals(n))
                    nodes.Add(e.Nodes.Y);
                else
                    nodes.Add(e.Nodes.X);
            }
            return nodes;
        }



        //For further usees
        private Graph Merge(Graph treeMatching)
        {
            Graph outputG = new Graph(this);
            foreach(Edge edge in treeMatching.Edges)
            {
                outputG.Edges.Add(edge);
            }
            return outputG;
        }

        public Graph PrepareGraphForMatching()
        {
            Graph tree = this.MinimumSpanningTree();
            List<Node> oddNodes = tree.Nodes.Where(e => tree.GetEdges(e).Count % 2 == 1).ToList();
            List<Edge> newEdges = new List<Edge>();
            foreach(Node node in oddNodes)
            {
                this.GetEdges(node).ForEach(e => newEdges.Add(e));
            }
            return new Graph(oddNodes,newEdges);
        }



        static void Main(string[] args)
        {
            string path = @"C:\Users\Filip\Desktop\Grafy\15.txt";
            Graph g = new Graph(path);


            Console.WriteLine(g.PrepareGraphForMatching().ToString());
            Console.WriteLine(g.MinimumSpanningTree().ToString());


            Console.ReadKey();
        }
    }
}
