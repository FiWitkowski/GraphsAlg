using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightedGraphRandomizer
{
    class Pane
    {
        private List<Pair> pane;
        Random rand;

        public Pane() {
            rand = new Random(DateTime.Now.Millisecond);
            pane = new List<Pair>(); 
        }

        public Pane(int n) {
            rand= new Random(DateTime.Now.Millisecond);
            pane = new List<Pair>();
            pane = addPoints(n);
        }

        public Pair addPoint()
        {
            double x = rand.NextDouble()*1000;
            double y = rand.NextDouble()*1000;
            Pair point = new Pair(x, y);
            pane.Add(point);

            return point;
        }

        public List<Pair> addPoints(int number)
        {
            List<Pair> listPair = new List<Pair>();
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
            double x;
            foreach(Pair p1 in pane)
            {
                foreach(Pair p2 in pane)
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
        public static void printDoubles(double[] table)
        {
            int indexer = 0;
            foreach(double d in table)
            {
                Console.Out.Write(d + "\t");
                indexer++;
                if (indexer % 5 == 0)
                    Console.Out.WriteLine();
            }
                
        }

        static void Main(string[] args)
        {
            double[] sto = new double[10];
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 10; i++)
                sto[i] = rand.NextDouble();
            Pane.printDoubles(sto);
            Console.WriteLine("\n");
            for (int j = 0; j < 1000; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (sto[i] <= 0.5)
                        sto[i] =sto[i]*2;
                    else
                        sto[i] = sto[i]/2;
                }
                Pane.printDoubles(sto);
                Console.WriteLine("\n");
                
            }
            Console.ReadKey();
        }
    }
}
