using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.GraphStuff;

namespace Graph.Algorythms
{
    public class Prim
    {
        private GraphStuff.Graph inputGraph;
        private GraphStuff.Graph outputGraph;

        public Prim(GraphStuff.Graph inputG)
        {
            inputGraph = inputG;
        }

        public GraphStuff.Graph Do()
        {
            List<Node> outNodes = inputGraph.Nodes;
            List<Edge> outEdges = new List<Edge>();

            List<Node> treeNodes = new List<Node>();
            treeNodes.Add(outNodes[0]);
            FibonacciHeap.FibonacciHeap<Edge, double> heap = new FibonacciHeap.FibonacciHeap<Edge,double>(0.0);
            while (treeNodes.Count != outNodes.Count)
            {
               
                foreach (Node node in inputGraph.Nodes)
                {
                    if (!treeNodes.Contains(node))
                    {
                        List<Edge> connectingEdges = new List<Edge>();
                        List<Edge> adjecentEdges = inputGraph.GetEdges(node);
                        
                        foreach (Edge edge in adjecentEdges)
                        {
                            
                            foreach(Node treeNode in treeNodes)
                            {
                                if (edge.Contains(treeNode))
                                {
                                    connectingEdges.Add(edge);
                                }
                            }

                        }
                        connectingEdges = connectingEdges.OrderBy(e => e.Weight).ToList();
                        FibonacciHeap.FibonacciHeapNode<Edge, double> fNode = new FibonacciHeap.FibonacciHeapNode<Edge, double>(connectingEdges[0], connectingEdges[0].Weight);
                        heap.Insert(fNode);
                    } 
                }
               

                Edge minEdge = heap.RemoveMin().Data;
                outEdges.Add(minEdge);
                if (treeNodes.Contains(minEdge.Nodes.X))
                    treeNodes.Add(minEdge.Nodes.Y);
                else
                    treeNodes.Add(minEdge.Nodes.X);
                heap.Clear();
            }

            return new GraphStuff.Graph(outNodes,outEdges);
        }

    }
}
