using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.GraphStuff;

namespace Graph.Algorythms
{
    
    class CutToHamilton
    {
        Queue<Edge> qEdges;
        GraphStuff.Graph orgGraph;

        public CutToHamilton(Queue<Edge> q,GraphStuff.Graph graph)
        {
            qEdges = q;
            this.orgGraph = graph;
        }

        public CutToHamilton(Queue<Edge> q)
        {
            qEdges = q;
        
        }
        public GraphStuff.Graph Cut()
        {
            Queue<Node> qNodes = new Queue<Node>();

            while (qEdges.Count != 0)
            {
                Edge e = qEdges.Dequeue();
                if (!qNodes.Contains(e.Nodes.X))
                    qNodes.Enqueue(e.Nodes.X);
                if (!qNodes.Contains(e.Nodes.Y))
                    qNodes.Enqueue(e.Nodes.Y);
            }

            List<Edge> edges = new List<Edge>();
            Node x = qNodes.Dequeue();
            Node firstNode = x;
            Node y=null;
            while (qNodes.Count != 0)
            {
                y = qNodes.Dequeue();
                edges.Add(orgGraph.GetEdge(x, y));
                x = y;
            }
            edges.Add(orgGraph.GetEdge(firstNode, y));
            //List<Edge> edges = new List<Edge>();
            //List<Node> nodes = new List<Node>();
            //GraphStuff.Graph newGraph = new GraphStuff.Graph(orgGraph.Nodes, edges);
            //Edge edge = qEdges.Dequeue();
            //Node previous;

            //edges.Add(edge);
            //if (qEdges.Peek().Contains(edge.Nodes.X))
            //{
            //    nodes.Add(edge.Nodes.Y);
            //    previous = edge.Nodes.Y;
            //}
            //else if (qEdges.Peek().Contains(edge.Nodes.Y))
            //{
            //    nodes.Add(edge.Nodes.X);
            //    previous = edge.Nodes.X;
            //}

            //while (qEdges.Count != 0)
            //{
            //    edge = qEdges.Dequeue();
            //    if (nodes.Contains(edge.Nodes.X) && !nodes.Contains(edge.Nodes.Y))
            //    {
            //        edge = orgGraph.GetEdge(edge.Nodes.X, edge.Nodes.Y);
            //        edges.Add(edge);
            //    }
            //}

            //List<Edge> lEdges = new List<Edge>();
            //List<Node> lNodes = new List<Node>();
            //Edge cEdge = qEdges.Peek();
            //lNodes.Add(cEdge.Nodes.X);
            //while (qEdges.Count!=0)
            //{
            //    cEdge = qEdges.Dequeue();
            //    if (!lNodes.Contains(cEdge.Nodes.Y))
            //    {
            //        lNodes.Add(cEdge.Nodes.Y);
            //        lEdges.Add(cEdge);
            //    }
            //    else if (!lNodes.Contains(cEdge.Nodes.X))
            //    {
            //        lNodes.Add(cEdge.Nodes.X);
            //        lEdges.Add(cEdge);
            //    }
            //    else
            //    {
            //        //nothing
            //    }




            return new GraphStuff.Graph(orgGraph.Nodes, edges);
        }
    }
}
