using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightedGraphRandomizer
{
    public class Pane
    {
        private List<Point> pane;
        Random rand;

        public Pane() {
            rand = new Random(DateTime.Now.Millisecond);
            pane = new List<Point>(); 
        }

        public Pane(int n) {
            rand= new Random(DateTime.Now.Millisecond);
            pane = new List<Point>();
            pane = addPoints(n);
        }

        public Point addPoint()
        {
            double x = rand.NextDouble()*1000;
            double y = rand.NextDouble()*1000;
            Point point = new Point(x, y);
            pane.Add(point);

            return point;
        }

        public Point addPoint(double x,double y)
        {
            Point point = new Point(x, y);
            pane.Add(point);
            return point;
        }
        public List<Point> addPoints(int number)
        {
            List<Point> listPair = new List<Point>();
            for (int i = 0; i < number; i++)
            {
                listPair.Add(addPoint());
            }
            return listPair;
        }
        public double[,] CalculateDistances()
        {
            int n = pane.Count();
            double[,] distances = new double[n,n];
            
            foreach(Point p1 in pane)
            {
                foreach(Point p2 in pane)
                {
                    if (!p2.Equals(p1))
                    {
                        int index1 = pane.IndexOf(p1);
                        int index2 = pane.IndexOf(p2);
                        double dist = Math.Round(Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)), 2);
                        distances[index1, index2] = dist;
                        distances[index2, index1] = dist;
                    }
                    
                }
            }
            for(int i = 0; i < n; i++)
            {
                distances[i, i] = 0.0;
            }
            return distances;
        }

        public void savePane(string filePath)
        {
            double[,] distances = CalculateDistances();
            int n = pane.Count();

            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                string line = String.Empty;

                for (int i = 0; i < n; i++)
                {

                    for (int j = 0; j < n; j++)
                    {
                        line += distances[i, j] + "\t";
                    }
                    outputFile.WriteLine(line);
                    line = String.Empty;
                }
              
                
                
            }
        }


        static void Main(string[] args)
        {
     

   
        }
    }
}
