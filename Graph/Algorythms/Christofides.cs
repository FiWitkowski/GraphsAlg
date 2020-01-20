using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.GraphStuff;

namespace Graph.Algorythms
{
    public class Christofides
    {
        GraphStuff.Graph graph;
        public Christofides(GraphStuff.Graph g)
        {
            graph = g;
        }

        public GraphStuff.Graph Do()
        {
            
            KeyValuePair<GraphStuff.Graph, GraphStuff.Graph> vp = graph.PrepareGraphForMatching();

            GraphStuff.Graph tree = vp.Key;
            GraphStuff.Graph prepared = vp.Value;

            GraphStuff.Graph matched = prepared.MinimalMatching();
            GraphStuff.Graph merged = tree.MergeWithMatching(matched.Edges);

            EulerPath eulerAlg = new EulerPath(merged);
            Queue<Edge> eulerPath = eulerAlg.FindEuler();
            CutToHamilton cutAlg = new CutToHamilton(eulerPath,graph);


            return cutAlg.Cut();


        }

     
    }
}
