using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightedGraphRandomizer
{
    public class Point
    {
        private double x, y;



        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
    }
}
