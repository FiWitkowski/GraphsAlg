using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.GraphStuff
{
    public class PairOfNodes
    {
        private Node x, y;

        public PairOfNodes(Node x, Node y)
        {
            X = x;
            Y = y;
        }
        public Node X { get => x; private set => x = value; }
        public Node Y { get => y; private set => y = value; }
    }


}
