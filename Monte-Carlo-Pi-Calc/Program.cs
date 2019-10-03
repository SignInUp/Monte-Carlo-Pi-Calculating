using System;
using System.Diagnostics;
using System.IO;

using Shapes;

namespace Monte_Carlo_Pi_Calc {
    class Program {
        static void Main(string[] args) {

            Console.Write("Radius = ");
            var radius = int.Parse(Console.ReadLine());

            if (radius < 10) {
                Console.WriteLine("You has to write >= 10");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("There is " + (radius * radius) + " points");

            Console.Write("Count of created points = ");    
            var pointsCount = int.Parse(Console.ReadLine());

            var stopwatch = Stopwatch.StartNew();
            double[] pi = FindPi(pointsCount, radius);
            stopwatch.Stop();

            WriteData(pi, radius, pointsCount, stopwatch.ElapsedMilliseconds, "..\\..\\..\\Output.txt");

            Console.ReadLine();
        }
        static double[] FindPi(int pointsCount, int radius) {
            
            var allPi = new double[10];
            var circle = new Circle(radius);
            var rnd = new Random();
            var inCircle = 0;
            
            for (int i = 0; i < 10; ++i) {
                for (int j = 0; j < pointsCount / 10; ++j) {

                    var point = new Point(rnd.Next(0, circle.Radius + 1), rnd.Next(0, circle.Radius + 1));

                    if (circle.IsPointInCircle(point))
                        ++inCircle;

                }
                allPi[i] = (4.0 * inCircle / pointsCount);
            }

            return allPi;
        }
        static void WriteData(double[] pi, int radius, int pointsCount, long time, string path) {

            var fs = new StreamWriter(path, true);
            fs.WriteLine("Radius = " + radius);
            fs.WriteLine("Count of created points: " + pointsCount + "\r\n");

            for (int i = 0; i < 10; ++i) {
                fs.WriteLine("Cycle " + (i + 1) * (pointsCount / 10) + ": " + pi[i]);
            }

            fs.WriteLine("\r\nDelta: " + (Math.PI - pi[9]));
            fs.WriteLine("TIME: " + time + "ms");
            fs.WriteLine("<------------------------------------------>\r\n");
            fs.Close();

            Console.WriteLine("Data in the file by adress: " + path);

        }
    }
}
