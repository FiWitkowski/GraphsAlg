using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.GraphStuff;

namespace Graph.Algorythms
{
    public class EulerPath
    {
        GraphStuff.Graph graph;
        
        Queue<Edge> qEdges;
        List<Node> avaiableNodes;

        public EulerPath(GraphStuff.Graph graph)
        {
            this.graph = graph;
            qEdges = new Queue<Edge>();
            avaiableNodes = graph.Nodes.Where(e => graph.GetEdges(e).Count > 0).ToList();
        }
        bool IsBridge(Edge edge)
        {
            GraphStuff.Graph g = new GraphStuff.Graph(graph);
            g.RemoveEdge(edge);

            if(g.Edges.Count==0)
                return false;
            

            DFS dfs = new DFS(g);
            return !dfs.IsConnected();
        }
        public Queue<Edge> FindEuler()
        {

            bool succeed = EulerProceed(avaiableNodes[0]);
            if (succeed)
                return qEdges;
            else
                return null;
        }

        public bool EulerProceed(Node node)
        {
            List<Edge> possibleEdges = graph.GetEdges(node);
            Console.WriteLine(graph.ToString());
            foreach(Edge edge in possibleEdges)
            {
                if(!IsBridge(edge))
                {
                    Edge usedEdge = edge;
                    Node goToNode = graph.GetSecondNode(usedEdge, node);
                    graph.RemoveEdge(usedEdge);
                    qEdges.Enqueue(usedEdge);
                    EulerProceed(goToNode);
                    break;
                }
            }
            if (graph.Edges.Count==0)
                return true;
            else
                return false;
         
        }
    }
}
