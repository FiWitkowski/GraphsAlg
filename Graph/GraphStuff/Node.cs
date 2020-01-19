using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Graph.GraphStuff
{
    public class Node
    {
        public static int totalNumber = 0;
        private int index;
    

        public Node()
        {
            index = totalNumber++;
        }

        protected Node(int x)
        {
            index = x;
            totalNumber++;
        }

        public int Index { get => index; private set => index = value; }
    }
}
