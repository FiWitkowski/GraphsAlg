using System;
using System.Collections.Generic;
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
            
                using(StreamReader reader = new StreamReader(path))
                {
                 string line;
                    bool firstLine=true;
                    while((line = reader.ReadLine()) != null){
                    if (firstLine)
                    {
                        int noOfNodes=line.Split('\t').Count();
                        for (int i = 0; i < noOfNodes; i++)
                            Nodes.Add(new Node());
                    }


                    }
              
                }
        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\Filip\Desktop\Grafy\15.txt";
        }
    }
}
