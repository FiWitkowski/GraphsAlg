using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.GraphStuff;

namespace Graph.Algorythms
{

    public class MinimalMatching
    {
        GraphStuff.Graph g;
        static List<Edge> bestMatching;
        double bestCost;
        List<Node> freeNodes;
        Dictionary<Edge, int> edgeAvaiability;
        List<Edge> sortedEdges;

        public MinimalMatching(GraphStuff.Graph g)
        {
            this.g = g;
            bestMatching = new List<Edge>();
            bestCost = Double.MaxValue;
            sortedEdges = g.Edges.OrderBy(e => e.Weight).ToList();
            edgeAvaiability = new Dictionary<Edge, int>();
            sortedEdges.ForEach(e => edgeAvaiability.Add(e, 0));         
        }

        private double CountCost(List<Edge> edgeList)
        {
            double score = 0;
            edgeList.ForEach(e => score += e.Weight);
            return score;
        }

        private void MatchEdge(Edge edge)
        {
            foreach (Edge e in g.GetEdges(edge.Nodes.X))
                edgeAvaiability[e]++;
            foreach (Edge e in g.GetEdges(edge.Nodes.Y))
                edgeAvaiability[e]++;
        }

        private void UnmatchEdge(Edge edge)
        {
            foreach (Edge e in g.GetEdges(edge.Nodes.X))
                edgeAvaiability[e]--;
            foreach (Edge e in g.GetEdges(edge.Nodes.Y))
                edgeAvaiability[e]--;
        }


        public List<Edge> Do()
        {
            
            List<Edge> matching = new List<Edge>();
            ExpandMatching(matching);

            return bestMatching;
        }

        private double ExpandMatching(List<Edge> prev)
        {
            List<Edge> matching = prev;
            foreach (Edge edge in sortedEdges)
            {
                if (edgeAvaiability[edge]==0)
                {
                    MatchEdge(edge);
                    matching.Add(edge);
                    double cost = CountCost(matching);
                    if (cost < bestCost)
                    {

                        if (matching.Count == g.Nodes.Count / 2)
                        {
                             bestMatching.Clear();
                             matching.ForEach(e => bestMatching.Add(e));
                             bestCost = cost;
                        }
                        else
                            ExpandMatching(matching);
                    }
                    matching.Remove(edge);
                    UnmatchEdge(edge);
                }
            }

            return 0;
        }
    }
}
